using System;
using System.Collections.Generic;
using System.Text;

namespace Torshia.Web.ViewModels.Tasks
{
    public class BaseTaskViewModel
    {
        public string Title { get; set; }
        
        public string DueDate { get; set; }

        public string Participants { get; set; }
        
        public string Description { get; set; }
    }
}
