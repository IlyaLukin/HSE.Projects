using System;
using System.Collections.Generic;

namespace SQAT.XP
{
    /// <summary>
    /// Class for calculation functions
    ///     1. PressEnter: calculate;
    ///     2. PressDisplay: insert value;
    ///     3. PressPlus: a + b;
    ///     4. PressMinus: a - b;
    ///     5. PressMultiply: a*b;
    ///     6. PressDivide: a/b;
    ///     7. private Calculate: calculate 
    /// </summary>
    public class Calculator
    {
        // Last inserted value
        private readonly List<double> _insertedValues = new List<double>();
        // Current operation
        private readonly List<string> _operations = new List<string>();

        /// <summary>
        /// Displayed value
        /// </summary>
        public double Display { get; set; }

        /// <summary>
        /// Insert value
        /// </summary>
        /// <param name="value">Inserted value</param>
        public void PressDisplay(double value)
        {
            _insertedValues.Add(value);
        }

        #region Calculation functions

        /// <summary>
        /// a + b
        /// </summary>
        public void PressPlus() {
            _operations.Add("+");
        }

        /// <summary>
        /// a - b
        /// </summary>
        public void PressMinus()
        {
            _operations.Add("-");
        }

        /// <summary>
        /// a * b
        /// </summary>
        public void PressMultiply()
        {
            _operations.Add("*");
        }

        /// <summary>
        /// a - b
        /// </summary>
        public void PressDivide()
        {
            _operations.Add("/");
        }

        #endregion

        #region Calculation

        /// <summary>
        /// Calculate
        /// </summary>
        public void PressEnter() {
            Calculate();
        }

        /// <summary>
        /// Identify type of the operation
        /// </summary>
        private void Calculate() {
            var i = 0;
            var tryFindMd = true;
            while (true) {
                tryFindMd &= i != _operations.Count;
                if (i == _operations.Count) {
                    i = 0;
                }

                if (_insertedValues.Count == 1) {
                    Display = _insertedValues[0];
                    _insertedValues.Clear();
                    return;
                }

                switch (_operations[i]) {
                    case "*":
                        _insertedValues[i] *= _insertedValues[i + 1];
                        _insertedValues.RemoveAt(i +1);
                        _operations.RemoveAt(i);
                        continue;
                    case "/":
                        if (_insertedValues[i + 1].Equals(0)) throw new DivideByZeroException();
                        _insertedValues[i] /= _insertedValues[i + 1];
                        _insertedValues.RemoveAt(i + 1);
                        _operations.RemoveAt(i);
                        continue;
                    case "+":
                        if (tryFindMd) break;
                        _insertedValues[i] += _insertedValues[i + 1];
                        _insertedValues.RemoveAt(i + 1);
                        _operations.RemoveAt(i);
                        continue;
                    case "-":
                        if (tryFindMd) break;
                        _insertedValues[i] -= _insertedValues[i + 1];
                        _insertedValues.RemoveAt(i + 1);
                        _operations.RemoveAt(i);
                        continue;
                    default:
                        continue;
                }

                i += 1;
            }
        }

        #endregion
    }
}