using Microsoft.AspNetCore.Mvc;

namespace CSharpBasicsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OopController : ControllerBase
    {
        // Abstract base class (Abstraction)
        public abstract class Shape
        {
            // Encapsulation: property with public getter/setter
            public string Name { get; set; }

            // Polymorphic method
            public abstract double GetArea();
        }

        // Circle class inherits from Shape
        public class Circle : Shape
        {
            public double Radius { get; set; }

            public override double GetArea() => Math.PI * Radius * Radius;
        }

        // Square class inherits from Shape
        public class Square : Shape
        {
            public double SideLength { get; set; }

            public override double GetArea() => SideLength * SideLength;
        }

        // Endpoint that returns shape info and demonstrates all OOP principles
        [HttpGet("shapes")]
        public IActionResult GetShapes()
        {
            // Object instantiation (Object & Class concept)
            var shapes = new List<Shape>
            {
                new Circle { Name = "Circle A", Radius = 4 },
                new Square { Name = "Square A", SideLength = 5 },
                new Circle { Name = "Circle B", Radius = 2.5 }
            };

            // Polymorphism: GetArea works differently per shape
            var result = shapes.Select(shape => new
            {
                shape.Name,
                Type = shape.GetType().Name,
                Area = Math.Round(shape.GetArea(), 2)
            });

            return Ok(result);
        }
    }
}
