using FluentAssertions;
using NUnit.Framework;
using ShapePosition.Models;
using System;

namespace ShapePosition.Tests
{
    public class RectangleIntersectCalculatorTests
    {
        private static readonly Tuple<Rectangle, Rectangle> noIntersect = Tuple.Create(new Rectangle(1, 5, 4, 3), new Rectangle(1, 8, 4, 6));
        private static readonly Tuple<Rectangle, Rectangle> intersectsOnBottom = Tuple.Create(new Rectangle(1, 5, 4, 3), new Rectangle(2, 4, 3, 1));
        private static readonly Tuple<Rectangle, Rectangle> intersectsOnTop = Tuple.Create(new Rectangle(6, 8, 10, 6), new Rectangle(8, 10, 9, 7));
        private static readonly Tuple<Rectangle, Rectangle> fourPointsOfintersect = Tuple.Create(new Rectangle(6, 8, 10, 6), new Rectangle(8, 10, 9, 5));
        private static readonly Tuple<Rectangle, Rectangle> bottomRightOrTopLeftIntersect = Tuple.Create(new Rectangle(6, 8, 10, 6), new Rectangle(9, 7, 12, 4));
        private static readonly Tuple<Rectangle, Rectangle> bottomLeftOrTopRightIntersect = Tuple.Create(new Rectangle(6, 8, 10, 6), new Rectangle(5, 9, 7, 7));
        private static readonly Tuple<Rectangle, Rectangle> leftIntersect = Tuple.Create(new Rectangle(4, 5, 6, 1), new Rectangle(1, 4, 5, 2));
        private static readonly Tuple<Rectangle, Rectangle> rightIntersect = Tuple.Create(new Rectangle(4, 5, 6, 1), new Rectangle(5, 4, 8, 2));


        [Test]
        public static void CalculateIntersect_NoIntersect_ShouldReturnExpectedType()
        {
            //Arrange
            var sut = new RectangleIntersectCalculator();

            //Act
            Intersect result = sut.CalculateIntersect(noIntersect.Item1, noIntersect.Item2);

            //Assert
            result.IsIntersecting.Should().BeFalse();
            result.PointOfIntersect1.Should().Be(System.Drawing.Point.Empty);
            result.PointOfIntersect2.Should().Be(System.Drawing.Point.Empty);
        }

        [Test]
        public static void CalculateIntersect_IntersectsOnBottom_ShouldReturnExpectedValues()
        {
            //Arrange
            var sut = new RectangleIntersectCalculator();

            //Act
            Intersect result = sut.CalculateIntersect(intersectsOnBottom.Item1, intersectsOnBottom.Item2);
            Intersect invertedResult = sut.CalculateIntersect(intersectsOnBottom.Item2, intersectsOnBottom.Item1);

            //Assert
            result.IsIntersecting.Should().BeTrue();
            result.PointOfIntersect1.Should().Be(new System.Drawing.Point(2, 3));
            result.PointOfIntersect2.Should().Be(new System.Drawing.Point(3, 3));
            invertedResult.IsIntersecting.Should().BeTrue();
            invertedResult.PointOfIntersect1.Should().Be(new System.Drawing.Point(2, 3));
            invertedResult.PointOfIntersect2.Should().Be(new System.Drawing.Point(3, 3));
        }

        [Test]
        public static void CalculateIntersect_IntersectsOnTop_ShouldReturnExpectedValues()
        {
            //Arrange
            var sut = new RectangleIntersectCalculator();

            //Act
            Intersect result = sut.CalculateIntersect(intersectsOnTop.Item1, intersectsOnTop.Item2);
            Intersect invertedResult = sut.CalculateIntersect(intersectsOnTop.Item2, intersectsOnTop.Item1);

            //Assert
            result.IsIntersecting.Should().BeTrue();
            result.PointOfIntersect1.Should().Be(new System.Drawing.Point(8, 8));
            result.PointOfIntersect2.Should().Be(new System.Drawing.Point(9, 8));
            invertedResult.IsIntersecting.Should().BeTrue();
            invertedResult.PointOfIntersect1.Should().Be(new System.Drawing.Point(8, 8));
            invertedResult.PointOfIntersect2.Should().Be(new System.Drawing.Point(9, 8));
        }

        [Test]
        public static void CalculateIntersect_FourPointsOfIntersect_ShouldReturnExpectedValues()
        {
            //Arrange
            var sut = new RectangleIntersectCalculator();

            //Act
            Intersect result = sut.CalculateIntersect(fourPointsOfintersect.Item1, fourPointsOfintersect.Item2);
            Intersect invertedResult = sut.CalculateIntersect(fourPointsOfintersect.Item2, fourPointsOfintersect.Item1);

            //Assert
            result.IsIntersecting.Should().BeTrue();
            result.PointOfIntersect1.Should().Be(new System.Drawing.Point(8, 8));
            result.PointOfIntersect2.Should().Be(new System.Drawing.Point(9, 8));
            result.PointOfIntersect3.Should().Be(new System.Drawing.Point(8, 6));
            result.PointOfIntersect4.Should().Be(new System.Drawing.Point(9, 6));
            invertedResult.IsIntersecting.Should().BeTrue();
            invertedResult.PointOfIntersect1.Should().Be(new System.Drawing.Point(8, 8));
            invertedResult.PointOfIntersect2.Should().Be(new System.Drawing.Point(9, 8));
            invertedResult.PointOfIntersect3.Should().Be(new System.Drawing.Point(8, 6));
            invertedResult.PointOfIntersect4.Should().Be(new System.Drawing.Point(9, 6));
        }

