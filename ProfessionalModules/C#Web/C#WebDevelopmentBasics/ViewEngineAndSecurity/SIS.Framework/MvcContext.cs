﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework
{
    public class MvcContext
    {
        private static MvcContext Instance;

        private MvcContext() { }

        public static MvcContext Get => Instance ?? (Instance = new MvcContext());

        public string RootDirectoryRelativePath => "./";

        public string ResourceFolderName => "Resources";

        public string LayoutViewName => "_Layout";

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }

    }
}
