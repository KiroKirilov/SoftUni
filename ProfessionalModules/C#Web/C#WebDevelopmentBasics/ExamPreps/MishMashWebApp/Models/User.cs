using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.Models
{
    public class User
    {
        public User()
        {
            this.FollowedChannels = new List<UserChannel>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<UserChannel> FollowedChannels { get; set; }
    }
}
