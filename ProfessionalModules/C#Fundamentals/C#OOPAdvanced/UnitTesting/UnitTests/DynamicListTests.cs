using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class DynamicListTests
{
    private DynamicList<int> dynamicList;

    [SetUp]
    public void InitList()
    {
        this.dynamicList = new DynamicList<int>();
    }

    [Test]
    public void CallingNegativeIndexThrowsArgumentOutOfRangeException()
    {
        var incorrectIndex = -1;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var noValue = this.dynamicList[incorrectIndex];
        });
    }

    [Test]
    public void CallingIndexHigherThanCollectionCountThrowsArgumentOutOfRangeException()
    {
        var incorrectIndex = 1;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var test = this.dynamicList[incorrectIndex];
        });
    }

    [Test]
    public void AddShouldIncreaseCollectionCount()
    {
        this.dynamicList.Add(1);
        Assert.AreEqual(1, this.dynamicList.Count);
    }

    [Test]
    [TestCase(1)]
    [TestCase(-1)]
    public void RemoveAtIndexOusideTheBoundariesOfTheCollectionIsImpossible(int index)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(index));
    }

    [Test]
    [TestCase(23, 1)]
    [TestCase(100, 43)]
    [TestCase(123, 100)]
    public void RemoveAtShouldRemoveTheElementAtTheGivenIndex(int numberOfItemsToAdd, int indexToRemove)
    {
        for (int i = 0; i < numberOfItemsToAdd; i++)
        {
            this.dynamicList.Add(i);
        }
        this.dynamicList.RemoveAt(indexToRemove);
        Assert.AreEqual(indexToRemove + 1, dynamicList[indexToRemove]);
    }

    [Test]
    [TestCase(5, 2)]
    [TestCase(4, 1)]
    [TestCase(23, 11)]
    public void IndexOfShouldReturnTheIndexOfTheFirstOccurrenceOfTheElementInTheList(int numberOfItemsToAdd, int index)
    {
        for (int i = 0; i < numberOfItemsToAdd; i++)
        {
            this.dynamicList.Add(i);
        }
        var expectedIndex = index;
        var foundIndex = this.dynamicList.IndexOf(index);
        Assert.AreEqual(expectedIndex, foundIndex);
    }

    [Test]
    [TestCase(4, 9)]
    [TestCase(8, -12)]
    [TestCase(3, 4)]
    public void IndexOfShouldReturnNegativeOneIfIndexDoesntExist(int numberOfItemsToAdd, int index)
    {
        for (int i = 0; i < numberOfItemsToAdd; i++)
        {
            this.dynamicList.Add(i);
        }
        var isValueLessThanZero = this.dynamicList.IndexOf(index) < 0;
        Assert.IsTrue(isValueLessThanZero);
    }

    [Test]
    [TestCase(100, 43)]
    [TestCase(12, 9)]
    [TestCase(15, 0)]
    public void RemoveShouldDeleteGivenElement(int numberOfItemsToAdd, int element)
    {
        for (int i = 0; i < numberOfItemsToAdd; i++)
        {
            this.dynamicList.Add(i);
        }
        this.dynamicList.Remove(element);
        Assert.AreEqual(-1, this.dynamicList.IndexOf(element));
    }

    [Test]
    [TestCase(5, 8)]
    [TestCase(32, -1)]
    [TestCase(8, 10)]
    public void RemoveElementNotInCollectionShouGiveNegativeOne(int numberOfItemsToAdd, int element)
    {
        for (int i = 0; i < numberOfItemsToAdd; i++)
        {
            this.dynamicList.Add(i);
        }
        var isRemovingResultLesThanZero = this.dynamicList.Remove(element) < 0;
        Assert.IsTrue(isRemovingResultLesThanZero);
    }

    [Test]
    [TestCase(9, 5)]
    [TestCase(45, 4)]
    [TestCase(9, 7)]
    public void RemoveShouldGiveTheIndexOfTheRemovedElement(int numberOfItemsToAdd, int element)
    {
        for (int i = 0; i < numberOfItemsToAdd; i++)
        {
            this.dynamicList.Add(i);
        }
        var expectedIndex = element;
        var returnedIndex = this.dynamicList.Remove(element);
        Assert.AreEqual(expectedIndex, returnedIndex);
    }

    [Test]
    [TestCase(9, 5)]
    [TestCase(45, 4)]
    [TestCase(9, 7)]
    public void ContainsReturnsTrueIfElementIsFound(int numberOfItemsToAdd, int element)
    {
        for (int i = 0; i < numberOfItemsToAdd; i++)
        {
            this.dynamicList.Add(i);
        }
        Assert.IsTrue(this.dynamicList.Contains(element));
    }

    [Test]
    [TestCase(9, 19)]
    [TestCase(45, 46)]
    [TestCase(9, -1)]
    public void ContainsReturnsFalseIfElementIsNotFound(int numberOfItemsToAdd, int element)
    {
        for (int i = 0; i < numberOfItemsToAdd; i++)
        {
            this.dynamicList.Add(i);
        }
        Assert.IsFalse(this.dynamicList.Contains(element));
    }
}
