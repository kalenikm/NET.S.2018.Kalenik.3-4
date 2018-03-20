using System;
using System.Text;

namespace Logic
{
    public static class BinaryConverter
    {
        /// <summary>
        /// Convert double to binary string.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns>Returns binary string.</returns>
        public static string DoubleToBinary(this double number)
        {
            #region CheckConst

            if (Double.IsNaN(number))
                return "1111111111111000000000000000000000000000000000000000000000000000";

            if (Double.IsNegativeInfinity(number))
                return "1111111111110000000000000000000000000000000000000000000000000000";

            if (Double.IsPositiveInfinity(number))
                return "0111111111110000000000000000000000000000000000000000000000000000";

            if (Double.MaxValue.Equals(number))
                return "0111111111101111111111111111111111111111111111111111111111111111";

            if (Double.MinValue.Equals(number))
                return "1111111111101111111111111111111111111111111111111111111111111111";

            if (Double.Epsilon.Equals(number))
                return "0000000000000000000000000000000000000000000000000000000000000001";

            #endregion

            #region Sign

            int sign;
            if (number.Equals(0.0))
                sign = Double.IsNegativeInfinity(1.0 / number) ? 1 : 0;
            else
                sign = number >= 0 ? 0 : 1;

            #endregion

            double num = 0.0;

            if (number.Equals(0.0))
                return sign + new string('0', 63);

            number = Math.Abs(number);
            var pow = number < 1 ? 0 : (long)Math.Log((long)number, 2);
            var powBuff = pow;
            StringBuilder str = new StringBuilder(64);
            while (number - num >= Math.Pow(2, -51))
            {
                if (num + Math.Pow(2, pow) <= number)
                {
                    num += Math.Pow(2, pow);
                    str.Append("1");
                }
                else
                    str.Append("0");
                --pow;
            }
            string result = str.ToString();
            result = sign + LongToBinary(1023 + powBuff) + result.Substring(result.IndexOf("1") + 1);
            return result + new string('0', 64 - result.Length);
        }

        /// <summary>
        /// Convert long to binary string.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns>Returns binary string.</returns>
        public static string LongToBinary(this long number)
        {
            var a = (long)Math.Log(number, 2);
            long m = 0;
            string result = "";
            while (a != -1)
            {
                if (Math.Pow(2, a) + m <= number)
                {
                    m += (long)Math.Pow(2, a);
                    result += "1";
                }
                else
                {
                    result += "0";
                }
                a--;
            }
            return result;
        }
    }
}