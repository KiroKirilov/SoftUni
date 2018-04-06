using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class DateTests
{
    private ICustomDateTime customDateTime;

    [SetUp]
    public void TestInit()
    {
        this.customDateTime = new CustomDateTime();
    }

    [Test]
    public void NowShouldReturnCurrentDate()
    {
        var expectedValue = DateTime.Now.Date;
        Assert.AreEqual(expectedValue, this.customDateTime.Now().Date);
    }

    [Test]
    public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
    {
        var testDate = new DateTime(2000, 10, 31);
        var expectedDate = new DateTime(2000, 11, 1);
        testDate = testDate.AddDays(1);
        Assert.AreEqual(expectedDate, testDate);
    }

    [Test]
    public void AddingADayToTheMiddleOfAMonthShouldResultInTheNextDay()
    {
        var testDate = new DateTime(2000, 10, 15);
        var expectedDate = new DateTime(2000, 10, 16);
        testDate = testDate.AddDays(1);
        Assert.AreEqual(expectedDate, testDate);
    }

    [Test]
    public void AddDayTo28FebOnLeapYearShouldResultIn29Feb()
    {
        var testDate = new DateTime(2000, 02, 28);
        var expectedDate = new DateTime(2000, 02, 29);
        testDate = testDate.AddDays(1);
        Assert.AreEqual(expectedDate, testDate);
    }

    [Test]
    public void AddDayTo28FebOnNonLeapYearShouldResultIn1Mar()
    {
        var testDate = new DateTime(2001, 02, 28);
        var expectedDate = new DateTime(2001, 03, 01);
        testDate = testDate.AddDays(1);
        Assert.AreEqual(expectedDate, testDate);
    }

    [Test]
    public void AddNegativeDaysShouldDecreseDate()
    {
        var testDate = new DateTime(2001, 03, 15);
        var expectedDate = new DateTime(2001, 03, 10);
        testDate = testDate.AddDays(-5);
        Assert.AreEqual(expectedDate, testDate);
    }

    [Test]
    public void AddNegativeDaysToStartOfMonthShouldDecreseDateToPreviousMonth()
    {
        var testDate = new DateTime(2001, 03, 01);
        var expectedDate = new DateTime(2001, 02, 24);
        testDate = testDate.AddDays(-5);
        Assert.AreEqual(expectedDate, testDate);
    }

    [Test]
    public void AddDaysToDateTimeMaxValueShouldThrowArgumentOutOfRangeException()
    {
        var testDate = DateTime.MaxValue;
        Assert.Throws<ArgumentOutOfRangeException>(() => testDate.AddDays(5));
    }

    [Test]
    public void SubtractDaysFromDateTimeMinValueShouldThrowArgumentOutOfRangeException()
    {
        var testDate = DateTime.MinValue;
        Assert.Throws<ArgumentOutOfRangeException>(() => testDate.Subtract(new TimeSpan(1, 1, 1, 1)));
    }
}
