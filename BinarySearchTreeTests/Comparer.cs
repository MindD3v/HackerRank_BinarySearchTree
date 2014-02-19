using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTests
{
    public class Comparer
    {
        public static bool GreaterThanK(int[] arrayA, int[] arrayB, int k)
        {
            var bst = new BinarySearchTree();
            for (int i = 0; i < arrayA.Length; i++)
            {
                bst.Insert(arrayA[i]);
            }
            var d = new List<Tuple<int?, int>>();
            for (int i = 0; i < arrayB.Length; i++)
            {
                try
                {
                    var r = bst.Remove(arrayB[i], k);
                    d.Add(new Tuple<int?, int>(bst.DeletedNumber, arrayB[i]));
                    bst.DeletedNumber = null;
                    if (!r)
                        break;
                }
                catch (Exception e)
                {
                    break;
                }
            }
            if (bst.Root == null)
                return true;
            else
                return false;
        }
    }
}
