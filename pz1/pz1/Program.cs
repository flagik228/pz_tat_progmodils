using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace pz1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задаем размерность массивов и коллекций
            int size = 5000;

            // Создаем и заполняем массив случайными значениями
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 10000);
            }

            Console.WriteLine("Задание 1");
            // Выполняем анализ времени выполнения сортировки
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Sorting.InsertionSort(array);
            stopwatch.Stop();
            Console.WriteLine("Время сортировки при вставке: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Reset();

            stopwatch.Start();
            Sorting.SelectionSort(array);
            stopwatch.Stop();
            Console.WriteLine("Время сортировки выбора: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Reset();

            stopwatch.Start();
            Sorting.BubbleSort(array);
            stopwatch.Stop();
            Console.WriteLine("Время сортировки при обмене: " + stopwatch.ElapsedMilliseconds + " ms");

            // Создаем и заполняем список случайными значениями
            List<int> list = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(1, 10000));
            }

            Console.WriteLine("Задание 2");
            // Выполняем анализ времени выполнения поиска прямым поиском
            stopwatch.Reset();
            stopwatch.Start();
            LinearSearch.Search(list, 9999);
            stopwatch.Stop();
            Console.WriteLine("Время линейного поиска (Список): " + stopwatch.ElapsedMilliseconds + " ms");

            // Выполняем анализ времени выполнения бинарного поиска
            stopwatch.Reset();
            stopwatch.Start();
            BinarySearch.Search(list, 9999);
            stopwatch.Stop();
            Console.WriteLine("Время бинарного поиска (Список): " + stopwatch.ElapsedMilliseconds + " ms");

            // Создаем и заполняем хеш-таблицу случайными значениями
            Dictionary<int, int> hashTable = new Dictionary<int, int>();
            for (int i = 0; i < size; i++)
            {
                hashTable.Add(i, random.Next(1, 10000));
            }

            Console.WriteLine("Задание 4");
            // Выполняем анализ времени выполнения поиска элемента в хеш-таблице
            stopwatch.Reset();
            stopwatch.Start();
            HashTableSearch.Search(hashTable, 9999);
            stopwatch.Stop();
            Console.WriteLine("Время поиска в хеш-таблице: " + stopwatch.ElapsedMilliseconds + " ms");

            // Ждем ввода пользователя для завершения программы
            Console.ReadLine();
        }
    }

    public static class Sorting
    {
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }

                array[j + 1] = key;
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }

        public static void BubbleSort(int[] array)
        {
            bool swapped;
            for (int i = 0; i < array.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }
    }

    public static class LinearSearch
    {
        public static bool Search(List<int> list, int target)
        {
            foreach (int num in list)
            {
                if (num == target)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public static class BinarySearch
    {
        public static bool Search(List<int> list, int target)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (list[mid] == target)
                {
                    return true;
                }
                else if (list[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }
    }

    public static class HashTableSearch
    {
        public static bool Search(Dictionary<int, int> hashTable, int target)
        {
            return hashTable.ContainsValue(target);
        }
    }
}