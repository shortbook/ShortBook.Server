using ShortBook.Server.ViewModel.Login;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// Login service interface.
    /// </summary>
    public interface ILoginService : IShortBookService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">用户登录模型</param>
        void Login(LoginModel model);

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="id">用户Id</param>
        void Logout(long id);

        /// <summary>
        /// 修改登录口令
        /// </summary>
        /// <param name="model">修改登录口令模型</param>
        void ChangePassword(ChangePasswordModel model);
    }
}