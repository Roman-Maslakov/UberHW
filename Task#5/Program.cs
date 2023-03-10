/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

// работает только для квадратного массива, не знаю как решить проблему перезаписи центральной
// линии если массив задается прямоугольным

string[,] spiralArr = CreateArray();
spiralArr = Spiralizator(FindCircles(spiralArr), spiralArr);
PrintArray(spiralArr);

string[,] Spiralizator(int circles, string[,] arr)
{
    int startPosition = 0;
    int cell = 0;
    int i, j;
    int finish0 = arr.GetLength(0);
    int finish1 = arr.GetLength(1);
    while (circles > 0)
    {
        j = startPosition;
        i = startPosition;
        while (j < finish1)
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
        circles--;
        finish1--;
        finish0--;
    }
    return arr;
}

int FindCircles(string[,] arr)
{
    int circles = 0;
    if (arr.GetLength(0) > arr.GetLength(1)) circles = arr.GetLength(1);
    else circles = arr.GetLength(0);
    if (circles % 2 != 0) circles = circles / 2 + 1;
    else circles = circles / 2;
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