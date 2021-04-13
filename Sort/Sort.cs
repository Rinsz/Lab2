using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSort
{
    public static class Sort<T> where T : IComparable
    {
        public static (IEnumerable<T> sortedCollection, long totalOperations) ByBubble(IEnumerable<T> enumerable, SortOrder order = SortOrder.Ascending)
        {
            var arr = enumerable.ToArray();
            var swapCount = 0;
            var totalOperations = 0L;
            
            do
            {
                swapCount = 0;
                for (var i = 1; i < arr.Length; i++)
                {
                    if (!NeedToSwap(arr[i - 1], arr[i], order))
                        continue;
                    var temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                    swapCount++;
                }
                
                totalOperations += swapCount;
                
            } while (swapCount != 0);

            return (arr, totalOperations);
        }

        private static bool NeedToSwap(T first, T second, SortOrder order) =>
            order == SortOrder.Descending ? first.CompareTo(second) < 0 : first.CompareTo(second) > 0;
    }
}