// Требуется определить массив целых чисел (например, размера 30), заполнить его случайными 
// числами (в диапазоне от A до B, где A и B задаются в директивах #define) или ввести его 
// элементы с клавиатуры. 

// 1. Найти минимальный элемент массива из всех элементов, обладающих свойством Q.
// 2. Все элементы массива, обладающие свойством T, заменить на их обратные изображения 
// (например, 123 заменить на 321). 
// 3. Отсортировать массив по возрастанию.

// После инициализации и каждого преобразования выводить массив на экран. Свойства Q и T будут ниже.
// Программа должна содержать следующие функции:
// • инициализация элементов массива случайными числами или вводимыми с
// клавиатуры;
// • вывод массива на экран;
// • нахождение минимального элемента из всех элементов, обладающих
// свойством Q;
// • сортировка элементов массива;
// • целочисленная функция, которая возвращает число в перевернутом виде.

// Q: число является степенью тройки. 
// T: число не содержит в своем составе цифру 5.

// #define A
// #define B


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)  //Main
        {
            #if A
                const bool IS_DEFINE = true;
            #else
                const bool IS_DEFINE = false;
            #endif
            int[] arr = InitArray(IS_DEFINE);
            PrintArray(arr);

            System.Console.WriteLine(IsQ(59042));
        }

        public static int[] GenArray(int size, int minValue, int maxValue)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = new Random().Next(minValue, maxValue + 1);
            }
            return arr;
        }

        public static int[] KeyboardArray()
        {
            char[] separators = new char[] { ',', ' ', '[', ']' };

            while (true)
            {
                Console.Write("Input array items: ");
                string? value = Console.ReadLine();
                if (!String.IsNullOrEmpty(value))
                {
                    string[] strArray = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);                 
                    int[] intArray = new int[strArray.Length];
                    bool isNum = true;
                    for (int i = 0; i < intArray.Length; i++)
                    {
                        if (int.TryParse(strArray[i], out int num))
                            intArray[i] = num;
                        else
                        {
                            Console.WriteLine(
                                "Not all enter values are numbers. Please, try again...");
                            isNum = false;
                        }
                    }
                    if (isNum) return intArray;
                }
                else Console.WriteLine("An empty array is entered. Please try again...");
            }
        }

        public static int[] InitArray(bool isDefine)
        {
            const int SIZE = 20;
            const int A = 1;
            const int B = 100;

            return isDefine ? GenArray(SIZE, A, B) :
            KeyboardArray();
        }

        public static int Promt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Inputed value is incorrect. Please, try again...");
            }
        }

        public static void PrintArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(i < array.Length - 1 ?
                $"{array[i]}, " : $"{array[i]}]");
            }
        }

        public static bool IsQ(int number)
        {
            while (number > 1)
            {
                if (number % 3 != 0) 
                    return false;
                number /= 3;
            }
            return true;
        }
    }
}