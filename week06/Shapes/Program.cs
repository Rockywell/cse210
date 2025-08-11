using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.\n");

        Square square = new Square("Red", 3);
       
        square.GetColor();
        square.GetArea();

        Rectangle rectangle = new Rectangle("Blue", 4, 5);

        Circle circle = new Circle("Green", 6);

        List<Shape> shapes = new List<Shape> { square, rectangle, circle };

        shapes.ForEach(shape => {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}.");
        });

    }
}