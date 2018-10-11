﻿namespace IRunesWebApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Album : BaseModel<string>
    {
        public Album()
        {
            this.Tracks = new HashSet<TrackAlbum>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }
        
        public ICollection<TrackAlbum> Tracks { get; set; }

        //Not mapped because ef doesn't like calculated properties.
        [NotMapped]
        public decimal Price => this.Tracks.Sum(t => t.Track.Price) * 0.87m;
    }
}
