using Microsoft.AspNetCore.Mvc;
using firtApiProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace firtApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        postgresContext db = new postgresContext();
        RetObj ret = new RetObj(); 
     

        [HttpGet("GetUsers")]
        public List<user>? GetUsers()
        {
            var res = db.users.ToList();
            return res; 
        }
        
        [HttpPost("Register")]
        public string Register(user u)
        {

            string msg = "";
            int existCount = 0;
            existCount = db.users.Where(o => o.email == u.email).Count();

            if (existCount > 0)
            {
                return "Email daha önce kayıt edildi.";
            }
            else
            {
                db.users.Add(u);
                db.SaveChanges();
            }

            return "Kullanıcı Kaydı Başarılı";

        }
       

        [HttpGet("Login")]
        public string Login(string email, string password)
        {
            
            var existCount = db.users.Where(o => o.email == email && o.password == password).Count();
            ret.data = existCount;
            ret.result = existCount == 1 ? true : false;


            var res = JObject.Parse(JsonConvert.SerializeObject(ret).ToString()).ToString();
            return res;
        }

        [HttpPut("UpdateUser")]
        public user Updateuser(user u)
        {
            return u;
        }

        //[HttpDelete("DeleteUser")]
        //public List<user> DeleteUser(user u)
        //{
        //    return users.list;
        //}



    }
}
