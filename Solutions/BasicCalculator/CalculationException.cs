using System;

namespace BasicCalculator
{
    public class CalculationException : Exception
    {
        public CalculationException(string message) : base(message)
        {
        }
    }
}