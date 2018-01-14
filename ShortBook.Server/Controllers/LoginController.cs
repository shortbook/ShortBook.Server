using System;
using Microsoft.AspNetCore.Mvc;
using ShortBook.Server.Exceptions;
using ShortBook.Server.Service;
using ShortBook.Server.ViewModel.User;

namespace ShortBook.Server.Controllers
{
    /// <summary>
    /// 登录操作
    /// </summary>
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IUserService _service;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service"></param>
        public LoginController(IUserService service)
        {
            _service = service;
            _service.Context = HttpContext;
        }

        /// <summary>
        /// Login by username and password.
        /// </summary>
        /// <param name="model"></param>
        /// <example>POST /api/login</example>
        [HttpPost]
        public ActionResult Post([FromBody]LoginModel model)
        {
            try
            {
                _service.Login(model);
                return Ok();
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
        /// <example>PUT /api/login</example>
        [HttpPut]
        public ActionResult Put([FromBody]ChangePasswordModel model)
        {
            try
            {
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