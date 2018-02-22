using System.Collections.Generic;
using System;

namespace prototyping
{
    public static class ArrayUtil
    {
        // Randomizer for random things we need :o
        private static Random random = new Random();

        #region Highest Value
        public static int GetHighestValue(int[] a)
        {
            int b = int.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        public static float GetHighestValue(float[] a)
        {
            float b = float.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        public static double GetHighestValue(double[] a)
        {
            double b = double.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        public static long GetHighestValue(long[] a)
        {
            long b = long.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        public static short GetHighestValue(short[] a)
        {
            short b = short.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        public static byte GetHighestValue(byte[] a)
        {
            byte b = byte.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        public static uint GetHighestValue(uint[] a)
        {
            uint b = uint.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        public static ushort GetHighestValue(ushort[] a)
        {
            ushort b = ushort.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        public static ulong GetHighestValue(ulong[] a)
        {
            ulong b = ulong.MinValue;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) b = a[i]; }
            return b;
        }
        #endregion

        #region Lowest Value
        public static int GetLowestValue(int[] a)
        {
            int b = int.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        public static float GetLowestValue(float[] a)
        {
            float b = float.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        public static double GetLowestValue(double[] a)
        {
            double b = double.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        public static long GetLowestValue(long[] a)
        {
            long b = long.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        public static short GetLowestValue(short[] a)
        {
            short b = short.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        public static byte GetLowestValue(byte[] a)
        {
            byte b = byte.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        public static uint GetLowestValue(uint[] a)
        {
            uint b = uint.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        public static ushort GetLowestValue(ushort[] a)
        {
            ushort b = ushort.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        public static ulong GetLowestValue(ulong[] a)
        {
            ulong b = ulong.MaxValue;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) b = a[i]; }
            return b;
        }
        #endregion

        #region Highest Value Index
        public static int GetHighestValueIndex(int[] a)
        {
            int b = int.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetHighestValueIndex(float[] a)
        {
            float b = float.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetHighestValueIndex(double[] a)
        {
            double b = double.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetHighestValueIndex(long[] a)
        {
            long b = long.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetHighestValueIndex(short[] a)
        {
            short b = short.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetHighestValueIndex(byte[] a)
        {
            byte b = byte.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetHighestValueIndex(uint[] a)
        {
            uint b = uint.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetHighestValueIndex(ushort[] a)
        {
            ushort b = ushort.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetHighestValueIndex(ulong[] a)
        {
            ulong b = ulong.MinValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b < a[i]) { b = a[i]; index = i; } }
            return index;
        }
        #endregion

        #region Lowest Value Index
        public static int GetLowestValueIndex(int[] a)
        {
            int b = int.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetLowestValueIndex(float[] a)
        {
            float b = float.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetLowestValueIndex(double[] a)
        {
            double b = double.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetLowestValueIndex(long[] a)
        {
            long b = long.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetLowestValueIndex(short[] a)
        {
            short b = short.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetLowestValueIndex(byte[] a)
        {
            byte b = byte.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetLowestValueIndex(uint[] a)
        {
            uint b = uint.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetLowestValueIndex(ushort[] a)
        {
            ushort b = ushort.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        public static int GetLowestValueIndex(ulong[] a)
        {
            ulong b = ulong.MaxValue;
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            { if (b > a[i]) { b = a[i]; index = i; } }
            return index;
        }
        #endregion

        #region GetClosestIndex
        public static int GetClosestIndex(int[] a, int n)
        {
            int delta = int.MaxValue;
            int index = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Math.Abs(a[i] - n) < delta)
                {
                    delta = Math.Abs(a[i] - n);
                    index = i;
                }
            }

            return index;
        }
        public static int GetClosestIndex(float[] a, float n)
        {
            float delta = float.MaxValue;
            int index = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Math.Abs(a[i] - n) < delta)
                {
                    delta = Math.Abs(a[i] - n);
                    index = i;
                }
            }

            return index;
        }
        public static int GetClosestIndex(double[] a, double n)
        {
            double delta = double.MaxValue;
            int index = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Math.Abs(a[i] - n) < delta)
                {
                    delta = Math.Abs(a[i] - n);
                    index = i;
                }
            }

            return index;
        }
        public static int GetClosestIndex(long[] a, long n)
        {
            long delta = long.MaxValue;
            int index = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Math.Abs(a[i] - n) < delta)
                {
                    delta = Math.Abs(a[i] - n);
                    index = i;
                }
            }

            return index;
        }
        public static int GetClosestIndex(short[] a, short n)
        {
            short delta = short.MaxValue;
            int index = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Math.Abs(a[i] - n) < delta)
                {
                    delta = (short)Math.Abs(a[i] - n);
                    index = i;
                }
            }

            return index;
        }
        #endregion

        public static void CopyOver<T>(T[] source, T[] target)
        {
            for (int i = 0; i < source.Length && i < target.Length; i++)
            {
                target[i] = source[i];
            }
        }
        public static List<t> Filter<t>(List<t> elements, List<t> from)
        {
            List<t> E = new List<t>(from);
            for (int i = 0; i < elements.Count; i++)
            {
                E.Remove(elements[i]);
            }
            return E;
        }
        public static t[] Filter<t>(t[] elements, t[] from)
        {
            return Filter(new List<t>(elements), new List<t>(from)).ToArray();
        }
        public static void Shuffle<t>(ref t[] array)
        {
            List<int> Positions = new List<int>();
            t[] copy = new t[array.Length];

            for (int i = 0; i < array.Length; i++)
                Positions.Add(i);

            CopyOver(array, copy);

            for (int i = 0; i < array.Length; i++)
            {
                int index = random.Next(Positions.Count);
                array[i] = copy[Positions[index]];
                Positions.Remove(index);
            }
        }
    }
}
