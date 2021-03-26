using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_BTS.Models;

namespace TEST_BTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private ShoppingContext _context;

        public ShoppingController(ShoppingContext context)
        {
            this._context = context;
        }
        // GET: api/shopping
        [HttpGet]
        public ActionResult<IEnumerable<ShoppingModels>> GetShoppingItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            //return new string[] { "value1", "value2" };
            return _context.GetAllShopping();
        }

        //Get : api/shopping/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<ShoppingModels>> GetShoppingItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(ShoppingContext)) as ShoppingContext;
            return _context.GetShopping(id);
        }
    }
}
