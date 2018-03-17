using System;
using System.Diagnostics;

namespace Logic
{
    public class GreaterCommonDivisor
    {
        /// <summary>
        /// Returns greater common divisor of two numbers using the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns></returns>
        public static int NormalGcd(int a, int b)
        {
            if(a < 0 || b < 0)
                throw new ArgumentException("Negative number.");

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
        /// Returns greater common divisor of array of numbers and time that was spent by this method.
        /// </summary>
        /// <param name="time">Output time that was spent by method.</param>
        /// <param name="array">Input array of numbers.</param>
        /// <returns></returns>
        public static int NormalGcd(out TimeSpan time, params int[] array)
        {
            if(array == null || array.Length == 0)
                throw new ArgumentException($"Array {nameof(array)} is empty.");

            Stopwatch watch = new Stopwatch();
            int[] res = new int[(array.Length + 1) / 2];
            watch.Start();
            while (array.Length != 1)
            {
                for (int i = 0; i < array.Length; i += 2)
                {
                    res[i / 2] = i + 1 < array.Length ? NormalGcd(array[i + 1], array[i]) : NormalGcd(array[i], array[i]);
                    if (res[i / 2] == 1)
                    {
                        watch.Stop();
                        time = watch.Elapsed;
                        return 1;
                    }
                }
                array = res;
                res = new int[(array.Length + 1) / 2];
            }
            watch.Stop();
            time = watch.Elapsed;
            return array[0];
        }

        /// <summary>
        /// Returns greater common divisor of array of numbers.
        /// </summary>
        /// <param name="array">Numbers.</param>
        /// <returns></returns>
        public static int NormalGcd(params int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException($"Array {nameof(array)} is empty.");

            int[] res = new int[(array.Length + 1) / 2];
            while (array.Length != 1)
            {
                for (int i = 0; i < array.Length; i += 2)
                {
                    res[i / 2] = i + 1 < array.Length ? NormalGcd(array[i + 1], array[i]) : NormalGcd(array[i], array[i]);
                    if (res[i / 2] == 1)
                        return 1;
                }
                array = res;
                res = new int[(array.Length + 1) / 2];
            }
            return array[0];
        }

        /// <summary>
        /// Returns greater common divisor of two numbers using the binary Euclidean algorithm.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns></returns>
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
        /// Returns greater common divisor of array of numbers and time that was spent by this method.
        /// </summary>
        /// <param name="time">Output time that was spent by method.</param>
        /// <param name="array">Input array of numbers.</param>
        /// <returns></returns>
        public static int BinaryGcd(out TimeSpan time, params int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException($"Array {nameof(array)} is empty.");

            Stopwatch watch = new Stopwatch();
            int[] res = new int[(array.Length + 1) / 2];
            watch.Start();
            while (array.Length != 1)
            {
                for (int i = 0; i < array.Length; i += 2)
                {
                    res[i / 2] = i + 1 < array.Length ? BinaryGcd(array[i + 1], array[i]) : BinaryGcd(array[i], array[i]);
                    if (res[i / 2] == 1)
                    {
                        watch.Stop();
                        time = watch.Elapsed;
                        return 1;
                    }
                }
                array = res;
                res = new int[(array.Length + 1) / 2];
            }
            watch.Stop();
            time = watch.Elapsed;
            return array[0];
        }

        /// <summary>
        /// Returns greater common divisor of array of numbers.
        /// </summary>
        /// <param name="array">Numbers.</param>
        /// <returns></returns>
        public static int BinaryGcd(params int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException($"Array {nameof(array)} is empty.");

            int[] res = new int[(array.Length + 1) / 2];
            while (array.Length != 1)
            {
                for (int i = 0; i < array.Length; i += 2)
                {
                    res[i / 2] = i + 1 < array.Length ? BinaryGcd(array[i + 1], array[i]) : BinaryGcd(array[i], array[i]);
                    if (res[i / 2] == 1)
                        return 1;
                }
                array = res;
                res = new int[(array.Length + 1) / 2];
            }
            return array[0];
        }
    }
}
