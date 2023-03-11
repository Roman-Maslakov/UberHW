/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

// кажется работает для любого размера, боюсь решение мудренное в плохом смысле

string[,] spiralArr = CreateArray();
spiralArr = Spiralizator(FindCircles(spiralArr), spiralArr);
PrintArray(spiralArr);

string[,] Spiralizator(int[] circles, string[,] arr)
{
    int startPosition = 0;
    int cell = 0;
    int i, j;
    int finish0 = arr.GetLength(0);
    int finish1 = arr.GetLength(1);
    while (circles[2] > 0)
    {
        j = startPosition;
        i = startPosition;
        if (circles[2] == 1 && circles[1] == 1 && circles[0] == 1) // это и следующее условие ради заполнения
                                                                   // центра прямоугольных кейсов
        {
            for (i = startPosition; i < finish0; i++)
            {
                cell++;
                arr[i, j] = Fill(cell);
            }
            break;
        }
        else if (circles[2] == 1 && circles[1] == 1 && circles[0] == 0)
        {
            for (j = startPosition; j < finish1; j++)
            {
                cell++;
                arr[i, j] = Fill(cell);
            }
            break;
        }
        while (j < finish1) // начало основного заполнения
        {
            cell++;
            arr[i, j] = Fill(cell);
            j++;
        }
        j--;
        i++;
        while (i < finish0)
        {
            cell++;
            arr[i, j] = Fill(cell);
            i++;
        }
        i--;
        j--;
        while (j >= startPosition)
        {
            cell++;
            arr[i, j] = Fill(cell);
            j--;
        }
        j++;
        i--;
        while (i >= startPosition + 1)
        {
            cell++;
            arr[i, j] = Fill(cell);
            i--;
        }
        startPosition++;
        circles[2]--;
        finish1--;
        finish0--;
    }
    return arr;
}

int[] FindCircles(string[,] arr)
{
    int[] circles = new int[3]; // для инфо. первое число передает чего меньше
                                // (строк или стобцов - от этого зависит движение при заполнении центра), 
                                // второе число передает четность, а третье число говорит сколько кругов делать.
    if (arr.GetLength(0) > arr.GetLength(1)) 
    {
        circles[0] = 1;
        circles[2] = arr.GetLength(1);
    }
    else 
    {
        circles[0] = 0;
        circles[2] = arr.GetLength(0);
    }
    if (circles[2] % 2 != 0) 
    {
        circles[2] = circles[2] / 2 + 1;
        circles[1] = 1;
    }
    else 
    {
        circles[2] = circles[2] / 2;
        circles[1] = 0;
    }
    return circles;
}

string[,] CreateArray()
{
    Console.Write("Create array: input amount of rows of your array - ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write("Now input amount of columns of your array - ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Creating an array...");
    string[,] arrayDuo = new string[m, n];
    return arrayDuo;
}

void PrintArray(string[,] duoArr)
{
    for (int i = 0; i < duoArr.GetLength(0); i++)
    {
        for (int j = 0; j < duoArr.GetLength(1); j++)
            Console.Write($"{duoArr[i, j]} ");
        Console.WriteLine();
    }
}

string Fill(int n)
{
    string result = String.Empty;
    if (n / 10 < 1) result = "0" + Convert.ToString(n);
    else result = Convert.ToString(n);
    return result;
}