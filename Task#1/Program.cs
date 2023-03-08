/* Задача 54: Задайте двумерный массив. Напишите программу, 
которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

int[,] ourArr = CreateDoubleArray();
PrintArray(ourArr);
Console.WriteLine();
Console.WriteLine("Sorting...");
PrintArray(Sort(ourArr));

int[,] CreateDoubleArray()
{
    Console.Write("Create array: input amount of rows of your array - ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write("Now input amount of columns of your array - ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Creating an array...");
    int[,] arrayDuo = new int[m, n];
    for (int i = 0; i < arrayDuo.GetLength(0); i++)
    {
        for (int j = 0; j < arrayDuo.GetLength(1); j++)
            arrayDuo[i, j] = new Random().Next(10);
    }
    return arrayDuo;
}

void PrintArray(int[,] duoArr)
{
    for (int i = 0; i < duoArr.GetLength(0); i++)
    {
        for (int j = 0; j < duoArr.GetLength(1); j++)
            Console.Write($"{duoArr[i, j]} ");
        Console.WriteLine();
    }
}

int[,] Sort(int[,] arr)
{
    int temporary = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = j + 1; k < arr.GetLength(1); k++)
            {
                if (arr[i, j] < arr[i, k]) 
                {
                    temporary = arr[i, j];
                    arr[i, j] = arr[i, k];
                    arr[i, k] = temporary;
                }
            }
        }
    }
    return arr;
}