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
        public double bottom { get; set; }
        public double Height { get; set; }

    }
	
	public class Triangle 
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

//An abstract computational superclass
public  abstract class  AreaCalculator
{
	public abstract double Area();

}

//Calculate the area of a rectangle
public class rectangle : AreaCalculator
{

	public double Area(object[] shapes)
	{
		Rectangle rectangle = (Rectangle) shape;
        area += rectangle.Width*rectangle.Height;
		return area

	}
}

//Calculate the area of a circle
public class circle : AreaCalculator
{
	public override double GetResult()
	{
		Circle circle = (Circle)shape;
        area += circle.Radius * circle.Radius * Math.PI;
		return area
	}
}

//Calculate the area of a circle
public class Triangle : AreaCalculator
{
	public override double GetResult()
	{
		Triangle triangle = (Triangle)shape;
        area += triangle.bottom * triangle.height / 2
		return area
	}
}


public class AreaCalculator_Iter3
{
	public double Area(object[] shapes)
	{
		double area = 0;
		foreach (var shape in shapes)
		{
			if (shape is Rectangle)
			{
				area = new Rectangle()
			}
			if (shape is Circle)
			{
				area = new Circle()
			}
			if (shape is Triangle)
			{
				area = new Triangle()
			}
		}

		return area;
	}
}

