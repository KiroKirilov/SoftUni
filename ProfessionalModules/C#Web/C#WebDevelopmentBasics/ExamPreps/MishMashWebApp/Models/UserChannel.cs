﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashWebApp.Models
{
    public class UserChannel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ChannelId { get; set; }
        public virtual Channel Channel { get; set; }
    }
}
