using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    abstract public class Shape
    {
        public abstract double Area();
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double r)
        {
            radius = r;
        }

        public override double Area()
        {
            return 3.14 * radius * radius;
        }

    }

    public class Rectangle : Shape
    {
        private double Length;
        private double Breadth;

        public Rectangle(double l, double b)
        {
            Length = l;
            Breadth = b;
        }

        public override double Area()
        {
            return Length * Breadth;
        }
    }
}
