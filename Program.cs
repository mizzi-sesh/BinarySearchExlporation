using static System.Console;
using System.Diagnostics;

namespace BinarySearchExlporation
{
    public static class Program
    {
        public static void Main()
        {

            int n = 20000;
            Random rnd = new Random();

            int result = 0;
            int iterations = 0;
            float average = 0f;

            while (iterations < 20000)
            {
                iterations++;
                int[] ints = new int[20000];

                for (int index = 0; index < n; index++)
                {
                    ints[index] = rnd.Next(0, n - 1);
                }

                // List<int> list = ints.ToList();
                // list.Sort();
                // ints = list.ToArray();      
                Stopwatch sw = new Stopwatch();
                //List<int> intList = ints.ToList();
                sw.Start();
                //result = intList.FindIndex(x => x == rnd.Next(0,n));
                //result = BinarySearch(ints, rnd.Next(0,n));
                sw.Stop();
                if (result >= 0)
                {
                    average *= iterations - 1;
                    average += sw.ElapsedTicks;
                    average /= iterations;
                }
                sw.Reset();
            }
            WriteLine("Average running time: {0} ticks.", average);
        }

        public static int BinarySearch(int[] domain, int target)
        {

            if (domain.Length == 0)
                throw new ArgumentException("No elements in the domain array.");

            int mid = domain.Length / 2 - 1;
            int high = domain.Length - 1;
            int low = 0;

            while (domain[mid] != target && high != low)
            {
                if (domain[mid] > target)
                    high = mid - 1;
                if (domain[mid] < target)
                    low = mid + 1;
                if (low >= high || high <= low)
                    low = high;

                mid = high - (high - low) / 2;
            }

            if (domain[mid] == target)
            {
                return mid;
            }
            else
            {
                //WriteLine("Target not found");
                return -1;
            }
        }
    }
}