namespace DesignPatterns.SortedList
{
    public class ShellSort : ISortStrategy
    {
        private static void Sort(string[] arr, int arraySize)
        {
            var inc = 3;
            while (inc > 0)
            {
                int i;
                for (i = 0; i < arraySize; i++)
                {
                    var j = i;
                    int temp = arr[0][i];
                    while ((j >= inc) && (arr[0][j - inc] > temp))
                    {
                        arr[j] = arr[j - inc];
                        j -= inc;
                    }
                    arr[j] = temp.ToString();
                }
                if (inc / 2 != 0)
                    inc /= 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }

        public void Sort(string[] list)
        {
            Sort(list, list.Length);
        }
    }
}