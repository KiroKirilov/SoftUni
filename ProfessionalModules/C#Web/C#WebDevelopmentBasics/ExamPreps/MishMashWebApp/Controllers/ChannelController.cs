using MishMashWebApp.ViewModels.Channel;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MishMashWebApp.Models;
using System;

namespace MishMashWebApp.Controllers
{
    public class ChannelController : BaseController
    {
        [HttpGet("/Channel/Followed")]
        public IHttpResponse Followed()
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                this.Redirect("Users/Login");
            }

            var followedChannels = this.Db.Channels
                .Where(c => c.Followers.Any(f => f.User.Id == user.Id))
                .Select(c => new FollowedChannelViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Type = c.Type.ToString(),
                    Followers = c.Followers.Count()
                })
                .ToArray();

            return this.View("Channel/Followed", followedChannels);
        }

        [HttpGet("/Channel/Details")]
        public IHttpResponse Details(int id)
        {
            var channel = this.Db.Channels
                .Include(e => e.Tags)
                .ThenInclude(t => t.Tag)
                .Include(e => e.Followers)
                .FirstOrDefault(c => c.Id == id);

            if (channel == null)
            {
                this.Redirect("/");
            }

            var model = new DetailedChannelViewModel
            {
                Id = channel.Id,
                Name = channel.Name,
                Description = channel.Description,
                Type = channel.Type.ToString(),
                Followers = channel.Followers.Count,
                TagsAsString = string.Join(", ", channel.Tags.Select(t => t.Tag.Name))
            };

            return this.View("Channel/Details", model);
        }

        [HttpGet("/Channel/Create")]
        public IHttpResponse Create()
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null || user.Role != Role.Admin)
            {
                return this.Redirect("/");
            }

            return this.View("Channel/Create");
        }

        [HttpPost("/Channel/Create")]
        public IHttpResponse Create(ChannelCreationViewModel model)
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null || user.Role != Role.Admin)
            {
                return this.Redirect("/");
            }

            var validChannelType = Enum.TryParse<ChannelType>(model.Type.Trim(), out ChannelType channelType);

            if (!validChannelType)
            {
                return this.Redirect("/");
            }

            var channel = new Channel
            {
                Name = model.Name,
                Description = model.Description,
                Type = channelType
            };

            var tagsArray = model.TagsAsString.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToArray();
            foreach (var tag in tagsArray)
            {
                var dbTag = this.Db.Tags.FirstOrDefault(t => t.Name == tag);

                if (dbTag == null)
                {
                    dbTag = new Tag { Name = tag };
                }

                channel.Tags.Add(new ChannelTag()
                {
                    Tag = dbTag
                });
            }

            this.Db.Channels.Add(channel);
            this.Db.SaveChanges();

            return this.Redirect($"/Channel/Details?id={channel.Id}");
        }

        [HttpGet("/Channel/Unfollow")]
        public IHttpResponse Unfollow(int id)
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect("/");
            }

            var followDetails = this.Db.UsersChannels.FirstOrDefault(uc => uc.UserId == user.Id && uc.ChannelId == id);
            if (followDetails == null)
            {
                return this.Redirect("/");
            }

            this.Db.UsersChannels.Remove(followDetails);
            this.Db.SaveChanges();

            return this.Redirect("/Channel/Followed");
        }

        [HttpGet("/Channel/Follow")]
        public IHttpResponse Follow(int id)
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);
            var channel = this.Db.Channels.FirstOrDefault(c => c.Id == id);

            if (user == null || channel == null)
            {
                return this.Redirect("/");
            }

            var followDetails = this.Db.UsersChannels.FirstOrDefault(uc => uc.UserId == user.Id && uc.ChannelId == id);
            if (followDetails != null)
            {
                return this.Redirect("/");
            }

            this.Db.UsersChannels.Add(new UserChannel
            {
                User = user,
                ChannelId = id
            });
            this.Db.SaveChanges();

            return this.Redirect("/Channel/Followed");
        }
    }
}
