using System;
using System.Collections.Generic;
using System.Text;

namespace Torshia.Web.ViewModels.Tasks
{
    public class DetailedTaskViewModel: BaseTaskViewModel
    {
        public int Level { get; set; }
        
        public string SectorsAsString { get; set; }
    }
}
