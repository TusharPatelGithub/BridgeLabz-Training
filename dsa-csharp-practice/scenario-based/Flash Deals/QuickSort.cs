using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Deals
{
    class QuickSort
    {
        public static void Sort(Product[] products, int low, int high)
        {
            if (low >= high)
                return;
            int pivotIndex = Partition(products, low, high);
            Sort(products, low, pivotIndex - 1);
            Sort(products, pivotIndex + 1, high);
        }
        private static int Partition(Product[] products, int low, int high)
        {
            double pivot = products[high].discount;
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (products[j].discount > pivot)
                {
                    i++;
                    Swap(products, i, j);
                }
            }
            Swap(products, i + 1, high);
            return i + 1;

        }
        public static void Swap(Product[] products, int i, int j)
        {
            Product temp = products[i];
            products[i] = products[j];
            products[j] = temp;
        }
    }
}