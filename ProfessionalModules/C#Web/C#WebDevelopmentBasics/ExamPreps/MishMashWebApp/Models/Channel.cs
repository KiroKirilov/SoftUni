using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.Models
{
    public class Channel
    {
        public Channel()
        {
            this.Tags = new List<ChannelTag>();
            this.Followers = new List<UserChannel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType Type { get; set; }

        public virtual ICollection<ChannelTag> Tags { get; set; }

        public virtual ICollection<UserChannel> Followers { get; set; }
    }
}
