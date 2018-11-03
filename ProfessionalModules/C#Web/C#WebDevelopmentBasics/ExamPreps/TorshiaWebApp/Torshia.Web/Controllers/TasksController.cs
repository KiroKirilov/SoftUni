using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torshia.Web.Common;
using Torshia.Web.ViewModels.Tasks;
using Torshia.Models;
using SIS.Framework.Attributes.Method;
using Torshia.Models.Enums;

namespace Torshia.Web.Controllers
{
    public class TasksController: BaseController
    {
        [Authorize]
        public IActionResult Details(int id)
        {
            var task = this.Db.Tasks.FirstOrDefault(t => t.Id == id);

            if (task==null)
            {
                return this.RedirectToAction("/");
            }

            var model = new DetailedTaskViewModel
            {
                Title = task.Title,
                Description = task.Description,
                Participants = task.Participants,
                DueDate = task.DueDate.ToString(Constants.DateTimeFormat),
                SectorsAsString = string.Join(", ", task.AffectedSectors.Select(s => s.Sector.ToString())),
                Level = task.AffectedSectors.Count
            };

            this.Model["Task"] = model;

            return this.RenderView();
        }

        [Authorize("Admin")]
        public IActionResult Create()
        {
            return this.RenderView();
        }

        [HttpPost]
        [Authorize("Admin")]
        public IActionResult Create(CreateTaskViewModel model)
        {
            var sectorStrings = new string[] { model.Sector1, model.Sector2, model.Sector3, model.Sector4, model.Sector5 }
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

            var task = new Task
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = DateTime.Parse(model.DueDate),
                IsReported = false,
                Participants = model.Participants
            };

            foreach (var sectorStr in sectorStrings)
            {
                var validSector = Enum.TryParse<Sector>(sectorStr, out Sector sector);
                if (validSector)
                {
                    task.AffectedSectors.Add(new TaskSector { Sector = sector });
                }
            }

            this.Db.Tasks.Add(task);
            this.Db.SaveChanges();

            return this.RedirectToAction($"/Tasks/Details?id={task.Id}");
        }

        [Authorize]
        public IActionResult Report(int id)
        {
            var task = this.Db.Tasks.FirstOrDefault(t => t.Id == id);
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.Identity.Username);
            
            if (task==null || user==null)
            {
                return this.RedirectToAction("/");
            }

            if (this.Db.Reports.Any(r => r.TaskId == task.Id))
            {
                return this.RedirectToAction("/");
            }

            task.IsReported = true;
            var status = Status.Completed;

            var randomNumber = new Random().Next(1, 101);
            if (randomNumber>75)
            {
                status = Status.Archived;
            }

            var report = new Report
            {
                TaskId = task.Id,
                ReporterId = user.Id,
                ReportedOn = DateTime.UtcNow,
                Status = status
            };

            this.Db.Reports.Add(report);
            this.Db.SaveChanges();

            return this.RedirectToAction("/");
        }
    }
}
