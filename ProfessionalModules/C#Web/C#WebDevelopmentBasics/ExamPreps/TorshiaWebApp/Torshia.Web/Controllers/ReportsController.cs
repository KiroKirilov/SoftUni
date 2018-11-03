using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torshia.Web.Common;
using Torshia.Web.ViewModels.Reports;

namespace Torshia.Web.Controllers
{
    public class ReportsController : BaseController
    {
        [Authorize("Admin")]
        public IActionResult All()
        {
            var reportNumber = 1;
            var models = new List<ReportViewModel>();
            foreach (var report in this.Db.Reports.ToList())
            {
                var currentModel = new ReportViewModel
                {
                    Id = report.Id,
                    Number = reportNumber++,
                    Title = report.Task.Title,
                    Status = report.Status.ToString(),
                    Level = report.Task.AffectedSectors.Count
                };

                models.Add(currentModel);
            }

            this.Model["Reports"] = models;

            return this.RenderView();
        }

        [Authorize("Admin")]
        public IActionResult Details(int id)
        {
            var report = this.Db.Reports.FirstOrDefault(r => r.Id == id);

            if (report == null)
            {
                return this.RedirectToAction("/");
            }

            var model = new DetailedReportViewModel
            {
                Id = report.Id,
                Title = report.Task.Title,
                Description = report.Task.Description,
                DueDate = report.Task.DueDate.ToString(Constants.DateTimeFormat),
                Level = report.Task.AffectedSectors.Count,
                Participants = report.Task.Participants,
                ReportedOn = report.ReportedOn.ToString(Constants.DateTimeFormat),
                Reporter = report.Reporter.Username,
                Sectors = string.Join(", ", report.Task.AffectedSectors.Select(s => s.Sector.ToString())),
                Status = report.Status.ToString()
            };

            this.Model["Report"] = model;

            return this.RenderView();
        }
    }
}
