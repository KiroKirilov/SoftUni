namespace FestivalManager.Core.Controllers
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";

		private readonly IStage stage;
        private ISetFactory setFactory;
        private ISetController setController;
        private IInstrumentFactory instrumentFactory;

		public FestivalController(IStage stage, ISetFactory setFactory,ISetController setController, IInstrumentFactory instrumentFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.setController = setController;
            this.instrumentFactory = instrumentFactory;
		}

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];
            IPerformer performer = this.stage.Performers.FirstOrDefault(p=>p.Name==performerName);
            ISet set = this.stage.Sets.FirstOrDefault(s=>s.Name==setName);

            if (performer==null)
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (set == null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];
            ISong song = this.stage.Songs.FirstOrDefault(s => s.Name == songName);
            ISet set = this.stage.Sets.FirstOrDefault(s => s.Name == setName);

            if (set == null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (song == null)
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }

        public string ProduceReport()
        {
            StringBuilder result = new StringBuilder();

            TimeSpan totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            var resultTotal = string.Format("Festival length: {0:d2}:{1:d2}", (int)totalFestivalLength.TotalMinutes, totalFestivalLength.Seconds);
            result.AppendLine(resultTotal);

            foreach (var set in this.stage.Sets)
            {
                var resultSet = string.Format("{0:d2}:{1:d2}", (int)set.ActualDuration.TotalMinutes, set.ActualDuration.Seconds);
                result.AppendLine($"--{set.Name} ({resultSet}):");

                List<IPerformer> orderedPerformers = set.Performers.OrderByDescending(p => p.Age).ToList();
                foreach (var performer in orderedPerformers)
                {
                    var instrumentInfo = new StringBuilder();
                    foreach (var instrument in performer.Instruments.OrderByDescending(i=>i.Wear))
                    {
                        var instrumentStatus = instrument.IsBroken ? "broken" : $"{instrument.Wear}%";

                        instrumentInfo.Append($"{instrument.GetType().Name} [{instrumentStatus}], ");
                    }

                    if (instrumentInfo.Length > 1)
                    {
                        instrumentInfo.Length -= 2;
                    }
                    

                    result.AppendLine($"---{performer.Name} ({instrumentInfo.ToString().Trim()})");
                }

                if (!set.Songs.Any())
                    result.AppendLine("--No songs played");
                else
                {
                    result.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        result.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
            }

            return result.ToString().Trim();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];
            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

        public string RegisterSong(string[] args)
        {
            string songName = args[0];
            string songLengthString = args[1];
            TimeSpan timeSpan = TimeSpan.ParseExact(songLengthString,TimeFormat,CultureInfo.InvariantCulture);
            ISong song = new Song(songName,timeSpan);

            this.stage.AddSong(song);

            return $"Registered song {songName} ({songLengthString})";
        }

        public string RepairInstruments(string[] args)
        {
            int repairedCount = 0;
            foreach (var performer in this.stage.Performers)
            {
                foreach (var instrument in performer.Instruments)
                {
                    if (instrument.Wear<100)
                    {
                        instrument.Repair();
                        repairedCount++;
                    }
                }
            }

            return $"Repaired {repairedCount} instruments";
        }

        public string SignUpPerformer(string[] args)
        {
            string performerName = args[0];
            int performerAge = int.Parse(args[1]);
            string[] instumentNames = args.Skip(2).ToArray();
            IList<IInstrument> instruments = new List<IInstrument>();
            if (instumentNames.Length>0)
            {
                foreach (var instumentName in instumentNames)
                {
                    IInstrument instrument=this.instrumentFactory.CreateInstrument(instumentName);
                    instruments.Add(instrument);
                }
            }

            IPerformer performer = new Performer(performerName, performerAge);
            foreach (var instr in instruments)
            {
                performer.AddInstrument(instr);
            }
            this.stage.AddPerformer(performer);
            return $"Registered performer {performerName}";

        }

        //public string Report()
        //{
        //	var result = string.Empty;

        //	var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

        //	result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

        //	foreach (var set in this.stage.Sets)
        //	{
        //		result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

        //		var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
        //		foreach (var performer in performersOrderedDescendingByAge)
        //		{
        //			var instruments = string.Join(", ", performer.Instruments
        //				.OrderByDescending(i => i.Wear));

        //			result += ($"---{performer.Name} ({instruments})") + "\n";
        //		}

        //		if (!set.Songs.Any())
        //			result += ("--No songs played") + "\n";
        //		else
        //		{
        //			result += ("--Songs played:") + "\n";
        //			foreach (var song in set.Songs)
        //			{
        //				result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
        //			}
        //		}
        //	}

        //	return result.ToString();
        //}

        //public string RegisterSet(string[] args)
        //{
        //	throw new NotImplementedException(); // оф...
        //}

        //public string SignUpPerformer(string[] args)
        //{
        //	var name = args[0];
        //	var age = int.Prase(args[1]);

        //	var instrumenti = args.Skip(2).ToArray();

        //	var instrumenti2 = instrumenti
        //		.Select(i => this.instrumentFactory.CreateInstrument(i))
        //		.ToArray();

        //	var performer = this.performerFactory.CreatePerformer(name, age);

        //	foreach (var instrument in instrumenti2)
        //	{
        //		performer.AddInstrument(instrument);
        //	}

        //	this.stage.AddPerformer(performer);

        //	return $"Registered performer {performer.Name}";
        //}

        //public string RegisterSong(string[] args)
        //{
        //	// TODO: scheduled for next month

        //	return $"Registered song {song}";
        //}

        //public string SongRegistration(string[] args)
        //{
        //	var songName = args[0];
        //	var setName = args[1];

        //	if (!this.stage.HasSet(setName))
        //	{
        //		throw new InvalidOperationException("Invalid set provided");
        //	}

        //	if (!this.stage.HasSong(songName))
        //	{
        //		throw new InvalidOperationException("Invalid song provided");
        //	}

        //	var set = this.stage.GetSet(setName);
        //	var song = this.stage.GetSong(songName);

        //	set.AddSong(song);

        //	return $"Added {song} to {set.Name}";
        //}

        //// Временно!!! Чтобы работало делаем срез на конец месяца
        //public string AddPerformerToSet(string[] args)
        //{
        //	return PerformerRegistration(args);
        //}

        //public string PerformerRegistration(string[] args)
        //{
        //	var performerName = args[0];
        //	var setName = args[1];

        //	if (!this.stage.HasPerformer(performerName))
        //	{
        //		throw new InvalidOperationException("Invalid performer provided");
        //	}

        //	if (!this.stage.HasSet(setName))
        //	{
        //		throw new InvalidOperationException("Invalid set provided");
        //	}

        //	AddPerformerToSet(args);

        //	var performer = this.stage.GetPerformer(performerName);
        //	var set = this.stage.GetSet(setName);

        //	set.AddPerformer(performer);

        //	return $"Added {performer.Name} to {set.Name}";
        //}

        //public string RepairInstruments(string[] args)
        //{
        //	var instrumentsToRepair = this.stage.Performers
        //		.SelectMany(p => p.Instruments)
        //		.Where(i => i.Wear <= 100)
        //		.ToArray();

        //	foreach (var instrument in instrumentsToRepair)
        //	{
        //		instrument.Repair();
        //	}

        //	return $"Repaired {instrumentsToRepair.Length} instruments";
        //}
    }
}