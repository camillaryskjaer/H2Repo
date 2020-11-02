using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.Shapes.Squares
{
    public class Rectangle : Shape
    {
        private double _sideA;
        private double _sideB;

        public Rectangle(double SideA, double SideB)
        {
            _sideA = SideA;
            _sideB = SideB;
        }

        public override double CalculateArea()
        {
            return _sideA * _sideB;
        }

        public override double CalculateCircumference()
        {
            return (_sideA * 2) + (_sideB * 2);
        }
    }
}
