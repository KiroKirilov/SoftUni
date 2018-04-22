using FestivalManager.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public abstract class Set : ISet
    {
        private IList<IPerformer> performers;
        private IList<ISong> songs;

        public Set(string name)
        {
            this.Name = name;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; }

        public abstract TimeSpan MaxDuration { get; }

        public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers => this.performers as IReadOnlyCollection<IPerformer>;

        public IReadOnlyCollection<ISong> Songs => this.songs as IReadOnlyCollection<ISong>;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (this.ActualDuration + song.Duration > this.MaxDuration)
            {
                throw new InvalidOperationException("Song is over the set limit!");
            }
            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            bool validAmountOfPerformers = this.performers.Count > 0;
            bool validAmountOfSongs = this.songs.Count > 0;
            bool allPerfomersHaveValidInstument = this.performers.All(p => p.Instruments.Any(i => i.IsBroken == false));

            return validAmountOfPerformers && validAmountOfSongs && allPerfomersHaveValidInstument;
        }
    }
}

