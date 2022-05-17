using FluentAssertions;
using NUnit.Framework;
using ShapePosition.Models;
using System;

namespace ShapePosition.Tests
{
    public class RectangleContainCalculatorTests
    {
        private static readonly Tuple<Rectangle, Rectangle> noContain = Tuple.Create(new Rectangle(1, 5, 4, 3), new Rectangle(1, 8, 4, 6));

        //Item1 contains Item2
        private static readonly Tuple<Rectangle, Rectangle> doesContain = Tuple.Create(new Rectangle(1, 12, 7, 9), new Rectangle(2, 11, 4, 10));

        [Test]
        public static void CalculateContained_NoContain_ShouldReturnFalse()
        {
            //Arrange
            var sut = new RectangleContainCalculator();

            //Act
            bool result = sut.IsRectangle2ContainedIn1(noContain.Item1, noContain.Item2);
            bool invertedResult = sut.IsRectangle2ContainedIn1(noContain.Item2, noContain.Item1);

            //Assert
            result.Should().BeFalse();
            invertedResult.Should().BeFalse();
        }

        [Test]
        public static void IsRectangle1ContainedIn2_ShouldReturnExpectedBool()
        {
            //Arrange
            var sut = new RectangleContainCalculator();

            //Act
            bool result = sut.IsRectangle1ContainedIn2(doesContain.Item1, doesContain.Item2);
            bool invertedResult = sut.IsRectangle1ContainedIn2(doesContain.Item2, doesContain.Item1);

            //Assert
            result.Should().BeFalse();
            invertedResult.Should().BeTrue();
        }

        [Test]
        public static void IsRectangle2ContainedIn1_ShouldReturnExpectedBool()
        {
            //Arrange
            var sut = new RectangleContainCalculator();

            //Act
            bool result = sut.IsRectangle2ContainedIn1(doesContain.Item1, doesContain.Item2);
            bool invertedResult = sut.IsRectangle2ContainedIn1(doesContain.Item2, doesContain.Item1);

            //Assert
            result.Should().BeTrue();
            invertedResult.Should().BeFalse();
        }       

        [Test]
        public static void CalculateContained_NullRectangle1_ShouldThrowEx()
        {
            //Arrange
            var r2 = new Rectangle(1, 2, 3, 4);
            var sut = new RectangleContainCalculator();

            //Act
            Action act = () => sut.CalculateContained(null, r2);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public static void CalculateContained_NullRectangle2_ShouldThrowEx()
        {
            //Arrange
            var r1 = new Rectangle(1, 2, 3, 4);
            var sut = new RectangleContainCalculator();

            //Act
            Action act = () => sut.CalculateContained(r1, null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public static void CalculateContained_NullValues_ShouldThrowEx()
        {
            //Arrange            
            var sut = new RectangleContainCalculator();

            //Act
            Action act = () => sut.CalculateContained(null, null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
