using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Domain
{
    public class Calculator
    {
        public double Display { get; private set; }
        public string Formula { get; private set; }

        private bool _canSetNewOperand = true;
        private OperationEnum _currentOperation;
        private double _previousOperand;

        public void Handle(char input)
        {
          
        }
    }

    internal enum OperationEnum
    {
        Plus
    }
}