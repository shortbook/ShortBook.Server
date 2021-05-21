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
        /// 查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserInfoModel GetUserInfo(long id);
    }
}