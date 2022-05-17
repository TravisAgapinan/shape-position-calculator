using FluentAssertions;
using NUnit.Framework;
using ShapePosition.Models;
using System;

namespace ShapePosition.Tests
{
    public class RectangleAdjacencyCalculatorTests
    {
        private static readonly Tuple<Rectangle, Rectangle> noAdjacency = Tuple.Create(new Rectangle(1, 5, 4, 3), new Rectangle(1, 8, 4, 6));
        private static readonly Tuple<Rectangle, Rectangle> subLineOnRightAdjacency = Tuple.Create(new Rectangle(1, 12, 4, 9), new Rectangle(4, 11, 7, 10));
        private static readonly Tuple<Rectangle, Rectangle> subLineOnLeftAdjacency = Tuple.Create(new Rectangle(1, 11, 4, 10), new Rectangle(4, 12, 7, 9));
        private static readonly Tuple<Rectangle, Rectangle> properAjacency = Tuple.Create(new Rectangle(11, 12, 4, 9), new Rectangle(4, 12, 7, 9));
        private static readonly Tuple<Rectangle, Rectangle> partialAdjacency = Tuple.Create(new Rectangle(1, 12, 4, 9), new Rectangle(4, 14, 7, 10));

        [Test]
        public static void CalculateAdjacency_NoAdjecency_ShouldReturnExpectedType()
        {
            //Arrange
            var sut = new RectangleAdjacencyCalculator();

            //Act
            Adjacency result = sut.CalculateAdjacency(noAdjacency.Item1, noAdjacency.Item2);

            //Assert
            result.IsAdjacent.Should().BeFalse();
            result.AdjacencyType.Should().Be(AdjacencyType.None);
        }

        [Test]
        public static void CalculateAdjacency_PartialAdjacency_ShouldReturnExpectedType()
        {
            //Arrange
            var sut = new RectangleAdjacencyCalculator();

            //Act
            Adjacency result = sut.CalculateAdjacency(partialAdjacency.Item1, partialAdjacency.Item2);
            Adjacency invertedResult = sut.CalculateAdjacency(partialAdjacency.Item2, partialAdjacency.Item1);

            //Assert
            result.IsAdjacent.Should().BeTrue();
            result.AdjacencyType.Should().Be(AdjacencyType.Partial);
            invertedResult.IsAdjacent.Should().BeTrue();
            invertedResult.AdjacencyType.Should().Be(AdjacencyType.Partial);
        }

        [Test]
        public static void CalculateAdjacency_ProperAdjacenc_ShouldReturnExpectedType()
        {
            //Arrange
            var sut = new RectangleAdjacencyCalculator();

            //Act
            Adjacency result = sut.CalculateAdjacency(properAjacency.Item1, properAjacency.Item2);
            Adjacency invertedResult = sut.CalculateAdjacency(properAjacency.Item2, properAjacency.Item1);

            //Assert
            result.IsAdjacent.Should().BeTrue();
            result.AdjacencyType.Should().Be(AdjacencyType.Proper);
            invertedResult.IsAdjacent.Should().BeTrue();
            invertedResult.AdjacencyType.Should().Be(AdjacencyType.Proper);
        }

        [Test]
        public static void CalculateAdjacency_SubLineAdjacencyOnRight_ShouldReturnExpectedType()
        {
            //Arrange
            var sut = new RectangleAdjacencyCalculator();

            //Act
            Adjacency result = sut.CalculateAdjacency(subLineOnRightAdjacency.Item1, subLineOnRightAdjacency.Item2);
            Adjacency invertedResult = sut.CalculateAdjacency(subLineOnRightAdjacency.Item2, subLineOnRightAdjacency.Item1);

            //Assert
            result.IsAdjacent.Should().BeTrue();
            result.AdjacencyType.Should().Be(AdjacencyType.SubLine);
            invertedResult.IsAdjacent.Should().BeTrue();
            invertedResult.AdjacencyType.Should().Be(AdjacencyType.SubLine);
        }

        [Test]
        public static void CalculateAdjacency_SubLineAdjacencyOnLeft_ShouldReturnExpectedType()
        {
            //Arrange
            var sut = new RectangleAdjacencyCalculator();

            //Act
            Adjacency result = sut.CalculateAdjacency(subLineOnLeftAdjacency.Item1, subLineOnLeftAdjacency.Item2);
            Adjacency invertedResult = sut.CalculateAdjacency(subLineOnLeftAdjacency.Item2, subLineOnLeftAdjacency.Item1);

            //Assert
            result.IsAdjacent.Should().BeTrue();
            result.AdjacencyType.Should().Be(AdjacencyType.SubLine);
            invertedResult.IsAdjacent.Should().BeTrue();
            invertedResult.AdjacencyType.Should().Be(AdjacencyType.SubLine);
        }

        [Test]
        public static void CalculateAdjacency_NullRectangle1_ShouldThrowEx()
        {
            //Arrange
            var r2 = new Rectangle(1, 2, 3, 4);
            var sut = new RectangleAdjacencyCalculator();

            //Act
            Action act = () => sut.CalculateAdjacency(null, r2);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public static void CalculateAdjacency_NullRectangle2_ShouldThrowEx()
        {
            //Arrange
            var r1 = new Rectangle(1, 2, 3, 4);
            var sut = new RectangleAdjacencyCalculator();

            //Act
            Action act = () => sut.CalculateAdjacency(r1, null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public static void CalculateAdjacency_NullValues_ShouldThrowEx()
        {
            //Arrange            
            var sut = new RectangleAdjacencyCalculator();

            //Act
            Action act = () => sut.CalculateAdjacency(null, null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
