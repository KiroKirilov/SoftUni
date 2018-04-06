using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ExtendedDatabaseTests
{
    [Test]
    public void Add_AddItem_ItemPresentInCollection()
    {
        var initialId = 1;
        var initialUsername = "Genadi";
        var db = new ExtendedDatabase();
        var person = new Person(initialId, initialUsername);
        db.Add(person);
        Assert.That(db.People.Contains(person));
    }

    [Test]
    public void Add_AddItemWithIdAlreadyPresent_ThrowsInvalidOperationExecption()
    {
        var initialId = 1;
        var initialUsernamePerson1 = "Genadi";
        var initialUsernamePerson2 = "Stavri";
        var db = new ExtendedDatabase();
        var person1 = new Person(initialId, initialUsernamePerson1);
        var person2 = new Person(initialId, initialUsernamePerson2);
        db.Add(person1);
        Assert.That(() => db.Add(person2),Throws.InvalidOperationException);
    }

    [Test]
    public void Add_AddItemWithUsernameAlreadyPresent_ThrowsInvalidOperationExecption()
    {
        var initialIdPerson1 = 1;
        var initialIdPerson2 = 2;
        var initialUsernamePerson = "Genadi";
        var db = new ExtendedDatabase();
        var person1 = new Person(initialIdPerson1, initialUsernamePerson);
        var person2 = new Person(initialIdPerson2, initialUsernamePerson);
        db.Add(person1);
        Assert.That(() => db.Add(person2), Throws.InvalidOperationException);
    }

    [Test]
    public void Remove_RemoveItem_ItemNotPresentInCollection()
    {
        var initialId = 1;
        var initialUsername = "Genadi";
        var db = new ExtendedDatabase();
        var person = new Person(initialId, initialUsername);
        db.Add(person);
        db.Remove();
        Assert.That(!db.People.Contains(person));
    }

    [Test]
    public void Remove_RemoveItemWithEmptyCollection_ThrowInvalidOperationException()
    {
        var db = new ExtendedDatabase();
        Assert.That(() => db.Remove(), Throws.InvalidOperationException);
    }

    [Test]
    public void FindById_FindExistingItem_ReturnsCorrectPerson()
    {
        var id1 = 1;
        var id2 = 2;
        var name1 = "Genadi";
        var name2 = "Stavri";
        var db = new ExtendedDatabase();
        var p1 = new Person(id1,name1);
        var p2 = new Person(id2, name2);
        db.Add(p1);
        db.Add(p2);
        var found = db.FindById(id1);
        Assert.That(found, Is.EqualTo(p1));
    }

    [Test]
    public void FindById_FindNonExistingId_ThrowsInvalidOperationException()
    {
        var id1 = 1;
        var id2 = 2;
        var name1 = "Genadi";
        var db = new ExtendedDatabase();
        var p1 = new Person(id1, name1);
        db.Add(p1);
        Assert.That(() => db.FindById(id2), Throws.InvalidOperationException);
    }

    [Test]
    public void FindById_FindIdLessThanZero_ThrowsArgumentOutOfRangeException()
    {
        var id1 = 1;
        var name1 = "Genadi";
        var db = new ExtendedDatabase();
        var p1 = new Person(id1, name1);
        db.Add(p1);
        Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
    }

    [Test]
    public void FindByUsername_FindNonExistingUsername_ThrowsInvalidOperationException()
    {
        var id1 = 1;
        var name2 = "Stavri";
        var name1 = "Genadi";
        var db = new ExtendedDatabase();
        var p1 = new Person(id1, name1);
        db.Add(p1);
        Assert.That(() => db.FindByUsername(name2), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByUsername_FindExistingItem_ReturnsCorrectPerson()
    {
        var id1 = 1;
        var id2 = 2;
        var name1 = "Genadi";
        var name2 = "Stavri";
        var db = new ExtendedDatabase();
        var p1 = new Person(id1, name1);
        var p2 = new Person(id2, name2);
        db.Add(p1);
        db.Add(p2);
        var found = db.FindByUsername(name1);
        Assert.That(found, Is.EqualTo(p1));
    }

    [Test]
    public void FindByUsername_FindNull_ThrowsNullArgumentException()
    {
        var id1 = 1;
        var id2 = 2;
        var name1 = "Genadi";
        var name2 = "Stavri";
        var db = new ExtendedDatabase();
        var p1 = new Person(id1, name1);
        var p2 = new Person(id2, name2);
        db.Add(p1);
        db.Add(p2);
        Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
    }

    [Test]
    public void Constructor_InitilizeObject_CollectionIsNotNull()
    {
        var db = new ExtendedDatabase();
        Assert.That(db.People, Is.Not.EqualTo(null));
    }
}

