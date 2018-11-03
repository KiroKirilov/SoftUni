using ChushkaWebApp.ViewModels.Home;
using ChushkaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChushkaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var model = new IndexViewModel();
            if (this.User.IsLoggedIn)
            {
                model.Products = this.Db.Products
                    .Select(p => new IndexProductViewModel
                    {
                        Id = p.Id,
                        Description = p.Description,
                        Name = p.Name,
                        Price =Math.Round(p.Price, 2)
                    }).ToList();
            }

            return this.View<IndexViewModel>(model);
        }

        private string GenerateProductsHtml()
        {
            var allProducts = this.Db.Products.ToList();

            var html = new StringBuilder();
            html.AppendLine(@"<div class=""row d-flex justify-content-around"">");

            for (int i = 0; i < allProducts.Count; i++)
            {
                if (i % 5 == 0 && i > 0)
                {
                    html.AppendLine("</div>");
                    html.AppendLine(@"<div class=""row d-flex justify-content-around"">");
                }
                var product = allProducts[i];
                html.AppendLine($@"<a href=""/Products/Details?id={product.Id}"" class=""col-md-2 mb-5"">");

                html.AppendLine(@"<div class=""product p-1 chushka-bg-color rounded-top rounded-bottom"">");

                html.AppendLine($@"<h5 class=""text-center mt-3"">{product.Name}</h5>");
                html.AppendLine(@"<hr class=""hr-1 bg-white""/>");
                html.AppendLine($@"<p class=""text-white text-center"">{this.GetProductSummary(product.Description)}</p>");
                html.AppendLine(@"<hr class=""hr-1 bg-white""/>");
                html.AppendLine($@"<h6 class=""text-center text-white mb-3"">${product.Price:f2}</h6>");

                html.AppendLine("</div>");

                html.AppendLine("</a>");
            }

            html.AppendLine("</div>");

            return html.ToString();
        }

        private string GetProductSummary(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return string.Empty;
            }

            if (description.Length <= 50)
            {
                return description;
            }

            return description.Substring(0, 50) + "...";
        }
    }
}
