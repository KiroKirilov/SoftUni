using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.ViewModels.Channel
{
    public class ChannelCreationViewModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string TagsAsString { get; set; }
    }
}
