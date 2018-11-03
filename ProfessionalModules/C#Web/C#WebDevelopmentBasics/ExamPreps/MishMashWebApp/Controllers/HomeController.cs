using MishMashWebApp.Models;
using MishMashWebApp.ViewModels;
using MishMashWebApp.ViewModels.Channel;
using MishMashWebApp.ViewModels.Home;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MishMashWebApp.Controllers
{
    public class HomeController:BaseController
    {
        [HttpGet("/")]
        public IHttpResponse Index()
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);
            
            if (user == null)
            {
                return this.View("Home/IndexGuest");
            }


            var followedChannels = this.Db.Channels
                .Where(c => user.FollowedChannels.Any(fc => fc.ChannelId == c.Id))
                .Select(c => new BaseChannelViewModel
                {
                     Id=c.Id,
                     Name=c.Name,
                     Followers=c.Followers.Count,
                     Type=c.Type.ToString()
                })
                .ToList();

            var userTags = this.Db.Channels
                .Where(c => user.FollowedChannels.Any(fc => fc.ChannelId == c.Id))
                .SelectMany(c => c.Tags.Select(t => t.Tag.Name))
                .ToList();

            var suggestedChannels=this.Db.Channels
                .Where(c => c.Tags.Any(t => userTags.Contains(t.Tag.Name)) && !followedChannels.Any(fc => fc.Id==c.Id))
                .Select(c => new BaseChannelViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Followers = c.Followers.Count,
                    Type = c.Type.ToString()
                })
                .ToList();

            var otherChannels=this.Db.Channels
                .Where(c => !followedChannels.Any(fc => fc.Id==c.Id) && !suggestedChannels.Any(sc => sc.Id==c.Id))
                .Select(c => new BaseChannelViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Followers = c.Followers.Count,
                    Type = c.Type.ToString()
                })
                .ToList();

            var model = new IndexViewModel
            {
                FollowedChannels = followedChannels,
                SuggestedChannels = suggestedChannels,
                OtherChannels = otherChannels,
                UserIsAdmin=user.Role==Role.Admin
            };

            return this.View("Home/Index", model);
        }

        [HttpGet("/Home/Index")]
        public IHttpResponse IndexAlt()
        {
            return this.Index();
        }
    }
}
