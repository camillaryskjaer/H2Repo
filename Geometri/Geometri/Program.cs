using Geometri.Shapes;
using Geometri.Shapes.Squares;
using Geometri.Shapes.Triangles;
using System;
using System.Collections.Generic;

namespace Geometri
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Parallelogram parallelogram = new Parallelogram(5, 10, 18);
            Rectangle rectangle = new Rectangle(5, 8);
            Square square = new Square(10);
            Trapez trapez = new Trapez(2, 4, 3, 5);
            RectangularTriangle triangle = new RectangularTriangle(8, 6);

            shapes.Add(parallelogram);
            shapes.Add(rectangle);
            shapes.Add(square);
            shapes.Add(trapez);
            shapes.Add(triangle);

            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Type:");
                Console.WriteLine(shape.GetType());
                Console.WriteLine("Area:");
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine("Circumference:");
                Console.WriteLine(shape.CalculateCircumference());
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
