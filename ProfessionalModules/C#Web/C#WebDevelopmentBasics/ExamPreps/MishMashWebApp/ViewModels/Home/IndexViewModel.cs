using MishMashWebApp.ViewModels.Channel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public bool UserIsAdmin { get; set; }

        public IEnumerable<BaseChannelViewModel> FollowedChannels { get; set; }

        public IEnumerable<BaseChannelViewModel> SuggestedChannels { get; set; }

        public IEnumerable<BaseChannelViewModel> OtherChannels { get; set; }
    }
}
