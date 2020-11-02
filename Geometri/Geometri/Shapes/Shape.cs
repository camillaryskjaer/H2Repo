using Geometri.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.Shapes
{
    public abstract class Shape : ICalculateArea, ICalculateCircumference
    {
        public abstract double CalculateArea();
        public abstract double CalculateCircumference();
    }
}
