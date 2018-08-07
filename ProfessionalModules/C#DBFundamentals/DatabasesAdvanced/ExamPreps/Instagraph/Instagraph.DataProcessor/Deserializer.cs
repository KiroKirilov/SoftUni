using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.Models;
using Instagraph.DataProcessor.Dtos;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMsg = "Error: Invalid data.";
        private const string SuccessMsg = "Successfully imported {0}.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var deserializedPictures = JsonConvert.DeserializeObject<Picture[]>(jsonString);
            var sb = new StringBuilder();

            var pictures = new List<Picture>();

            foreach (var pic in deserializedPictures)
            {
                var isValid = !string.IsNullOrWhiteSpace(pic.Path) &&
                    pic.Size > 0;

                if (!isValid)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var picExists = pictures.Any(p => p.Path == pic.Path);

                if (picExists)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                pictures.Add(pic);
                sb.AppendLine(string.Format(SuccessMsg, $"Picture {pic.Path}"));
            }

            context.Pictures.AddRange(pictures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var deserializedData = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            var users = new List<User>();

            var sb = new StringBuilder();

            foreach (var dto in deserializedData)
            {
                var isValid = !string.IsNullOrWhiteSpace(dto.Username) &&
                    !string.IsNullOrWhiteSpace(dto.Password) &&
                    !string.IsNullOrWhiteSpace(dto.ProfilePicture) &&
                    dto.Username.Length <= 30 &&
                    dto.Password.Length <= 20;

                if (!isValid)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var userExists = users.Any(u => u.Username == dto.Username);
                var pictureId = context.Pictures.FirstOrDefault(p => p.Path == dto.ProfilePicture)?.Id;

                if (userExists || pictureId == null)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var user = new User()
                {
                    Username = dto.Username,
                    Password = dto.Password,
                    ProfilePictureId = pictureId.Value
                };

                users.Add(user);
                sb.AppendLine(string.Format(SuccessMsg, $"User {dto.Username}"));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var deserializedData = JsonConvert.DeserializeObject<UserFollowerDto[]>(jsonString);

            var usersFollowers = new List<UserFollower>();

            var sb = new StringBuilder();

            foreach (var dto in deserializedData)
            {
                int? userId = context.Users.FirstOrDefault(u=>u.Username==dto.User)?.Id;
                int? followerId = context.Users.FirstOrDefault(u=>u.Username==dto.Follower)?.Id;                

                if (userId==null||followerId==null)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var alreadyFollowed = usersFollowers.Any(uf => uf.UserId == userId.Value && uf.FollowerId == followerId.Value);

                if (alreadyFollowed)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var userFollower = new UserFollower()
                {
                    UserId = userId.Value,
                    FollowerId = followerId.Value
                };

                usersFollowers.Add(userFollower);
                sb.AppendLine(string.Format(SuccessMsg,$"Follower {dto.Follower} to User {dto.User}"));
            }

            context.UsersFollowers.AddRange(usersFollowers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            var sb = new StringBuilder();

            var posts = new List<Post>();

            foreach (var element in elements)
            {
                string caption = element.Element("caption")?.Value;
                string user = element.Element("user")?.Value;
                string picture = element.Element("picture")?.Value;

                var userId = context.Users.FirstOrDefault(u=>u.Username==user)?.Id;
                var pictureId = context.Pictures.FirstOrDefault(p=>p.Path==picture)?.Id;

                if (userId == null || pictureId==null || string.IsNullOrWhiteSpace(caption))
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var post = new Post()
                {
                    UserId = userId.Value,
                    PictureId = pictureId.Value,
                    Caption = caption
                };

                posts.Add(post);
                sb.AppendLine(string.Format(SuccessMsg,$"Post {caption}"));
            }

            context.Posts.AddRange(posts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            var sb = new StringBuilder();

            var comments = new List<Comment>();

            foreach (var element in elements)
            {
                var content = element.Element("content")?.Value;
                var user = element.Element("user")?.Value;
                var postIdString = element.Element("post")?.Attribute("id")?.Value;
                
                if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(postIdString))
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var postId = int.Parse(postIdString);
                var userId = context.Users.FirstOrDefault(u => u.Username == user)?.Id;
                var postExists = context.Posts.Any(p => p.Id == postId);

                if (userId==null || !postExists)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var comment = new Comment()
                {
                    UserId = userId.Value,
                    PostId = postId,
                    Content = content
                };

                comments.Add(comment);
                sb.AppendLine(string.Format(SuccessMsg, $"Comment {content}"));
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }
    }
}
