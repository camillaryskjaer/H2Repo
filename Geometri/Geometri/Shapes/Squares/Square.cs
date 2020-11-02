using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.Shapes.Squares
{
    public class Square : Shape
    {
        private double _sideA;

        public Square(double SideA)
        {
            _sideA = SideA;
        }

        public override double CalculateArea()
        {
            return _sideA * _sideA;
        }

        public override double CalculateCircumference()
        {
            return _sideA * 4;
        }
    }
}
