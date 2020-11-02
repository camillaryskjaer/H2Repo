using Geometri.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.Shapes.Squares
{
    class Trapez : Shape, ICalculateArea
    {
        private double _sideA;
        private double _sideb;
        private double _sideC;
        private double _sideD;
        private double _height;

        public Trapez(double SideA, double SideB, double SideC, double SideD)
        {
            _sideA = SideA;
            _sideb = SideB;
            _sideC = SideC;
            _sideD = SideD;
            CalculateHeight();
        }

        private void CalculateHeight()
        {
            double middleCalculation = (_sideA + _sideb - _sideC - _sideD) / 2;
            _height = (2 / (_sideA - _sideC)) * Math.Sqrt(middleCalculation * (middleCalculation - _sideA + _sideC) * (middleCalculation - _sideb) * (middleCalculation - _sideD));
        }

        public override double CalculateArea()
        {
            return 0.5 * (_sideA + _sideb) * _height;
        }

        public override double CalculateCircumference()
        {
            return _sideA + _sideb + _sideC + _sideD;
        }
    }
}
