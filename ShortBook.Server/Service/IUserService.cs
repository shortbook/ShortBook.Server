using ShortBook.Server.ViewModel.User;

namespace ShortBook.Server.Service
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService : IShortBookService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">用户注册模型</param>
        void Register(RegisterModel model);

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