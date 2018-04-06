using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class ListyIteratorTests
{
    [Test]
    public void Constructor_InitilizeObject_InitilizesCollection()
    {
        var listToUseToInitilize = new List<int>() { 1, 2, 3, 4, 5, 6 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        Assert.That(listy.Collection, Is.Not.EqualTo(null));
    }

    [Test]
    public void Constructor_InitilizeObjectWithNullCollection_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new ListyIterator<int>(null));
    }

    [Test]
    public void GetEnumerator_ForeachCollection_ForeachesCollection()
    {
        var listToUseToInitilize = new List<int>() { 1, 2, 3, 4, 5, 6 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        var expectedOutput = "123456";
        var sb = new StringBuilder();
        foreach (var num in listy)
        {
            sb.Append(num);
        }
        var actualOutput = sb.ToString();

        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void GetEnumerator_ForeachEmptyCollection_ThrowsInvalidOperationExceptionWithMessage()
    {
        var listToUseToInitilize = new List<int>();
        var listy = new ListyIterator<int>(listToUseToInitilize);

        Assert.That(() =>
        {
            foreach (var item in listy)
            {
                Console.WriteLine("Tova ne trqbva da se sluchva.");
            }
        }, Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
    }

    [Test]
    public void HasNext_CheckIfNextExists_True()
    {
        var listToUseToInitilize = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        var expected = true;
        var actual = listy.HasNext();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void HasNext_CheckIfNextExistsWhenItDoesnt_False()
    {
        var listToUseToInitilize = new List<int>() { 1 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        var expected = false;
        var actual = listy.HasNext();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PrintAll_PrintsAll()
    {
        var listToUseToInitilize = new List<int>() { 1,2,3,4,5,6,7,8 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        var expected = "1 2 3 4 5 6 7 8";
        var actual = listy.PrintAll();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Print_PrintCurrentElement_CurrentElementAsString()
    {
        var listToUseToInitilize = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        var expected = "1";
        var actual = listy.Print();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Move_MoveWhenNextExists_True()
    {
        var listToUseToInitilize = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        var expected = true;
        var actual = listy.Move();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Move_MoveWhenNextDoesntExist_False()
    {
        var listToUseToInitilize = new List<int>() { 1 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        var expected = false;
        var actual = listy.Move();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Move_MovesIndex_ChangesIndex()
    {
        var listToUseToInitilize = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        var listy = new ListyIterator<int>(listToUseToInitilize);
        var expected = 1;
        listy.Move();
        var actual = listy.CurrentIndex;
        Assert.That(actual, Is.EqualTo(expected));
    }
}
