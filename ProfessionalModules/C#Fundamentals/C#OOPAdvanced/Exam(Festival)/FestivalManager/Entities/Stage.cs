namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly IList<ISet> sets;
        private readonly IList<ISong> songs;
        private readonly IList<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets as IReadOnlyCollection<ISet>;

        public IReadOnlyCollection<ISong> Songs => this.songs as IReadOnlyCollection<ISong>;

        public IReadOnlyCollection<IPerformer> Performers => this.performers as IReadOnlyCollection<IPerformer>;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(n=>n.Name==name);

            if (performer==null)
            {
                throw new ArgumentException("Performer not found");
            }

            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(s => s.Name == name);

            if (set==null)
            {
                throw new ArgumentException("Set not found");
            }

            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(s => s.Name == name);

            if (song == null)
            {
                throw new ArgumentException("Song not found");
            }

            return song;
        }

        public bool HasPerformer(string name)
        {
            bool hasPerformer = this.performers.Any(p => p.Name == name);
            return hasPerformer;
        }

        public bool HasSet(string name)
        {
            bool hasSet = this.sets.Any(s => s.Name == name);
            return hasSet;
        }

        public bool HasSong(string name)
        {
            bool hasSong = this.songs.Any(s => s.Name == name);
            return hasSong;
        }
    }
}
