using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Instagraph.Data;
using Instagraph.DataProcessor.Dtos;
using Newtonsoft.Json;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .Select(p => new
                {
                    Id = p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                })
                .OrderBy(p => p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(posts, Formatting.Indented);
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers
                            .Any(f => f.FollowerId == c.UserId))))
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    Username = u.Username,
                    Followers = u.Followers.Count
                })
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new
                {
                    Username = u.Username,
                    CommentsCount = u.Posts.Select(p => p.Comments.Count).ToArray()
                })
                .ToArray();

            var userDtos = new List<UserMostCommentsDto>();

            foreach (var u in users)
            {
                var mostComments = 0;

                if (u.CommentsCount.Any())
                {
                    mostComments = u.CommentsCount.OrderByDescending(x => x).First();
                }

                var userDto = new UserMostCommentsDto()
                {
                    Username = u.Username,
                    MostComments = mostComments
                };

                userDtos.Add(userDto);
            }

            var xDoc = new XDocument(new XElement("users"));

            foreach (var user in userDtos.OrderByDescending(u=>u.MostComments).ThenBy(u=>u.Username))
            {
                xDoc.Root.Add(new XElement("user",
                    new XElement("Username", user.Username),
                    new XElement("MostComments", user.MostComments)));
            }

            return xDoc.ToString();
        }
    }
}
