
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Microsoft.Xrm.Sdk;
using MimeKit;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using System;
using System.Net.Http;
using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechCreare.attachments;
using TechCreare.Models;
using TechCreare.Repository;


namespace TechCreare.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly INotyfService _notyf;
        
        public EmailController(IEmailSender emailSender, IHttpClientFactory httpClientFactory, INotyfService notyf)
        {
            _emailSender = emailSender;
            _httpClientFactory = httpClientFactory;
            _notyf = notyf;
        }
        public IActionResult Index(EmailParam entity)
        {
            return View("~/Views/ContactUs/Index.cshtml", entity);
        }



        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> SendEmail([FromForm] EmailParam entity)
        {
            try
            {

                var httpRequestMessage = new HttpRequestMessage(
           HttpMethod.Get,
           "https://ipinfo.io/?token=3c0ec73562f55d");


                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream =
                        await httpResponseMessage.Content.ReadAsStreamAsync();

                    entity.ipDetail = new IpDetail();

                    entity.ipDetail = await System.Text.Json.JsonSerializer.DeserializeAsync<IpDetail>(contentStream);
                }

                string content = htmlTemplate.getContent(entity);
                var message = new Message(new string[] { "info@techcreare.com", "vidya.lakshmi@techcreare.in" }, entity.Message, content, entity.Myfile);

                if (entity.Myfile != null)
                {
                    var fileType = Path.GetExtension(entity.Myfile.FileName);
                    if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".docx" || fileType.ToLower() == ".jpeg" || fileType.ToLower() == ".doc" || fileType.ToLower() == ".txt" || fileType.ToLower() == ".png")
                    {

                        var bodyBuilder = new BodyBuilder { HtmlBody = message.Content };
                        byte[] fileBytes;
                        using (var ms = new MemoryStream())
                        {
                            message.Myfile.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        bodyBuilder.Attachments.Add(message.Myfile.FileName, fileBytes, ContentType.Parse(message.Myfile.ContentType));
                    }
                    else
                    {
                        //ModelState.AddModelError("Myfile", "Please attach a valid  file");
                        _notyf.Error($"Please attach a valid  file, {fileType} is not a valid format.");
                        TempData["invalidAttachment"] = $"Please attach a valid  file, {fileType} is not a valid format.";
                        return RedirectToAction("Index", entity);
                        //return View("Index", entity);
                    }
                }

                _emailSender.SendEmail(message);
                _notyf.Success(" Thank you for contacting us, One of our representatives will be in touch with you soon.");
                return Redirect("/ContactUs/Index");

            }
            catch (Exception ex)
            {
                _notyf.Error("There is some error, please try again after some time...");
                throw;
            }
        }

    }
}




