using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.Shapes.Squares
{
    class Parallelogram : Shape
    {
        private double _sideA;
        private double _sideB;
        private double _angle;

        public Parallelogram(double SideA, double SideB, double Angle)
        {
            _sideA = SideA;
            _sideB = SideB;
            _angle = Angle;
        }

        public override double CalculateArea()
        {
            double result = _sideA * _sideB * Math.Sin(_angle * Math.PI / 180);
            return result;
        }

        public override double CalculateCircumference()
        {
            return (_sideA * 2) + (_sideB * 2);
        }
    }
}
