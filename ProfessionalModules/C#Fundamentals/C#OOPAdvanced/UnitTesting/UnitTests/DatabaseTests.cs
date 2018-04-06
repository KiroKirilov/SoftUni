using NUnit.Framework;
using System;

namespace UnitTests
{
    public class DatabaseTests
    {
        [Test]
        public void Add_AddItem_IncreasesCount()
        {
            var valueToAdd = 5;
            var expectedCount = 1;
            var db = new CustomDatabase();
            db.Add(valueToAdd);
            Assert.That(db.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddMoreThan16Items_ThrowsInvalidOperationException()
        {
            var valueToAdd = 7;
            var db = new CustomDatabase(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6);
            Assert.That(()=>db.Add(valueToAdd), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_RemoveItem_DecreasesCount()
        {
            var expectedCount = 0;
            var db = new CustomDatabase(1);
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_RemoveItemWhenArrayIsEmpty_ThrowsInvalidOperationException()
        {
            var db = new CustomDatabase(1);
            db.Remove();
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void Fetch_ReturnsCorrectArrayAfterRemove()
        {
            var db = new CustomDatabase(1, 2, 3, 4);
            var expectedArray = new int[] { 1, 2 };
            db.Remove();
            db.Remove();
            var returnedArray = db.Fetch();
            Assert.That(returnedArray, Is.EqualTo(expectedArray));
        }

        [Test]
        public void Fetch_ReturnCorrectArrayAfterAdd()
        {
            var db = new CustomDatabase();
            db.Add(1);
            db.Add(2);
            var expectedArray = new int[] { 1, 2 };
            var returnedArray = db.Fetch();
            Assert.That(returnedArray, Is.EqualTo(expectedArray));
        }

        [Test]
        public void ParamsConstructor_InitilizesArray_CountIsCorrect()
        {
            var expectedCount = 5;
            var db = new CustomDatabase(1,2,3,4,5);
            Assert.That(db.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void ParameterlessConstructor_InitilizesArray_CountIsCorrect()
        {
            var expectedCount = 0;
            var db = new CustomDatabase();
            Assert.That(db.Count, Is.EqualTo(expectedCount));
        }
    }
}
