using Microsoft.AspNetCore.Mvc;
using ShortBook.Server.Service;
using ShortBook.Server.ViewModel;

namespace ShortBook.Server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service"></param>
        public UserController(IUserService service)
        {
            _service = service;
            _service.Context = HttpContext;
        }

        // POST api/user
        [HttpPost(Name = "user")]
        public JsonResult Register([FromBody]UserRegisterModel user)
        {
            return new JsonResult(_service.Register(user));
        }

        //// POST api/login
        //[HttpPost(Name = "login")]
        //public JsonResult Login([FromBody]UserLoginModel user)
        //{
        //    return new JsonResult(_service.Login(user));
        //}

        // PUT api/user/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]UserModifyModel user)
        {
            user.Id = id;
            return new JsonResult(_service.Modify(user));
        }
    }
}
