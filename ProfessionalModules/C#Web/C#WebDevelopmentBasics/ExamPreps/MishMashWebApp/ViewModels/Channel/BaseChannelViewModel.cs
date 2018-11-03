using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.ViewModels.Channel
{
    public class BaseChannelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Followers { get; set; }
    }
}
