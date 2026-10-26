using System;
using System.Diagnostics;

namespace DSA.Lab01
{
    public static class SearchAlgorithms
    {
        public static int LinearSearch(int[] values, int target)
        {
            //i represet the current index
            //the method stops early if the arrays lenght is null aka the array does not exist
            //the -1 is a check if they algorithm did not return any values
            //best case is the first index is the target
            //worst case is it returns -1 if there is no target in the array if there is a target in the array then worst would be the last index of the array
            //the worst case scenario is equal to the index amount so O(n) which would mean that the amount of work would double
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch(int[] sortedValues, int target)
        {
            //a binary serach needs sorted data because it takes the median and only searches the part that can have the target
            if (sortedValues == null)
            {
                throw new ArgumentNullException(nameof(sortedValues));
            }

            int low = 0;
            int high = sortedValues.Length - 1;

            while (low <= high)
            {
                int middle = low + ((high - low) / 2);
                int value = sortedValues[middle];

                if (value == target)
                {
                    return middle;
                }

                if (value < target)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }

            return -1;
        }

        public static int JumpSearch(int[] values, int target)
        {
            
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            
            int n = values.Length;
            int jumpLength = Convert.ToInt32(Math.Sqrt(n));
            int previous = 0;

            for (int minimumJump = Math.Min(jumpLength, n) - 1;
                 values[minimumJump] < target;
                 minimumJump = Math.Min(jumpLength, n) - 1)
            {
                previous = jumpLength;
                jumpLength += (int)Math.Sqrt(n);
                if (previous >= n)
                {
                    return -1;
                }
            }

            while (values[previous] < n)
            {
                previous++;

                if (previous == Math.Min(jumpLength, n))
                {
                    return -1;
                }
            }

            if (values[previous] == target)
            {
                return previous;
            }

            return -1;
        }
    }
}
