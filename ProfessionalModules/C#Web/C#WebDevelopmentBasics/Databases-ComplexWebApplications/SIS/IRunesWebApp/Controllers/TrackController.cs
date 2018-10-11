namespace IRunesWebApp.Controllers
{
    using IRunesWebApp.Models;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Net;
    using System.Linq;
    using IRunesWebApp.Constants;

    public class TrackController : BaseController
    {

        private const string Id = "id";
        private const string Name = "name";
        private const string AlbumId = "albumId";
        private const string Link = "link";
        private const string Price = "price";

        public IHttpResponse Create(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult(GlobalConstants.LoginRoot);
            }

            var albumId = request.QuerryData[AlbumId].ToString();
            this.Authenticated = true;
            this.ViewBag[Id] = albumId;
            return this.View();
        }

        public IHttpResponse DoCreate(IHttpRequest request)
        {
            var albumId = request.QuerryData[AlbumId].ToString();
            var name = this.GetFormData(request, Name).Trim();
            var link = this.GetFormData(request, Link).Trim();
            var price = this.GetFormData(request, Price).Trim();

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(link) ||
                string.IsNullOrEmpty(price))
            {
                return this.View(GlobalConstants.CreateView);
            }

            var trackAlbum = new TrackAlbum
            {
                AlbumId = albumId,
                Track = new Track
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = WebUtility.UrlDecode(name),
                    Link = WebUtility.UrlDecode(link),
                    Price = decimal.Parse(price)
                }
            };


            Db.TracksAlbums.Add(trackAlbum);
            Db.SaveChanges();
            this.ViewBag[Id] = albumId;

            return View(GlobalConstants.CreateView);
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult(GlobalConstants.LoginRoot);
            }
            this.Authenticated = true;

            var trackId = request.QuerryData["trackId"].ToString();

            var track = Db.Tracks
                .Where(t => t.Id == trackId)
                .Select(tr => new
                {
                    Link = tr.Link,
                    Name = tr.Name,
                    Price = tr.Price,
                    Albums = tr.Albums.Select(t => new
                    {
                        Id = t.AlbumId
                    }).FirstOrDefault()
                }).FirstOrDefault();

            this.ViewBag[Link] = track.Link;
            this.ViewBag[Name] = track.Name;
            this.ViewBag[Price] = track.Price.ToString("F2");
            this.ViewBag[Id] = track.Albums.Id;

            return this.View();
        }

    }
}
