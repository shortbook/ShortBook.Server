using ShortBook.Server.Domain.User;
using ShortBook.Server.ViewModel;

namespace ShortBook.Server.Service
{
    public interface IUserService
    {
        ServiceResult Register(UserRegisterModel user);

        ServiceResult Login(UserLoginModel user);

        ServiceResult Modify(UserModifyModel user);
    }
}