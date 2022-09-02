using firtApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace firtApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HamperController : Controller
    {
        postgresContext db = new postgresContext();

        [HttpGet("GetHamper")]
        public IActionResult GetHamper(decimal? Total, user user)
        {
            if (User.Identity.IsAuthenticated)
            {
                var Email = User.Identity.Name;
                var kullanıcı = db.users.FirstOrDefault(x => x.email == Email);
                var model = db.hampers.Where(x => x.userId == user.id).ToList();
                var uId = db.hampers.FirstOrDefault(x => x.userId == user.id);
                if (model != null)
                {
                    if (uId == null)
                    {
                        ViewBag.Total = "Sepetinizde ürün bulunmuyor";
                    }
                    else if (uId != null)
                    {
                        Total = db.hampers.Where(x => x.userId == uId.id).Sum(x => x.totalPrice * x.number);
                        ViewBag.Total = "Toplam Tutar =" + Total + "TL";

                    }
                    return View(model);
                }
            }
            return View();
        }

      

        [HttpGet("AddHamper")]

        public ActionResult AddHamper(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
            var Email = User.Identity.Name;

                var model = db.users.FirstOrDefault(x => x.email == Email);
                var p = db.products.Find(id);
                var hamper = db.hampers.FirstOrDefault(x => x.userId == model.id && x.productId == id);
                if (model != null)
                {
                    if (hamper != null)
                    {
                        hamper.number++;
                        hamper.totalPrice = (decimal)(p.salePrice * hamper.number);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    var h = new hamper
                    {
                        userId = model.id,
                        productId = p.id,
                        number = 1,
                        price = (int)p.salePrice,
                        totalPrice = p.salePrice,
                    };
                    db.hampers.Add(h);
                   //b.Entry(h).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NoContent();
        }




    }
}
