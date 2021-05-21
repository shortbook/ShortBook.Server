using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShortBook.Server.Exceptions;
using ShortBook.Server.Service;
using ShortBook.Server.ViewModel.User;

namespace ShortBook.Server.Controllers
{
    /// <summary>
    /// 用户操作
    /// </summary>
    [Route("api/user")]
    [Authorize]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <example>POST api/user</example>
        [HttpPost]
        public ActionResult Post([FromBody]RegisterModel model)
        {
            try
            {
                _service.Register(model);
                return Ok();
            }
            catch (ShortBookServerException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <example>POST api/user/1</example>
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            try
            {
                var userInfo = _service.GetUserInfo(id);
                return Ok(JsonConvert.ToString(userInfo));
            }
            catch (ShortBookServerException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
