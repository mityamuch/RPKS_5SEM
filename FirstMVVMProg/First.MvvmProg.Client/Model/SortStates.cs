using System;
using System.Collections.Generic;
using System.Text;

namespace FIrstMVVMProg.Client.Model
{
    public class InsertionSortState
    {
        public int i; public int j;
        public void Clear()
        {
            i = 1; j = 1;
        }


    }
    public class SelectionSortState
    {
        public int i; public int j; public int indmin;
        public void Clear()
        {
            i = 0; j = 1; indmin = 0;
        }
    }
    public class RadixSortState 
    {
        public int i;public int shift;public int j;
        public void Clear() {
           

        }
    }
    public class MergeSortState { }
    public class HeapSortState { }
}
