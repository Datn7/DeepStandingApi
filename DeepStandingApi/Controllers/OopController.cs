using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OopController : ControllerBase
{
    [HttpGet("classes")]
    public IActionResult GetClasses()
    {
        var examples = new[]
        {
            new {
                title = "Defining a Class with Constructor",
                code = @"public class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

var p = new Person(""Alice"", 30);
Console.WriteLine(p.Name);",
                output = "Alice",
                color = "green"
            },
            new {
                title = "Using 'this' Keyword",
                code = @"public class Car
{
    private string brand;

    public Car(string brand)
    {
        this.brand = brand;
    }

    public void ShowBrand()
    {
        Console.WriteLine(this.brand);
    }
}

var c = new Car(""Toyota"");
c.ShowBrand();",
                output = "Toyota",
                color = "blue"
            }
        };
        return Ok(examples);
    }

    [HttpGet("encapsulation")]
    public IActionResult GetEncapsulation()
    {
        var examples = new[]
        {
            new {
                title = "Using Private Field with Property",
                code = @"public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set { if (value >= 0) balance = value; }
    }
}

var acc = new BankAccount();
acc.Balance = 100.5m;
Console.WriteLine(acc.Balance);",
                output = "100.5",
                color = "purple"
            },
            new {
                title = "Protected Field in Base Class",
                code = @"public class Animal
{
    protected string name = ""Dog"";
}

public class Pet : Animal
{
    public void ShowName()
    {
        Console.WriteLine(name);
    }
}

var pet = new Pet();
pet.ShowName();",
                output = "Dog",
                color = "orange"
            }
        };
        return Ok(examples);
    }

    [HttpGet("inheritance")]
    public IActionResult GetInheritance()
    {
        var examples = new[]
        {
            new {
                title = "Base and Derived Class",
                code = @"public class Animal
{
    public void Speak() => Console.WriteLine(""Animal speaks"");
}

public class Dog : Animal {}

var d = new Dog();
d.Speak();",
                output = "Animal speaks",
                color = "green"
            },
            new {
                title = "Method Overriding",
                code = @"public class Animal
{
    public virtual void Speak() => Console.WriteLine(""Animal"");
}

public class Cat : Animal
{
    public override void Speak() => Console.WriteLine(""Meow"");
}

var cat = new Cat();
cat.Speak();",
                output = "Meow",
                color = "blue"
            }
        };
        return Ok(examples);
    }

    [HttpGet("polymorphism")]
    public IActionResult GetPolymorphism()
    {
        var examples = new[]
        {
            new {
                title = "Method Overloading",
                code = @"public class MathUtils
{
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
}

var m = new MathUtils();
Console.WriteLine(m.Add(2, 3));
Console.WriteLine(m.Add(2.5, 3.5));",
                output = "5\n6.0",
                color = "purple"
            },
            new {
                title = "Interface Polymorphism",
                code = @"public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw() => Console.WriteLine(""Drawing circle"");
}

IShape shape = new Circle();
shape.Draw();",
                output = "Drawing circle",
                color = "orange"
            }
        };
        return Ok(examples);
    }

    [HttpGet("abstraction")]
    public IActionResult GetAbstraction()
    {
        var examples = new[]
        {
            new {
                title = "Abstract Class and Method",
                code = @"public abstract class Animal
{
    public abstract void MakeSound();
}

public class Dog : Animal
{
    public override void MakeSound() => Console.WriteLine(""Bark"");
}

var d = new Dog();
d.MakeSound();",
                output = "Bark",
                color = "blue"
            },
            new {
                title = "Interface Abstraction",
                code = @"public interface IPrinter
{
    void Print();
}

public class LaserPrinter : IPrinter
{
    public void Print() => Console.WriteLine(""Printing..."");
}

var printer = new LaserPrinter();
printer.Print();",
                output = "Printing...",
                color = "green"
            }
        };
        return Ok(examples);
    }

    [HttpGet("interfaces")]
    public IActionResult GetInterfaces()
    {
        var examples = new[]
        {
            new {
                title = "Explicit Interface Implementation",
                code = @"public interface ILogger
{
    void Log();
}

public class FileLogger : ILogger
{
    void ILogger.Log()
    {
        Console.WriteLine(""File logged"");
    }
}

ILogger logger = new FileLogger();
logger.Log();",
                output = "File logged",
                color = "green"
            }
        };
        return Ok(examples);
    }

    [HttpGet("enums")]
    public IActionResult GetEnums()
    {
        var examples = new[]
        {
            new {
                title = "Using Enums",
                code = @"enum Direction { North, South, East, West }

Direction dir = Direction.North;
Console.WriteLine(dir);",
                output = "North",
                color = "purple"
            }
        };
        return Ok(examples);
    }

    [HttpGet("structs")]
    public IActionResult GetStructs()
    {
        var examples = new[]
        {
            new {
                title = "Struct vs Class",
                code = @"struct Point
{
    public int X;
    public int Y;
}

Point p = new Point { X = 1, Y = 2 };
Console.WriteLine(p.X);",
                output = "1",
                color = "orange"
            }
        };
        return Ok(examples);
    }

    [HttpGet("static")]
    public IActionResult GetStaticMembers()
    {
        var examples = new[]
        {
            new {
                title = "Static Class and Method",
                code = @"public static class Utils
{
    public static void SayHi() => Console.WriteLine(""Hi!"");
}

Utils.SayHi();",
                output = "Hi!",
                color = "blue"
            },
            new {
                title = "Static Field",
                code = @"public class Counter
{
    public static int Count = 0;
}

Console.WriteLine(Counter.Count);",
                output = "0",
                color = "green"
            }
        };
        return Ok(examples);
    }
}
