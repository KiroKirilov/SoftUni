using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.ViewModels.Channel
{
    public class DetailedChannelViewModel: BaseChannelViewModel
    {
        public string Description { get; set; }

        public string TagsAsString { get; set; }
    }
}
