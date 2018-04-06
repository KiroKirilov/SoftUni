using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class UserTests
{
    [Test]
    public void Constuctor_InitilizeObject_SetsName()
    {
        var name = "Genadi";
        var user = new User(name);
        Assert.That(user.Name, Is.EqualTo(name));
    }

    [Test]
    public void Constuctor_InitilizeObject_CollectionOfCategoriesIsNotNull()
    {
        var name = "Genadi";
        var user = new User(name);
        Assert.That(user.Categories, Is.Not.EqualTo(null));
    }

    [Test]
    [TestCase("\t")]
    [TestCase("      ")]
    [TestCase("")]
    [TestCase("\n")]
    [TestCase("\r\n")]
    public void Constuctor_InitilizeObjectWithInvalidName_ThrowsArgumentExceptionWithMessage(string name)
    {
        Assert.That(()=> new User(name),Throws.ArgumentException.With.Message.EqualTo("Name can't be empty"));
    }

    [Test]
    public void AddCategory_AddCategory_AddsCategory()
    {
        var categoryName = "Na Genadi Kategoriqta";
        var category = new Category(categoryName);
        var username = "Genadi";
        var user = new User(username);
        user.AddCategory(category);
        Assert.That(user.Categories.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddCategory_AddNullCategory_ThrowsArgumentNullException()
    {
        var username = "Genadi";
        var user = new User(username);
        Assert.Throws<ArgumentNullException>(()=> user.AddCategory(null));
    }

    [Test]
    public void RemoveCategory_RemoveCategory_RemovesCategory()
    {
        var categoryName = "Na Genadi Kategoriqta";
        var category = new Category(categoryName);
        var username = "Genadi";
        var user = new User(username);
        user.AddCategory(category);
        user.RemoveCategory(category);
        Assert.That(user.Categories.Count, Is.EqualTo(0));
    }

    [Test]
    public void RemoveCategory_RemoveNullCategory_ThrowsArgumentNullException()
    {
        var username = "Genadi";
        var user = new User(username);
        Assert.Throws<ArgumentNullException>(() => user.RemoveCategory(null));
    }

    [Test]
    public void RemoveCategory_RemoveCategoryThatDoesntExist_ThrowsArgumentException()
    {
        var categoryName = "Na Genadi Kategoriqta";
        var categoryNotInListName = "mene me nema";
        var category = new Category(categoryName);
        var categoryNotInList = new Category(categoryNotInListName);
        var username = "Genadi";
        var user = new User(username);
        user.AddCategory(category);
        Assert.Throws<ArgumentException>(() => user.RemoveCategory(categoryNotInList));
    }
}
