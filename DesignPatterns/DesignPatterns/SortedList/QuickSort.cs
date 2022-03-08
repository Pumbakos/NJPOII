using static System.String;

namespace DesignPatterns.SortedList
{
    public class QuickSort : ISortStrategy
    {
        private string[] _names;
        private int _length;

        private void _QuickSort(int lowerIndex, int higherIndex) {
            var i = lowerIndex;
            var j = higherIndex;
            var pivot = _names[lowerIndex + (higherIndex - lowerIndex) / 2];

            while (i <= j) {
                while (CompareOrdinal(pivot, _names[i]) < 0) {
                    i++;
                }

                while (CompareOrdinal(pivot, _names[i]) > 0) {
                    j--;
                }

                if (i > j) continue;
                
                ExchangeNames(i, j);
                i++;
                j--;
            }
            if (lowerIndex < j) {
                _QuickSort(lowerIndex, j);
            }
            if (i < higherIndex) {
                _QuickSort(i, higherIndex);
            }
        }

        private void ExchangeNames(int i, int j) {
            (_names[i], _names[j]) = (_names[j], _names[i]);
        }
        
        public void Sort(string[] array)
        {
            if (array == null || array.Length == 0) {
                return;
            }
            _names = array;
            _length = array.Length;
            _QuickSort(0, _length - 1);
        }
    }
}