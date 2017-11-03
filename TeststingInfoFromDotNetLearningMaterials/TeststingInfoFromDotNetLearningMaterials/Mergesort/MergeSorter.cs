//namespace TeststingInfoFromDotNetLearningMaterials.Mergesort
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    public class MergeSorter
//    {

//        public IList<T> SplitThenSort<T>(IList<T> collection)
//            where T : IComparable
//        {
//            int collectionCount = collection.Count;

//            if (collectionCount <= 1)
//            {
//                return collection;
//            }

//            int midPoint = collectionCount / 2;

//            IList<T> left = new List<T>();
//            IList<T> right = new List<T>();

//            for (int i = 0; i < midPoint; i++)
//            {
//                left.Add(collection[i]);
//            }

//            for (int i = midPoint; i < collectionCount; i++)
//            {
//                right.Add(collection[i]);
//            }

//            left = this.SplitThenSort(left);
//            right = this.SplitThenSort(right);

//            return MergeSort(left, right);
//        }

//        private IList<T> MergeSort<T>(IList<T> left, IList<T> right)
//            where T : IComparable
//        {
//            IList<T> toBeReturned = new List<T>();

//            while (left.Count > 0 || right.Count > 0)
//            {
//                if (left.Count > 0 && right.Count > 0)
//                {
//                    if (left.First().CompareTo(right.First()) >= 0)
//                    {
//                        toBeReturned.Add(left.First());
//                        left.RemoveAt(0);
//                    }
//                    else
//                    {
//                        toBeReturned.Add(right.First());
//                        right.RemoveAt(0);
//                    }
//                }
//                else if (left.Count <= 0)
//                {
//                    toBeReturned.Add(right.First());
//                    right.RemoveAt(0);
//                }
//                else if (right.Count <= 0)
//                {
//                    toBeReturned.Add(left.First());
//                    left.RemoveAt(0);
//                }
//            }

//            return toBeReturned;
//        }
//    }
//}
