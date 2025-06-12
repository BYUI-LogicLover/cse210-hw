using System;
using System.Collections.Generic;
using Shapes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Testing individual shapes:");

        Square square = new Square("Red", 5);
        Console.WriteLine($"Square - Color: {square.GetColor()}, Area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle - Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");

        Circle circle = new Circle("Green", 3);
        Console.WriteLine($"Circle - Color: {circle.GetColor()}, Area: {circle.GetArea():F2}");

        Console.WriteLine("\nTesting with List<Shape>:");

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Yellow", 4));
        shapes.Add(new Rectangle("Purple", 3, 7));
        shapes.Add(new Circle("Orange", 2.5));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape - Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}