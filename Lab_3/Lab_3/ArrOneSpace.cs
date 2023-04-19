namespace Lab_3
{
    public class ArrOneSpace: ISumMinMax
    {
        private int[] arr;
        
        public ArrOneSpace(){}

        public ArrOneSpace(int[] array)
        {
            arr = array;
        }

        public int sumMinMax()
        {
            int min = arr[0];
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i]) min = arr[i];
                if (max < arr[i]) max = arr[i];
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
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i]) min = arr[i];
            }

            return min;
        }
        
        public int findMax()
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i]) max = arr[i];
            }

            return max;
        }
    }
}