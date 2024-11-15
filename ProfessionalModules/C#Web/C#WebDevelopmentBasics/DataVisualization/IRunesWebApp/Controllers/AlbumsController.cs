﻿namespace IRunesWebApp.Controllers
{
    using IRunesWebApp.Constants;
    using IRunesWebApp.Models;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Linq;
    using System.Net;

    public class AlbumsController : BaseController
    {
        private const string AlbumList = "albumsList";

        public IHttpResponse All(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult(GlobalConstants.LoginRoot);
            }
            this.Authenticated = true;

            var albums = this.Db.Albums;
            var listOfAlbums = string.Empty;

            if (albums.Any())
            {
                foreach (var album in albums)
                {
                    var albumHtml = $@"<div><a href=""/Albums/Details/?id={album.Id}"">{album.Name}</a></div>";
                    listOfAlbums += albumHtml;
                }
                this.ViewBag[AlbumList] = listOfAlbums;
            }
            else
            {
                this.ViewBag[AlbumList] = "There are currently no albums";
            }

            return this.View();
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult(GlobalConstants.LoginRoot);
            }

            this.Authenticated = true;
            return this.View();
        }

        public IHttpResponse DoCreate(IHttpRequest request)
        {
            var name = this.GetFormData(request, "name").Trim();
            var cover = this.GetFormData(request, "cover").Trim();

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(cover))
            {
                return this.View(GlobalConstants.CreateView);
            }

            var album = new Album
            {
                Id = Guid.NewGuid().ToString(),
                Name = WebUtility.UrlDecode(name),
                Cover = WebUtility.UrlDecode(cover)
            };

            Db.Albums.Add(album);
            Db.SaveChanges();

            return View(GlobalConstants.CreateView);
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult(GlobalConstants.LoginRoot);
            }

            this.Authenticated = true;

            var albumId = request.QuerryData["id"].ToString();

            var albumWithTracks = Db.Albums
                   .Where(ta => ta.Id == albumId)
                   .Select(a => new
                   {
                       a.Id,
                       a.Name,
                       a.Cover,
                       Tracks = a.Tracks.Select(tr => new
                       {
                           tr.Track
                       }).ToArray(),
                       Price = decimal.Multiply(a.Tracks.Select(x => x.Track).Sum(y => y.Price), 0.87m)
                   }).FirstOrDefault();

            this.ViewBag["imgUrl"] = albumWithTracks.Cover;
            this.ViewBag["albumName"] = albumWithTracks.Name;
            this.ViewBag["price"] = albumWithTracks.Price.ToString("F2");

            string tracksList = string.Empty;

            if (albumWithTracks.Tracks.Any())
            {
                var tracks = albumWithTracks.Tracks
                    .Select(tr => tr.Track)
                    .Select(tr => new
                    {
                        tr.Id,
                        tr.Name
                    }).ToArray();

                foreach (var track in tracks)
                {
                    tracksList += $@"<li><a href=""/Tracks/Details/?trackId={track.Id}"">{track.Name}<a/></li>";
                }
            }
            this.ViewBag["tracksList"] = tracksList;
            this.ViewBag["albumId"] = albumWithTracks.Id;

            return this.View();
        }
    }
}
