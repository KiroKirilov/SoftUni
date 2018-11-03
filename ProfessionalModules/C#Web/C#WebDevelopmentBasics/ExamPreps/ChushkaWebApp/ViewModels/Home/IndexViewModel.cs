using ChushkaWebApp.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChushkaWebApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public IList<IndexProductViewModel> Products { get; set; }
    }
}
