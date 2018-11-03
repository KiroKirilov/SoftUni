using System;
using System.Collections.Generic;
using System.Text;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class Report
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int ReporterId { get; set; }
        public virtual User Reporter { get; set; }
    }
}
