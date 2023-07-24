using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Circle.Test
{
    public class CircleTests
    {
        [Fact]
        public void Circle_CircleNoParem_ReturnString()
        {
            // Arrange
            Circle cir = new Circle();

            // Act
            string result = cir.ToString();

            // Assert
            result.Should().Match("A Circle with radius = * and color *");
            result.Should().Contain("yellow");
        }

        [Fact]
        public void Circle_CircleWithParem_ReturnString()
        {
            // Arrange
            Circle cir = new Circle(5.0, "red");

            // Act
            string result = cir.ToString();

            // Assert
            result.Should().Match("A Circle with radius = 5 and color red");
        }


        [Fact]
        public void Circle_GetArea_ReturnDouble()
        {
            // Arrange
            Circle cir = new Circle();
            Circle cir1 = new Circle(5.0, "red");

            // Act
            double result = cir.GetArea();
            double result1 = cir1.GetArea();

            // Assert
            result.Should().BeGreaterThanOrEqualTo(Math.PI * 1);
            result1.Should().BeGreaterThanOrEqualTo(Math.PI * 5 * 5);
        }

        [Fact]
        public void Cylinder_CylinderNoParem_ReturnString()
        {
            // Arrange
            Cylinder cy = new Cylinder(5.0f);
            Cylinder cy1 = new Cylinder(3.0f, 4.0f, "red");

            // Act
            string result = cy.ToString();
            string result1 = cy1.ToString();

            // Assert
            result.Should().Match("A Cylinder with height = 5 and a subclass of A Circle with radius = 1 and color yellow");
            result1.Should().Match("A Cylinder with height = 3 and a subclass of A Circle with radius = 4 and color red");
        }

        [Fact]
        public void Cylinder_GetVolumn_ReturnDouble()
        {
            // Arrange
            Cylinder cy = new Cylinder();
            Cylinder cy1 = new Cylinder(5.0f);
            Cylinder cy2 = new Cylinder(3.0f, 4.0f, "red");

            // Act
            double result = cy.GetVolumn();
            double result1 = cy1.GetVolumn();
            double result2 = cy2.GetVolumn();

            // Assert
            result.Should().BeGreaterThanOrEqualTo(Math.PI * 1);
            result1.Should().BeGreaterThanOrEqualTo(Math.PI * 1 * 1 * 5);
            result2.Should().BeGreaterThanOrEqualTo(Math.PI * 4 * 4 * 3);
        }

    }
}
