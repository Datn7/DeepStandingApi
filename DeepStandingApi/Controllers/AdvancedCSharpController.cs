using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DeepStandingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvancedController : ControllerBase
    {
        public class Example
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Code { get; set; }
            public string Output { get; set; }
        }

        [HttpGet("{topic}")]
        public IActionResult Get(string topic)
        {
            var ex = topic.ToLower() switch
            {
                // Part 1 – Basic C#
                "hello" => new Example
                {
                    Title = "Hello World",
                    Description = "Your first C# program.",
                    Code = @"using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(""Hello, World!"");
    }
}",
                    Output = "Hello, World!"
                },

                "datatype" => new Example
                {
                    Title = "Data Types",
                    Description = "Value and reference types in C#.",
                    Code = @"int number = 10;         // Value type
string name = ""Alice"";   // Reference type",
                    Output = "number = 10, name = Alice"
                },

                // Part 2 – OOP
                "class" => new Example
                {
                    Title = "Class and Object",
                    Description = "Defines a simple class and instantiates it.",
                    Code = @"public class Car
{
    public string Model;

    public Car(string model)
    {
        Model = model;
    }
}

var car = new Car(""Tesla"");
Console.WriteLine(car.Model);",
                    Output = "Tesla"
                },

                "inheritance" => new Example
                {
                    Title = "Inheritance",
                    Description = "Derived class overriding base method.",
                    Code = @"public class Animal
{
    public virtual void Speak() => Console.WriteLine(""..."");
}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine(""Bark"");
}

var dog = new Dog();
dog.Speak();",
                    Output = "Bark"
                },

                // Part 3 – Intermediate C#
                "exception" => new Example
                {
                    Title = "Exception Handling",
                    Description = "Using try-catch-finally in C#.",
                    Code = @"try
{
    int x = int.Parse(""abc"");
}
catch (FormatException)
{
    Console.WriteLine(""Invalid input."");
}
finally
{
    Console.WriteLine(""Done."");
}",
                    Output = "Invalid input.\nDone."
                },

                "delegate" => new Example
                {
                    Title = "Delegate and Lambda",
                    Description = "Anonymous methods using delegates.",
                    Code = @"delegate void Greet(string name);
Greet g = name => Console.WriteLine($""Hello, {name}"");
g(""David"");",
                    Output = "Hello, David"
                },

                "linq" => new Example
                {
                    Title = "LINQ Where",
                    Description = "Filtering even numbers using LINQ.",
                    Code = @"var nums = new List<int> { 1, 2, 3, 4 };
var evens = nums.Where(n => n % 2 == 0);
Console.WriteLine(string.Join("", "", evens));",
                    Output = "2, 4"
                },

                // Part 4 – Advanced C#
                "extension" => new Example
                {
                    Title = "Extension Method",
                    Description = "Adds method to existing type.",
                    Code = @"public static class StringExtensions
{
    public static string Shout(this string str) => str.ToUpper() + ""!"";
}

Console.WriteLine(""hello"".Shout());",
                    Output = "HELLO!"
                },

                "record" => new Example
                {
                    Title = "Record Type",
                    Description = "Immutable data structure using records.",
                    Code = @"public record User(string Name, int Age);
var u1 = new User(""Tom"", 30);
var u2 = u1 with { Name = ""Bob"" };
Console.WriteLine(u2);",
                    Output = "User { Name = Bob, Age = 30 }"
                },

                "reflection" => new Example
                {
                    Title = "Reflection",
                    Description = "Get method info and invoke at runtime.",
                    Code = @"Type t = typeof(string);
var method = t.GetMethod(""ToUpper"", Type.EmptyTypes);
Console.WriteLine(method?.Invoke(""hello"", null));",
                    Output = "HELLO"
                },

                "parallel" => new Example
                {
                    Title = "Parallel.For",
                    Description = "Execute a loop in parallel.",
                    Code = @"Parallel.For(0, 3, i => Console.WriteLine($""Task {i}""));",
                    Output = "Task 0\nTask 1\nTask 2 (order may vary)"
                },

                "singleton" => new Example
                {
                    Title = "Singleton Pattern",
                    Description = "Ensures only one instance is created.",
                    Code = @"public sealed class Singleton
{
    private static Singleton? _instance;
    private static readonly object _lock = new();
    private Singleton() {}

    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance ??= new Singleton();
            }
        }
    }

    public string Greet() => ""Hello!"";
}

Console.WriteLine(Singleton.Instance.Greet());",
                    Output = "Hello!"
                },

                _ => null
            };

            return ex is null ? NotFound("Topic not found.") : Ok(ex);
        }
    }
}
