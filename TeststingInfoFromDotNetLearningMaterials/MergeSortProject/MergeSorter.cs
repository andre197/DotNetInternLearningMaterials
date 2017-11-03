namespace MergeSortProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter
    {
        public IList<T> SplitThenSort<T>(IList<T> collection, bool isTopDown = true)
            where T : IComparable
        {
            int collectionCount = collection.Count;

            if (collectionCount <= 1)
            {
                return collection;
            }

            int midPoint = collectionCount / 2;

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < midPoint; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = midPoint; i < collectionCount; i++)
            {
                right.Add(collection[i]);
            }

            left = this.SplitThenSort(left, isTopDown);
            right = this.SplitThenSort(right, isTopDown);

            return MergeSort(left, right, isTopDown);

        }

        private IList<T> MergeSort<T>(IList<T> left, IList<T> right, bool isTopDown)
            where T : IComparable
        {
            IList<T> toBeReturned = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (IsTopDown(left.First(), right.First(), isTopDown))
                    {
                        toBeReturned.Add(left.First());
                        left.RemoveAt(0);
                    }
                    else
                    {
                        toBeReturned.Add(right.First());
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count <= 0)
                {
                    toBeReturned.Add(right.First());
                    right.RemoveAt(0);
                }
                else if (right.Count <= 0)
                {
                    toBeReturned.Add(left.First());
                    left.RemoveAt(0);
                }
            }

            return toBeReturned;
        }

        private static bool IsTopDown<T>(T left, T right, bool isTopDown) where T : IComparable
        {
            if (isTopDown)
            {
                return left.CompareTo(right) >= 0;
            }

            return left.CompareTo(right) <= 0;
        }
    }
}
