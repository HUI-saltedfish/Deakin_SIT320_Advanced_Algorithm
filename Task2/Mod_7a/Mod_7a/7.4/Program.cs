using System;

namespace _7._4
{
    public class Rectangle 
        {
        public double Width { get; set; }
        public double Height { get; set; }

    }

    public class Circle 
        {
        public double Radius { get; set; }

    }

    public class AreaCalculator
    {
        public double Area(Rectangle[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Width*shape.Height;
            }

            return area;
        }
    }

    public class AreaCalculator_Iter2
    {
        public double Area(object[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle) shape;
                    area += rectangle.Width*rectangle.Height;
                }
                else
                {
                    Circle circle = (Circle)shape;
                    area += circle.Radius * circle.Radius * Math.PI;
                }
            }

            return area;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
