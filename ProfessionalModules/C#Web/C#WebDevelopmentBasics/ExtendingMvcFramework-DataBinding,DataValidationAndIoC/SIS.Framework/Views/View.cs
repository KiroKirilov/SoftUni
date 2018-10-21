using SIS.Framework.ActionResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;
        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string,object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
        }

        private string ReadFile()
        {
            if (File.Exists(this.fullyQualifiedTemplateName))
            {
                return File.ReadAllText(this.fullyQualifiedTemplateName);
            }

            throw new FileNotFoundException("Could not find the required view.", this.fullyQualifiedTemplateName);
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();
            var renderedHtml = this.RenderHtml(fullHtml);
            return renderedHtml;
        }

        private string RenderHtml(string fullHtml)
        {
            if (this.viewData!=null && this.viewData.Any())
            {
                foreach (var viewDataKey in this.viewData.Keys)
                {
                    var dynamicDataPlaceholder = $"{{{{{{{viewDataKey}}}}}}}";
                    if (fullHtml.Contains(dynamicDataPlaceholder))
                    {
                        fullHtml = fullHtml.Replace(
                            dynamicDataPlaceholder,
                            this.viewData[viewDataKey].ToString());
                    }
                }
            }
            return fullHtml;
        }
    }
}
