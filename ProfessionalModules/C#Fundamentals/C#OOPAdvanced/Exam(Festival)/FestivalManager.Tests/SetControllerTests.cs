// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
//using FestivalManager.Core.Controllers;
//using FestivalManager.Core.Controllers.Contracts;
//using FestivalManager.Entities;
//using FestivalManager.Entities.Contracts;
//using FestivalManager.Entities.Instruments;
//using FestivalManager.Entities.Sets;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FestivalManager.Tests
{

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void SetFailsWithNoSongs()
        {
            IStage stage = new Stage();
            IInstrument guitar = new Guitar();
            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Stavri", 12);
            performer.AddInstrument(guitar);
            set.AddPerformer(performer);
            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            var result = setController.PerformSets();

            Assert.That(result.Contains("Did not perform"));
        }

        [Test]
        public void SetFailsWithNoPerformers()
        {
            IStage stage = new Stage();
            IInstrument guitar = new Guitar();
            ISet set = new Short("Set1");
            ISong song = new Song("Something", new System.TimeSpan(0, 2, 0));
            //IPerformer performer = new Performer("Stavri", 12, instruments);
            set.AddSong(song);
            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            var result = setController.PerformSets();

            Assert.That(result.Contains("Did not perform"));
        }

        [Test]
        public void SetFailsWithNoInstrumentsForPerformers()
        {
            IStage stage = new Stage();
            IInstrument guitar = new Guitar();
            ISet set = new Short("Set1");
            ISong song = new Song("Something", new System.TimeSpan(0, 2, 0));
            IPerformer performer = new Performer("Stavri", 12);
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            var result = setController.PerformSets();

            Assert.That(result.Contains("Did not perform"));
        }

        [Test]
        public void InstrumentWearsDown()
        {
            IStage stage = new Stage();
            IInstrument guitar = new Guitar();
            ISet set = new Short("Set1");
            ISong song = new Song("Something", new System.TimeSpan(0, 2, 0));
            IPerformer performer = new Performer("Stavri", 12);
            performer.AddInstrument(guitar);
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            var result = setController.PerformSets();

            Assert.That(guitar.Wear < 100);
        }

        [Test]
        public void ValidSetIsSuccessful()
        {
            IStage stage = new Stage();
            IInstrument guitar = new Guitar();
            ISet set = new Short("Set1");
            ISong song = new Song("Something", new System.TimeSpan(0, 2, 0));
            IPerformer performer = new Performer("Stavri", 12);
            performer.AddInstrument(guitar);
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            var result = setController.PerformSets();

            Assert.That(result.Contains("Set Successful"));
        }

        [Test]
        public void CorrectTimeIsDisplayed()
        {
            IStage stage = new Stage();
            IInstrument guitar = new Guitar();
            IInstrument drums = new Drums();
            ISet set2 = new Medium("Settadfkhshdk");
            ISong song2 = new Song("Nothing", new TimeSpan(0, 3, 0));
            ISet set1 = new Short("Set1");
            //ISong song1 = new Song("Something", new System.TimeSpan(0, 2, 0));
            IPerformer performer1 = new Performer("Stavri", 12);
            IPerformer performer2 = new Performer("Genadi", 13);
            ISetController setController = new SetController(stage);
            performer2.AddInstrument(drums);
            performer1.AddInstrument(guitar);
            set1.AddPerformer(performer1);
            //set1.AddSong(song1);
            set2.AddPerformer(performer2);
            set2.AddSong(song2);
            stage.AddSet(set1);
            stage.AddSet(set2);

            var result = setController.PerformSets();

            Assert.That(result.Contains("03:00"));
        }

        [Test]
        public void SetCountInreases()
        {
            IStage stage = new Stage();
            IInstrument guitar = new Guitar();
            IInstrument drums = new Drums();
            ISet set2 = new Medium("Settadfkhshdk");
            ISong song2 = new Song("Nothing", new TimeSpan(0, 3, 0));
            ISet set1 = new Short("Set1");
            ISong song1 = new Song("Something", new System.TimeSpan(0, 2, 0));
            IPerformer performer1 = new Performer("Stavri", 12);
            IPerformer performer2 = new Performer("Genadi", 13);
            ISetController setController = new SetController(stage);
            performer2.AddInstrument(drums);
            performer1.AddInstrument(guitar);
            set1.AddPerformer(performer1);
            set1.AddSong(song1);
            set2.AddPerformer(performer2);
            set2.AddSong(song2);
            stage.AddSet(set1);
            stage.AddSet(set2);

            var result = setController.PerformSets();

            Assert.That(result.Contains("1. Settadfkhshdk"));
        }
    }
}