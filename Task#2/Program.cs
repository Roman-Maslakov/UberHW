/*Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка */

int[,] ourArr = CreateArray();
PrintArray(ourArr);
Console.WriteLine();
Console.WriteLine("Comparing rows...");
Compare(GetSum(ourArr));

int[,] CreateArray()
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

int[] GetSum(int[,] arr)
{
    int k = 0;
    int sum = 0;
    int[] sumOfEachRow = new int[arr.GetLength(0)];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            sum += arr[i, j];
        }
        sumOfEachRow[k] = sum;
        Console.WriteLine(sumOfEachRow[k]); // для удобства проверки
        sum = 0;
        k++;
    }
    return sumOfEachRow;
}

void Compare(int[] sum)
{
    int minRow = sum[0];
    int indexOfMinRow = 0;
    for (int i = 0; i < sum.Length; i++)
    {
        if (minRow > sum[i]) 
        {
            minRow = sum[i];
            indexOfMinRow = i;
        }
    }
    Console.WriteLine($"The smallest row is the {indexOfMinRow + 1} row");
}