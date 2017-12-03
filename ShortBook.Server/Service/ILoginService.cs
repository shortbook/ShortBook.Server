using ShortBook.Server.ViewModel;
using ShortBook.Server.ViewModel.User;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// Login service interface.
    /// </summary>
    public interface ILoginService : IShortBookService
    {
        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserInfoModel Login(LoginModel model);

        /// <summary>
        /// Change password.
        /// </summary>
        /// <param name="model"></param>
        void ChangePassword(ChangePasswordModel model);
    }
}