using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortBook.Server.Exceptions;
using ShortBook.Server.Service;
using ShortBook.Server.ViewModel.Login;

namespace ShortBook.Server.Controllers
{
    /// <summary>
    /// 登录操作
    /// </summary>
    [Route("api/login")]
    [Authorize]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public LoginController(ILoginService service, ILogger<LoginController> logger)
        {
            _service = service;
            _service.Logger = logger;
        }

        /// <summary>
        /// Login by username and password.
        /// </summary>
        /// <param name="model"></param>
        /// <example>POST /api/login</example>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post(LoginModel model)
        {
            try
            {
                _service.Context = HttpContext;
                _service.Login(model);
                return Ok();
            }
            catch (ShortBookServerException e)
            {
                return e.Catch();
            }
        }

        /// <summary>
        /// Change login password.
        /// </summary>
        /// <param name="model"></param>
        /// <example>PUT /api/login</example>
        [HttpPut]
        public ActionResult Put([FromBody]ChangePasswordModel model)
        {
            try
            {
                _service.Context = HttpContext;
                _service.ChangePassword(model);
                return Ok();
            }
            catch (Exception e)
            {
                return e.Catch();
            }
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <example>DELETE /api/login/1</example>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _service.Context = HttpContext;
                _service.Logout(id);
                return Ok();
            }
            catch (ShortBookServerException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}