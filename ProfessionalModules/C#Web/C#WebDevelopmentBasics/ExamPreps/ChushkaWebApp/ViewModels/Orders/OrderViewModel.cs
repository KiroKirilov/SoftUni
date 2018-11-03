using System;
using System.Collections.Generic;
using System.Text;

namespace ChushkaWebApp.ViewModels.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string ProductName { get; set; }

        public string OrderedOn { get; set; }
    }
}
