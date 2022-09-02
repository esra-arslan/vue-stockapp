using Microsoft.AspNetCore.Mvc;
using firtApiProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace firtApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        postgresContext db = new postgresContext();
        RetObj ret = new RetObj();


        [HttpGet("GetProducts")]
        public List<product>? GetProducts()
        {
            var res = db.products.OrderByDescending(x => x.id).ToList();
            return res;
        }
        [HttpGet("GetProducts/{id}")]
        public product Get(int id)
        {
            var res = db.products.Where(x => x.id == id).FirstOrDefault();
            return res;
        }
      

        [HttpPost("AddProduct")]
        public string AddProduct( product p)
        {

            string msg = "";
            int existCount = 0;
            existCount = db.products.Where(o => o.productCode == p.productCode).Count();

            if (existCount > 0)
            {
                return "Kod tekrarı veya eksik kod girildi.";
            }
            else
            {
                db.products.Add(p);
                db.SaveChanges();
            }
            return "Ürün başarıyla eklendi.";
        }
        

        [HttpPost("UpdateProduct/{id}")]
        public IActionResult Put(int id, product productModel)
        {

            if (id != productModel.id)
                return BadRequest("Geçersiz Id");

            var pro = db.products.Find(productModel.id);

            if (pro == null)
                return BadRequest("Böyle bir ürün bilgisi bulunamadı!");

            pro.productCode = productModel.productCode;
            pro.productName = productModel.productName;
            pro.stockNumber = productModel.stockNumber;
            pro.purchasePrice = productModel.purchasePrice;
            pro.salePrice = productModel.salePrice;
            pro.kdv = productModel.kdv;
            pro.imgurl = productModel.imgurl;

            db.SaveChanges(); 

            return NoContent();
        }


        [HttpDelete("DeleteProduct/{id}")]
        public int DeleteProduct(int id)
        {
            try
            {
                product pro = db.products.Where(x => x.id == id).FirstOrDefault();
                db.products.Remove(pro);
                db.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                return -1;
            }

        }
        }


    }

