using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TechCreare.Models
{
    public class EmailParam
    {
        [Description("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Description("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Description("Contact No")]
        [Required(ErrorMessage = "Contact No is required")]
        public string? ContactNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please provide valid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string? Message { get; set; }
        public IFormFile? Myfile { get; set; }

        public IpDetail ipDetail { get; set; }

    }

    public class IpDetail
    {
        public string ip { get; set; }

        public string city { get; set; }

        public string region { get; set; }

        public string country { get; set; }

        public string loc { get; set; }

        public string org { get; set; }

        public string postal { get; set; }

        public string timezone { get; set; }
    }

    public static class htmlTemplate
    {

        public static string getContent(EmailParam param)
        {
            string fullName = $"{param.FirstName} {param.LastName} Wants to contact.";
            var stringTeamp = "<html>\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n</head>\r\n<body>\r\n    <table bgcolor=\"#fafafa\" style=\" width: 100%!important; height: 100%; background-color: #fafafa; padding: 20px; font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, 'Lucida Grande', sans-serif;  font-size: 100%; line-height: 1.6;\">\r\n        <tr>\r\n            <td></td>\r\n            <td bgcolor=\"#FFFFFF\" style=\"border: 1px solid #eeeeee; background-color: #ffffff; border-radius:5px; display:block!important; max-width:600px!important; margin:0 auto!important; clear:both!important;\">\r\n                <div style=\"padding:20px; max-width:600px; margin:0 auto; display:block;\">\r\n                    <table style=\"width: 100%;\">\r\n                        <tr>\r\n                            <td>\r\n                                <p style=\"text-align: center; display: block;  padding-bottom:20px;  margin-bottom:20px; border-bottom:1px solid #dddddd;\"><img src=\"URLOFYOURLOGO\" /></p>\r\n                                <h1 style=\"font-weight: 200; font-size: 36px; margin: 20px 0 30px 0; color: #333333;\"> Subject : #subject</h1>\r\n                                <h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> First Name : #firstName </h2>\r\n                                <h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> Last Name : #lastName </h2>\r\n\t\t\t\t\t\t\t\t<p style=\"margin-bottom: 10px; font-weight: normal; font-size:16px; color: #333333;\">Phone No: #phone</p>\r\n                                <h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> Email : #email </h2>\r\n                                <h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> Message : #message </h2>\r\n\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t<h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> ip : #ip </h2>\r\n\t\t\t\t\t\t\t\t<h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> city : #city </h2>\r\n\t\t\t\t\t\t\t\t<h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> region : #region </h2>\r\n\t\t\t\t\t\t\t\t<h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> country : #country </h2>\r\n\t\t\t\t\t\t\t\t<h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> loc : #loc </h2>\r\n\t\t\t\t\t\t\t\t<h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> org : #org </h2>\r\n\t\t\t\t\t\t\t\t<h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> postal : #postal </h2>\r\n\t\t\t\t\t\t\t\t<h2 style=\"font-weight: 200; font-size: 16px; margin: 20px 0; color: #333333;\"> timezone : #timezone </h2>\r\n                                <p style=\"text-align: center; display: block; padding-top:20px; font-weight: bold; margin-top:30px; color: #666666; border-top:1px solid #dddddd;\">Tech Creare Software</p>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>";
            stringTeamp = stringTeamp.Replace("#subject", fullName).Replace("#phone", param.ContactNo).Replace("#email", param.Email).Replace("#firstName", param.FirstName).Replace("#lastName", param.LastName).Replace("#message", param.Message)
                .Replace("#ip", param.ipDetail.ip)
                .Replace("#city", param.ipDetail.city)
                .Replace("#region", param.ipDetail.region)
                .Replace("#country", param.ipDetail.country)
                .Replace("#loc", param.ipDetail.loc)
            .Replace("#org", param.ipDetail.org)
            .Replace("#postal", param.ipDetail.postal)
            .Replace("#timezone", param.ipDetail.timezone);

            return stringTeamp;
        }
    }

}
