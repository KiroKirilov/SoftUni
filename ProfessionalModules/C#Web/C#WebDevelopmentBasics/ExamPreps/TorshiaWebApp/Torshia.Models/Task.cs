using System;
using System.Collections.Generic;
using System.Text;

namespace Torshia.Models
{
    public class Task
    {
        public Task()
        {
            this.AffectedSectors = new List<TaskSector>();
            this.Reports = new List<Report>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public virtual ICollection<TaskSector> AffectedSectors { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
