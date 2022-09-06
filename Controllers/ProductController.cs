using freshMart.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace freshMart.Controllers
{
    public class ProductController : Controller
    {
        FreshMartEntities1 db = new FreshMartEntities1();
        // GET: Product
        public ActionResult Proudct(tbl_product obj)
        {
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddProudct(tbl_product model)
        {
            tbl_product obj = new tbl_product();
            if (ModelState.IsValid)
            {
                /*
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.product_image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                model.ImageFile.SaveAs(fileName);*/
;


                obj.product_id = model.product_id;
                obj.product_name = model.product_name;
                obj.product_image = model.product_image;
                obj.product_description = model.product_description;
                obj.product_price = model.product_price;

                
                if(model.product_id ==0)
                {
                    db.tbl_product.Add(obj);
                    db.SaveChanges();

                }
                else
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
            }
            ModelState.Clear();



            return View("Proudct");
        }

        public ActionResult ProductList()
        {
            var res = db.tbl_product.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            //var res = db.tbl_product.Where(x => x.product_id == id).First();
            //db.tbl_product.Remove(res);
            //db.SaveChanges();

            //var list = db.tbl_product.ToList();

            if(id>0)
            {
                var productIdRow = db.tbl_product.Where(model => model.product_id == id).FirstOrDefault();
                if(productIdRow!=null)
                {
                    db.Entry(productIdRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if(a>0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted!!')</script>";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Deleted!!')</script>";
                    }
                }
            }

            return RedirectToAction("Productlist");
        }
    }
}