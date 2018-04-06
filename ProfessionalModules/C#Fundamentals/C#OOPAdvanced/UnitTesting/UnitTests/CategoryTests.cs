using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


public class CategoryTests
{
    [Test]
    public void Constructor_InitilizeObject_NameIsSetUp()
    {
        var categoryName = "kategoriq";
        var category = new Category(categoryName);
        Assert.That(category.Name, Is.EqualTo(categoryName));
    }

    [Test]
    public void Constructor_InitilizeObject_UsersCollectionNotNull()
    {
        var categoryName = "kategoriq";
        var category = new Category(categoryName);
        Assert.That(category.Users, Is.Not.EqualTo(null));
    }

    [Test]
    public void Constructor_InitilizeObject_ChildrenCollectionNotNull()
    {
        var categoryName = "kategoriq";
        var category = new Category(categoryName);
        Assert.That(category.ChildCategories, Is.Not.EqualTo(null));
    }

    [Test]
    [TestCase("\t")]
    [TestCase("      ")]
    [TestCase("")]
    [TestCase("\n")]
    [TestCase("\r\n")]
    public void Constuctor_InitilizeObjectWithInvalidName_ThrowsArgumentExceptionWithMessage(string name)
    {
        Assert.That(() => new Category(name), Throws.ArgumentException.With.Message.EqualTo("Name can't be empty"));
    }

    [Test]
    public void AddChild_AddChild_ChildIsAddedToCollection()
    {
        var categoryParentName = "kategoriq tate";
        var parentCategory = new Category(categoryParentName);
        var cateogoryChildName = "kategoriq bebe";
        var childCategory = new Category(cateogoryChildName);
        parentCategory.AddChild(childCategory);
        Assert.That(parentCategory.ChildCategories.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddChild_AddChild_ChildParentSet()
    {
        var categoryParentName = "kategoriq tate";
        var parentCategory = new Category(categoryParentName);
        var cateogoryChildName = "kategoriq bebe";
        var childCategory = new Category(cateogoryChildName);
        parentCategory.AddChild(childCategory);
        Assert.That(childCategory.Parent, Is.Not.EqualTo(null));
    }

    [Test]
    public void AddChild_AddNullChild_ThrowsArgumentNullException()
    {
        var categoryParentName = "kategoriq tate";
        var parentCategory = new Category(categoryParentName);

        Assert.Throws<ArgumentNullException>(() => parentCategory.AddChild(null));
    }

    [Test]
    public void AddUser_AddUser_UserIsAddedToCollection()
    {
        var categoryName = "kategoriq";
        var category = new Category(categoryName);
        var username = "Genadi";
        var user = new User(username);
        category.AddUser(user);
        Assert.That(category.Users.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddUser_AddUser_CategoryIsAddedToUser()
    {
        var categoryName = "kategoriq";
        var category = new Category(categoryName);
        var username = "Genadi";
        var user = new User(username);
        category.AddUser(user);
        Assert.That(user.Categories.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddUser_AddNullUser_ThrowsArgumentNullException()
    {
        var categoryParentName = "kategoriq tate";
        var parentCategory = new Category(categoryParentName);

        Assert.Throws<ArgumentNullException>(() => parentCategory.AddUser(null));
    }

    [Test]
    public void SetParent_SetParent_ParentNotNull()
    {
        var categoryParentName = "kategoriq tate";
        var parentCategory = new Category(categoryParentName);
        var cateogoryChildName = "kategoriq bebe";
        var childCategory = new Category(cateogoryChildName);
        childCategory.SetParent(parentCategory);
        Assert.That(childCategory.Parent, Is.Not.Null);
    }

    [Test]
    public void SetParent_SetNullParent_ThrowsArgumentNullException()
    {
        var cateogoryChildName = "kategoriq bebe";
        var childCategory = new Category(cateogoryChildName);
        Assert.Throws<ArgumentNullException>(() => childCategory.SetParent(null));
    }

    [Test]
    public void MoveUsersToParent_MoveUsersToParent_ParentUserCollectionNotEmpty()
    {
        var categoryParentName = "kategoriq tate";
        var parentCategory = new Category(categoryParentName);
        var cateogoryChildName = "kategoriq bebe";
        var childCategory = new Category(cateogoryChildName);
        var username = "Genadi";
        var user = new User(username);
        childCategory.SetParent(parentCategory);
        childCategory.AddUser(user);
        childCategory.MoveUsersToParent();
        Assert.That(childCategory.Parent.Users.Count, Is.EqualTo(1));
    }

    public void MoveUsersToParent_MoveUsersToNullParent_ThrowsArgumentNullException()
    {
        var categoryParentName = "kategoriq tate";
        var parentCategory = new Category(categoryParentName);
        var cateogoryChildName = "kategoriq bebe";
        var childCategory = new Category(cateogoryChildName);
        var username = "Genadi";
        var user = new User(username);
        childCategory.SetParent(null);
        childCategory.AddUser(user);
        Assert.Throws<ArgumentNullException>(() => childCategory.MoveUsersToParent());
    }

    [Test]
    public void RemoveChild_RemoveChild_ChildCollectionRemoved()
    {
        var categoryParentName = "kategoriq tate";
        var parentCategory = new Category(categoryParentName);
        var cateogoryChildName = "kategoriq bebe";
        var childCategory = new Category(cateogoryChildName);
        parentCategory.AddChild(childCategory);
        parentCategory.RemoveChild(cateogoryChildName);
        Assert.That(parentCategory.ChildCategories.Count, Is.EqualTo(0));
    }
}

