using Microsoft.AspNetCore.Mvc;
using ShortBook.Server.Exception;
using ShortBook.Server.Service;
using ShortBook.Server.ViewModel;

namespace ShortBook.Server.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service"></param>
        public LoginController(ILoginService service)
        {
            _service = service;
            _service.Context = HttpContext;
        }

        /// <summary>
        /// Login by username and password.
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public ActionResult Post([FromBody]UserLoginModel model)
        {
            try
            {
                return Ok(_service.Login(model));
            }
            catch (ShortBookServerException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Change login password.
        /// </summary>
        /// <param name="model"></param>
        [HttpPut]
        public ActionResult Put([FromBody]ChangePasswordModel model)
        {
            _service.ChangePassword(model);
            return Ok();
        }
    }
}