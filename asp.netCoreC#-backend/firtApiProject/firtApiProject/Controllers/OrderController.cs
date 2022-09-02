using Microsoft.AspNetCore.Mvc;
using firtApiProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace firtApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        postgresContext db = new postgresContext();


        [HttpGet("GetOrders")]
        public List<order>? GetOrders()
        {
            var res = db.orders.ToList();
            return res;
        }

    }
}
