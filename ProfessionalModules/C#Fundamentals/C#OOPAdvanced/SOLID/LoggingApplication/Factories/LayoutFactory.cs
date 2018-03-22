using LoggingApplication.Contracts;
using LoggingApplication.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingApplication.Factories
{
    class LayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout = null;

            switch (type)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;

                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid layout type.");
            }

            return layout;
        }
    }
}
