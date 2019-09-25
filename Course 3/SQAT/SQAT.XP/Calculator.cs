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
        private double        _currentValue = 0;
        // Current operation
        private string        _operation    = "=";

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
            _currentValue = value;
        }

        #region Calculation functions

        /// <summary>
        /// a + b
        /// </summary>
        public void PressPlus()
        {

        }

        /// <summary>
        /// a - b
        /// </summary>
        public void PressMinus()
        {

        }

        /// <summary>
        /// a * b
        /// </summary>
        public void PressMultiply()
        {

        }

        /// <summary>
        /// a - b
        /// </summary>
        public void PressDivide()
        {

        }

        #endregion

        #region Calculation

        /// <summary>
        /// Calculate
        /// </summary>
        public void PressEnter()
        {
            Calculate();
            _operation = "=";
        }

        /// <summary>
        /// Identify type of the operation
        /// </summary>
        private static void Calculate()
        {

        }

        #endregion
    }
}