using ChushkaWebApp.ViewModels.Orders;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChushkaWebApp.Controllers
{
    public class OrdersController: BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse All()
        {
            var orders = this.Db.Orders
                .Select(o => new OrderViewModel
                {
                    Id = o.Id,
                    OrderedOn = o.OrderedOn.ToString("HH:mm dd/MM/yyyy"),
                    ProductName = o.Product.Name,
                    Username = o.Client.Username
                })
                .ToList();

            var model = new AllOrdersViewModel
            {
                Orders = orders
            };

            return this.View(model);
        }
    }
}
