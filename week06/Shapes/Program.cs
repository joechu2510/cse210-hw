using System;

class Program
{
    static void Main(string[] args)
    {
        // Square example1 = new Square("red", 2);
        // Console.WriteLine($"Your color is {example1.GetColor()}");
        // Console.WriteLine($"The area is {example1.GetArea()}");

        // Rectangle example2 = new Rectangle("blue", 3.2, 4.5);
        // Console.WriteLine($"Color: {example2.GetColor()}");
        // Console.WriteLine($"Area: {example2.GetArea()}");

        // Circle example3 = new Circle("yellow", 5);
        // Console.WriteLine($"Color: {example3.GetColor()}");
        // Console.WriteLine($"Radius: {example3.GetArea()}");

        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Red", 2);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 2, 3);
        shapes.Add(s2);

        Circle s3 = new Circle("Yellow", 6);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}