using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class MathTests
{
    private CustomMath math;

    [SetUp]
    public void InitMath()
    {
        this.math = new CustomMath();
    }

    [Test]
    [TestCase(-5.5)]
    [TestCase(5.5)]
    [TestCase(-12345654.51324345345)]
    [TestCase(0)]
    public void AbsShouldNotReturnNegativeValue(double number)
    {
        var result = math.Abs(number);
        Assert.That(result, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    [TestCase(-5.5)]
    [TestCase(5.5)]
    [TestCase(-12345654.51324345345)]
    [TestCase(2135.45656756867786)]
    public void FloorShouldReturnANumberSmallerThanInput(double number)
    {
        var result = math.Floor(number);
        Assert.That(result, Is.LessThan(number));
    }
}
