using ChushkaWebApp.Models;
using ChushkaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChushkaWebApp.Controllers
{
    public class ProductsController: BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == id);

            if (product==null)
            {
                return this.BadRequestError("Product not found");
            }

            var model = new DetailedProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = Math.Round(product.Price, 2),
                Description = product.Description,
                Type = product.Type.ToString()
            };

            return this.View<DetailedProductViewModel>(model);
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(DetailedProductViewModel model)
        {
            if (model==null)
            {
                return this.BadRequestErrorWithView("Please fill out the form.");
            }

            var parseResult = Enum.TryParse<Models.Type>(model.Type, out Models.Type type);

            if (!parseResult)
            {
                return this.BadRequestErrorWithView("Invalid product type");
            }

            var product = new Product
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                Type = type
            };

            this.Db.Products.Add(product);
            this.Db.SaveChanges();

            return this.Redirect($"/Products/Details?id={product.Id}");
        }

        [Authorize("Admin")]
        public IHttpResponse Edit(int id)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Product not found");
            }

            var model = new DetailedProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = Math.Round(product.Price, 2),
                Description = product.Description,
                Type = product.Type.ToString()
            };

            return this.View<DetailedProductViewModel>(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Edit(DetailedProductViewModel model)
        {
            if (model==null)
            {
                return this.BadRequestErrorWithView("Please fill out the form");
            }

            var product = this.Db.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return this.BadRequestError("Product not found");
            }

            var parseResult = Enum.TryParse<Models.Type>(model.Type, out Models.Type type);

            if (!parseResult)
            {
                return this.BadRequestErrorWithView("Invalid product type");
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Type = type;
            product.Price = model.Price;
            this.Db.SaveChanges();

            return this.Redirect($"/Products/Details?id={model.Id}");
        }

        [Authorize("Admin")]
        public IHttpResponse Delete(int id)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Product not found");
            }

            var model = new DetailedProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = Math.Round(product.Price, 2),
                Description = product.Description,
                Type = product.Type.ToString()
            };

            return this.View<DetailedProductViewModel>(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Delete(DetailedProductViewModel model)
        {
            if (model == null)
            {
                return this.BadRequestErrorWithView("Please fill out the form");
            }

            var product = this.Db.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return this.BadRequestError("Product not found");
            }

            this.Db.Products.Remove(product);
            this.Db.SaveChanges();

            return this.Redirect($"/");
        }

        [Authorize]
        public IHttpResponse Order(int id)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (user == null)
            {
                return this.BadRequestError("Invalid user.");
            }

            var order = new Order
            {
                OrderedOn = DateTime.UtcNow,
                ProductId = id,
                ClientId = user.Id,
            };

            this.Db.Orders.Add(order);
            this.Db.SaveChanges();

            return this.Redirect("/");
        }
    }
}
