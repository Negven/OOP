namespace Lab_3.Properties
{
    public class ArrTwoSpace: ISumMinMax
    {
        private int[,] arr;
        
        public ArrTwoSpace(){}

        public ArrTwoSpace(int[,] array)
        {
            arr = array;
        }

        public int sumMinMax()
        {
            int min = arr[0, 0];
            int max = arr[0, 0];
            foreach (int el in arr)
            {
                if (min > el) min = el;
                if (max < el) max = el;                
            }
            return max + min;
        }
        
        public int sum()
        {
            int sum = 0;
            foreach (int el in arr)
            {
                sum += el;
            }

            return sum;
        }
        
        public int findMin()
        {
            int min = arr[0, 0];
            foreach (int el in arr)
            {
                if (min > el) min = el;
            }

            return min;
        }
        
        public int findMax()
        {
            int max = arr[0, 0];
            foreach (int el in arr)
            {
                if (max < el) max = el;
            }

            return max;
        }
    }
}