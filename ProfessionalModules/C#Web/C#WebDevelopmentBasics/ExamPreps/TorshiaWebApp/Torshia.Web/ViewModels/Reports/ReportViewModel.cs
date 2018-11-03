using System;
using System.Collections.Generic;
using System.Text;

namespace Torshia.Web.ViewModels.Reports
{
    public class ReportViewModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Title { get; set; }

        public int Level { get; set; }

        public string Status { get; set; }
    }
}
