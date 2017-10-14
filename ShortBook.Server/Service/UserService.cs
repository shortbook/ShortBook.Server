using System;
using System.Security.Cryptography;
using System.Text;
using ShortBook.Server.ViewModel;

namespace ShortBook.Server.Service
{
    public class UserService : ShortBookServiceBase
    {
        public ServiceResult Login(UserLoginModel user)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Modify(UserModifyModel user)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Register(UserRegisterModel user)
        {
            throw new NotImplementedException();
        }

        private string GetMd5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
    }
}