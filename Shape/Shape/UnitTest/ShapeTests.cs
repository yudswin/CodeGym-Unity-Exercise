using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shape
{
    public class ShapeTests
    {

        [Theory]
        [InlineData("red", true)]
        [InlineData("blue", false)]
        public void Shape_ToString_ReturnString(string c, bool f)
        {
            // Arrange 
            List<Shape> arts = new List<Shape>
            {
                new Shape(),
                new Shape(c, f)
            };

            foreach (Shape shape in arts)
            {
                // Act
                string result = shape.ToString();

                // Assert
                result.Should().Match("A Shape with color of * and *");
                result.Should().ContainAny("filled", "not filled");
                result.Should().ContainAny("green", "red", "blue");
            }
        }

        [Theory]
        [InlineData(5.0f, 3.0f, "red", false)]
        [InlineData(3.0f, 9.0f, "blue", false)]
        public void Rectangle_ToString_ReturnString(double w, double l, string c, bool f)
        {
            // Arrange
            List<Rectangle> arts = new List<Rectangle>
            {
                new Rectangle(),
                new Rectangle(w, l),
                new Rectangle(w, l, c, f)
            };

            foreach (Rectangle rec in arts)
            {
                // Act
                string result = rec.ToString();

                // Assert
                result.Should().Match("A Rectangle with width = *, height = *, which is subclass of A Shape with color of * and *");
                result.Should().ContainAny("filled", "not filled");
                result.Should().ContainAny("green", "red", "blue");
            }
        }

        [Theory]
        [InlineData(5.0f, 3.0f, "red", false)]
        [InlineData(3.0f, 9.0f, "blue", false)]
        public void Rectangle_GetArea_ReturnDouble(double w, double l, string c, bool f)
        {
            // Arrange
            List<Rectangle> arts = new List<Rectangle>
            {
                new Rectangle(),
                new Rectangle(w, l),
                new Rectangle(w, l, c, f)
            };

            foreach (Rectangle rec in arts)
            {
                // Act
                double result = rec.GetArea();

                // Assert
                result.Should().BeGreaterThanOrEqualTo(rec.Width * rec.Length);
            }
        }

        [Theory]
        [InlineData(5.0f, 3.0f, "red", false)]
        [InlineData(3.0f, 9.0f, "blue", false)]
        public void Rectangle_GetPerimeter_ReturnDouble(double w, double l, string c, bool f)
        {
            // Arrange
            List<Rectangle> arts = new List<Rectangle>
            {
                new Rectangle(),
                new Rectangle(w, l),
                new Rectangle(w, l, c, f)
            };

            foreach (Rectangle rec in arts)
            {
                // Act
                double result = rec.GetPerimeter();

                // Assert
                result.Should().BeGreaterThanOrEqualTo((rec.Width + rec.Length) * 2);
            }
        }

        [Theory]
        [InlineData(5.0f, "red", false)]
        [InlineData(9.0f, "blue", false)]
        public void Circle_GetArea_ReturnDouble(double r, string c, bool f)
        {
            // Arrange
            List<Circle> arts = new List<Circle>
            {
                new Circle(),
                new Circle(r),
                new Circle(r, c, f)
            };

            foreach (Circle cir in arts)
            {
                // Act
                double result = cir.GetArea();

                // Assert
                result.Should().BeGreaterThanOrEqualTo(Math.PI * cir.Radius * cir.Radius);
            }
        }

        [Theory]
        [InlineData(5.0f, "red", false)]
        [InlineData(9.0f, "blue", false)]
        public void Circle_GetPerimeter_ReturnDouble(double r, string c, bool f)
        {
            // Arrange
            List<Circle> arts = new List<Circle>
            {
                new Circle(),
                new Circle(r),
                new Circle(r, c, f)
            };

            foreach (Circle cir in arts)
            {
                // Act
                double result = cir.GetPerimeter();

                // Assert
                result.Should().BeGreaterThanOrEqualTo(Math.PI * cir.Radius * 2);
            }
        }

        [Theory]
        [InlineData(5.0f, "red", false)]
        [InlineData(9.0f, "blue", false)]
        public void Circle_ToString_ReturnString(double r, string c, bool f)
        {
            // Arrange
            List<Circle> arts = new List<Circle>
            {
                new Circle(),
                new Circle(r),
                new Circle(r, c, f)
            };

            foreach (Circle cir in arts)
            {
                // Act
                string result = cir.ToString();

                // Assert
                result.Should().Match("A Circle with radius = *, which is subclass of *");
                result.Should().ContainAny("filled", "not filled");
                result.Should().ContainAny("green", "red", "blue");
            }
        }


        [Theory]
        [InlineData(1.0f, "red", false)]
        [InlineData(6.0f, "blue", true)]
        public void Square_ToString_ReturnString(double s, string c, bool f)
        {
            // Arrange
            List<Square> arts = new List<Square>
            {
                new Square(),
                new Square(s),
                new Square(s, c, f)
            };

            foreach (Square squ in arts)
            {
                // Act
                string result = squ.ToString();

                // Assert
                result.Should().Match("A Square with side = *, which is a subclass of A Rectangle with width = *, height = *, which is subclass of A Shape with color of * and *");
                result.Should().ContainAny("filled", "not filled");
                result.Should().ContainAny("green", "red", "blue");
            }
        }
    }
}
