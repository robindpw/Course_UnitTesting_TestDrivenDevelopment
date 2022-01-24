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
            if (input == '+')
            {
                _currentOperation = OperationEnum.Plus;
                Formula = $"{Display} +";
                _previousOperand = Display;
                _canSetNewOperand = true;
            }
            else if (input == '=')
            {
                switch (_currentOperation)
                {
                    case OperationEnum.Plus:
                        Display = _previousOperand + Display;
                        break;
                }
                Formula = string.Empty;
            }
            else
            {
                int digit = int.Parse(input.ToString());
                if (_canSetNewOperand)
                {
                    Display = digit;
                    _canSetNewOperand = false;
                }
                else
                {
                    Display = Display * 10 + int.Parse(input.ToString());
                }
            }
        }
    }

    internal enum OperationEnum
    {
        Plus
    }
}