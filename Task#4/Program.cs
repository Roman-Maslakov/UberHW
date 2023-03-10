/* Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */

int[,,] Our3DArr = CreateArray3D("Create a trhree dimensional array: input length - ",
                                 "And, give me width of array - ",
                                 "And at last input heigth of array - ");

if (Validate(Our3DArr)) PrintArray3D(ShuffleArray3D(Our3DArr));

int[,,] CreateArray3D(string msg, string msg2, string msg3)
{
    Console.Write(msg);
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write(msg2);
    int n = Convert.ToInt32(Console.ReadLine());
    Console.Write(msg3);
    int l = Convert.ToInt32(Console.ReadLine());
    int[,,] array3D = new int[m, n, l];
    int cell = 10;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < l; k++)
            {
                array3D[i, j, k] = cell++;
            }
        }
    }
    return array3D;
}

int[,,] ShuffleArray3D(int[,,] arr)
{
    int r = 0;
    int l = 0;
    int m = 0;
    int temp = 0;
    for (int i = arr.GetLength(0) - 1; i > 0; i--)
    {
        for (int j = arr.GetLength(1) - 1; j > 0 ; j--)
        {
            for (int k = arr.GetLength(2) - 1; k > 0; k--)
            {
                r = new Random().Next(i + 1);
                l = new Random().Next(j + 1);
                m = new Random().Next(k + 1);
                temp = arr[r, l, m];
                arr[r, l, m] = arr[i, j, k];
                arr[i, j, k] = temp;
            }
        }
    }
    return arr;
}

void PrintArray3D(int[,,] arr)
{
    for (int k = 0; k < arr.GetLength(2); k++)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
}

bool Validate(int[,,] arr)
{
    int m = arr.GetLength(0);
    int n = arr.GetLength(1);
    int l = arr.GetLength(2);
    if (m * n * l > 90) 
    {
        Console.WriteLine("We cann't afford more than 90 cells for nonrepeating two-digit numbers");
        return false;
    }
    return true;
}