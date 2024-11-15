﻿using SIS.Framework.ActionResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullHtmlContent;

        public View(string fullHtmlContent)
        {
            this.fullHtmlContent = fullHtmlContent;
        }

        public string Render() => this.fullHtmlContent;
    }
}
