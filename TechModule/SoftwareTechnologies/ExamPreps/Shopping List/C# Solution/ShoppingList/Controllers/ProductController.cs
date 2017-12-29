using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                var products = db.Products.OrderBy(p=>p.Priority).ToList();
                return View(products);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ShoppingListDbContext())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Redirect("/");
                }
            }
            return View();
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var db = new ShoppingListDbContext())
            {
                var product = db.Products.Find(id);
                if (product != null)
                {
                    return View(product);
                }
            }
            return Redirect("/");
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Product productModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productModel);
            }

            using (var db = new ShoppingListDbContext())
            {
                var prodFromDb = db.Products.Find(productModel.Id);
                if (prodFromDb != null)
                {
                    prodFromDb.Name = productModel.Name;
                    prodFromDb.Quantity = productModel.Quantity;
                    prodFromDb.Priority = productModel.Priority;
                    prodFromDb.Status = productModel.Status;
                    db.SaveChanges();
                }
            }
            return Redirect("/");
        }
    }
}