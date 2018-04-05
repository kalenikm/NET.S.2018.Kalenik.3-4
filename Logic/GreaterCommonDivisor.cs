using System;
using System.Diagnostics;

namespace Logic
{
    public class GreaterCommonDivisor
    {
        private static int FindGcd(out TimeSpan time, Func<int, int, int> func, params int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException($"Array {nameof(array)} is empty.");

            Stopwatch watch = new Stopwatch();
            watch.Start();

            int lastGcd = NormalGcd(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                lastGcd = func(lastGcd, array[i]);

                if (lastGcd == 1)
                {
                    watch.Stop();
                    time = watch.Elapsed;
                    return 1;
                }
            }

            watch.Stop();
            time = watch.Elapsed;
            return lastGcd;
        }

        private static int FindGcd(Func<int, int, int> func, params int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException($"Array {nameof(array)} is empty.");

            int lastGcd = NormalGcd(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                lastGcd = func(lastGcd, array[i]);

                if (lastGcd == 1)
                {
                    return 1;
                }
            }

            return lastGcd;
        }

        /// <summary>
        /// Calculates greater common divisor of two numbers using the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Greater common divisor of two numbers.</returns>
        public static int NormalGcd(int a, int b)
        {
            if (a < 0) a = -a;
            if (b < 0) b = -b;

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a + b;
        }

        /// <summary>
        /// Calculates greater common divisor of two numbers using the binary Euclidean algorithm.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Greater common divisor of two numbers.</returns>
        public static int BinaryGcd(int a, int b)
        {
            if (a == 0 || b == 0)
                return a + b;
            if (a == b)
                return a;
            if (a == 1 || b == 1)
                return 1;
            if ((a & 1) == 0)
                return (b & 1) == 0 ? BinaryGcd(a >> 1, b >> 1) << 1 : BinaryGcd(a >> 1, b);
            else
                return (b & 1) == 0 ? BinaryGcd(a, b >> 1) : BinaryGcd(b, a > b ? a - b : b - a);
        }

        /// <summary>
        /// Calculates greater common divisor of array of numbers and time that was spent by this method.
        /// </summary>
        /// <param name="time">Output time that was spent by method.</param>
        /// <param name="array">Input array of numbers.</param>
        /// <returns>Greater common divisor of array of numbers.</returns>
        public static int NormalGcd(out TimeSpan time, params int[] array)
        {
            return FindGcd(out time, NormalGcd, array);
        }

        /// <summary>
        /// Calculates greater common divisor of array of numbers.
        /// </summary>
        /// <param name="array">Numbers.</param>
        /// <returns>Greater common divisor of array of numbers.</returns>
        public static int NormalGcd(params int[] array)
        {
            return FindGcd(NormalGcd, array);
        }

        /// <summary>
        /// Calculates greater common divisor of array of numbers and time that was spent by this method.
        /// </summary>
        /// <param name="time">Output time that was spent by method.</param>
        /// <param name="array">Input array of numbers.</param>
        /// <returns>Greater common divisor of array of numbers.</returns>
        public static int BinaryGcd(out TimeSpan time, params int[] array)
        {
            return FindGcd(out time, NormalGcd, array);
        }

        /// <summary>
        /// Calculates greater common divisor of array of numbers.
        /// </summary>
        /// <param name="array">Numbers.</param>
        /// <returns>Greater common divisor of array of numbers.</returns>
        public static int BinaryGcd(params int[] array)
        {
            return FindGcd(NormalGcd, array);
        }
    }
}
