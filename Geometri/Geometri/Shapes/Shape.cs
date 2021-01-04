using Geometri.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.Shapes
{//Hvorfor bruge en abstraktklasse som ikke gør noget? Det kunne du have klaret med et interface i stedet
    public abstract class Shape : ICalculateArea, ICalculateCircumference
    {
        public abstract double CalculateArea();
        public abstract double CalculateCircumference();
    }
}
