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
    }
}