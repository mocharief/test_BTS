using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_BTS.Models;

namespace TEST_BTS.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            this._context = context;
        }

        // GET: api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserModels>> GetUserItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            //return new string[] { "value1", "value2" };
            return _context.GetAllUser();
        }

        //Get : api/user/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<UserModels>> GetUserItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;
            return _context.GetUser(id);
        }

    }
}