        [Test]
        public static void CalculateIntersect_BottomRightOrTopLeftIntersect_ShouldReturnExpectedValues()
        {
            //Arrange
            var sut = new RectangleIntersectCalculator();

            //Act
            Intersect result = sut.CalculateIntersect(bottomRightOrTopLeftIntersect.Item1, bottomRightOrTopLeftIntersect.Item2);
            Intersect invertedResult = sut.CalculateIntersect(bottomRightOrTopLeftIntersect.Item2, bottomRightOrTopLeftIntersect.Item1);

            //Assert
            result.IsIntersecting.Should().BeTrue();
            result.PointOfIntersect1.Should().Be(new System.Drawing.Point(10, 7));
            result.PointOfIntersect2.Should().Be(new System.Drawing.Point(9, 6));
            invertedResult.IsIntersecting.Should().BeTrue();
            invertedResult.PointOfIntersect1.Should().Be(new System.Drawing.Point(10, 7));
            invertedResult.PointOfIntersect2.Should().Be(new System.Drawing.Point(9, 6));
        }

        [Test]
        public static void CalculateIntersect_BottomLeftOrTopRightIntersect_ShouldReturnExpectedValues()
        {
            //Arrange
            var sut = new RectangleIntersectCalculator();

            //Act
            Intersect result = sut.CalculateIntersect(bottomLeftOrTopRightIntersect.Item1, bottomLeftOrTopRightIntersect.Item2);
            Intersect invertedResult = sut.CalculateIntersect(bottomLeftOrTopRightIntersect.Item2, bottomLeftOrTopRightIntersect.Item1);

            //Assert
            result.IsIntersecting.Should().BeTrue();
            result.PointOfIntersect1.Should().Be(new System.Drawing.Point(7, 8));
            result.PointOfIntersect2.Should().Be(new System.Drawing.Point(6, 7));
            invertedResult.IsIntersecting.Should().BeTrue();
            invertedResult.PointOfIntersect1.Should().Be(new System.Drawing.Point(7, 8));
            invertedResult.PointOfIntersect2.Should().Be(new System.Drawing.Point(6, 7));
        }

        [Test]
        public static void CalculateIntersect_LeftIntersect_ShouldReturnExpectedValues()
        {
            //Arrange
            var sut = new RectangleIntersectCalculator();

            //Act
            Intersect result = sut.CalculateIntersect(leftIntersect.Item1, leftIntersect.Item2);
            Intersect invertedResult = sut.CalculateIntersect(leftIntersect.Item2, leftIntersect.Item1);

            //Assert
            result.IsIntersecting.Should().BeTrue();
            result.PointOfIntersect1.Should().Be(new System.Drawing.Point(4, 4));
            result.PointOfIntersect2.Should().Be(new System.Drawing.Point(4, 2));
            invertedResult.IsIntersecting.Should().BeTrue();
            invertedResult.PointOfIntersect1.Should().Be(new System.Drawing.Point(4, 4));
            invertedResult.PointOfIntersect2.Should().Be(new System.Drawing.Point(4, 2));
        }

        [Test]
        public static void CalculateIntersect_RightIntersect_ShouldReturnExpectedValues()
        {
            //Arrange
            var sut = new RectangleIntersectCalculator();

            //Act
            Intersect result = sut.CalculateIntersect(rightIntersect.Item1, rightIntersect.Item2);
            Intersect invertedResult = sut.CalculateIntersect(rightIntersect.Item2, rightIntersect.Item1);

            //Assert
            result.IsIntersecting.Should().BeTrue();
            result.PointOfIntersect1.Should().Be(new System.Drawing.Point(6, 4));
            result.PointOfIntersect2.Should().Be(new System.Drawing.Point(6, 2));
            invertedResult.IsIntersecting.Should().BeTrue();
            invertedResult.PointOfIntersect1.Should().Be(new System.Drawing.Point(6, 4));
            invertedResult.PointOfIntersect2.Should().Be(new System.Drawing.Point(6, 2));
        }

        [Test]
        public static void CalculateIntersect_NullRectangle1_ShouldThrowEx()
        {
            //Arrange
            var r2 = new Rectangle(1, 2, 3, 4);
            var sut = new RectangleIntersectCalculator();

            //Act
            Action act = () => sut.CalculateIntersect(null, r2);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public static void CalculateIntersect_NullRectangle2_ShouldThrowEx()
        {
            //Arrange
            var r1 = new Rectangle(1, 2, 3, 4);
            var sut = new RectangleIntersectCalculator();

            //Act
            Action act = () => sut.CalculateIntersect(r1, null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public static void CalculateIntersect_NullValues_ShouldThrowEx()
        {
            //Arrange            
            var sut = new RectangleIntersectCalculator();

            //Act
            Action act = () => sut.CalculateIntersect(null, null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
