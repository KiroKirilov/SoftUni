using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


public class BubbleTests
{
    [Test]
    public void Constuctior_InitilizeObject_CollectionNotNull()
    {
        var list = new List<int>() { 5, 4, 6, 8, 6 };
        var bubble = new Bubble<int>(list);
        Assert.That(bubble.Collection, Is.Not.EqualTo(null));
    }

    [Test]
    public void Constuctior_InitilizeObject_CollectionCountIsSetUp()
    {
        var list = new List<int>() { 5, 4, 6, 8, 6 };
        var bubble = new Bubble<int>(list);
        var expected = list.Count;
        var actual = bubble.Collection.Count;
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Constuctor_InitilizeObjectWithNull_ThrowsArumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Bubble<int>(null));
    }

    [Test]
    public void Constuctor_InitilizeObjectWithEmptyList_ThrowsArumentExceptionWithMessage()
    {
        var list = new List<int>() { };
        Assert.That(()=> new Bubble<int>(list),Throws.ArgumentException.With.Message.EqualTo("Collection must have at least 2 items."));
    }

    [Test]
    public void Constuctor_InitilizeObjectWithOneElementInList_ThrowsArumentExceptionWithMessage()
    {
        var list = new List<int>() { 1 };
        Assert.That(() => new Bubble<int>(list), Throws.ArgumentException.With.Message.EqualTo("Collection must have at least 2 items."));
    }

    [Test]
    public void Sort_SortCollection_ReturnsSortedCollection()
    {
        var list = new List<int>() { 5, 4, 2, 7, 6 };
        var bubble = new Bubble<int>(list);
        var sorted = bubble.Sort();
        var expected = "24567";
        var actual = string.Join(string.Empty, sorted);
        Assert.That(actual, Is.EqualTo(expected));
    }

}

