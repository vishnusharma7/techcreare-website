using Microsoft.AspNetCore.DataProtection;
using TechCreare.Repository;

namespace TechCreare.Services
{
    public class CipherService:ICipherService
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string Key = "ILoveCreare";

        public CipherService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public string Encrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }

        public string Decrypt(string cipherText)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(cipherText);
        }
    }
}
