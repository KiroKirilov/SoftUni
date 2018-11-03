using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;
using SIS.Framework.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Torshia.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var username = string.Empty;
            var html = string.Empty;
            if (this.Identity!=null)
            {
                var usernamePrefix = this.Identity.Roles.Contains("Admin") ? "Admin-" : string.Empty;
                username = usernamePrefix + this.Identity.Username;

                html = this.GenerateTasksHtml();
            }

            this.Model["Username"] = username;
            this.Model["Tasks"] = html;

            return this.RenderView();
        }

        private string GenerateTasksHtml()
        {
            var allTasks = this.Db.Tasks.Where(t => !t.IsReported).ToList();

            var html = new StringBuilder();
            html.AppendLine(@"<div class=""tasks-row row mb-5"">");

            for (int i = 0; i < allTasks.Count; i++)
            {
                if (i % 5 == 0 && i > 0)
                {
                    html.AppendLine("</div>");
                    html.AppendLine(@"<div class=""tasks-row row mb-5"">");
                }
                var task = allTasks[i];
                html.AppendLine(@"<div class=""task col mx-3 bg-torshia rounded py-3"">");

                html.AppendLine($@"<h6 class=""task-title text-white text-center my-3"">{task.Title}</h6>");
                html.AppendLine(@"<hr class=""bg-white hr-2 w-75"">");
                html.AppendLine($@"<h6 class=""task-title text-white text-center my-4"">Level: {task.AffectedSectors.Count}</h6>");
                html.AppendLine(@"<hr class=""bg-white h-2 w-75"">");

                html.AppendLine(@"<div class=""follow-button-holder d-flex justify-content-between w-50 mx-auto mt-4"">");
                html.AppendLine($@"<a href = ""Tasks/Report?id={task.Id}"" ><h6 class=""text-center text-white"">Report</h6></a>");
                html.AppendLine($@"<a href = ""Tasks/Details?id={task.Id}"" ><h6 class=""text-center text-white"">Details</h6></a>");
                html.AppendLine("</div>");

                html.AppendLine("</div>");
            }

            var emptyTasksToAdd = 5 - (allTasks.Count % 5);

            for (int i = 0; i < emptyTasksToAdd; i++)
            {
                html.AppendLine(@"<div class=""task col mx-3 bg-white rounded py-3""></div>");
            }

            html.AppendLine("</div>");

            return html.ToString();
        }
    }
}
