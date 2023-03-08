/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18 */

int[,] Matrix1 = CreateArray("Create fisrt matrix: input amount of rows of your first matrix - ", 
                            "Now, input amount of columns of your fisrt matrix - ");
int[,] Matrix2 = CreateArray("Create second matrix: input amount of rows of your second matrix - ", 
                            "And finally, input amount of columns of your second matrix - ");
Console.WriteLine("Creating matrixes...");                      
PrintArray(Matrix1);
Console.WriteLine();
PrintArray(Matrix2);
Console.WriteLine();
Console.WriteLine("Multiplying matrixes...");
if (Validate(Matrix1, Matrix2)) PrintArray(MultiplyMatrix(Matrix1, Matrix2));
else Console.WriteLine("You cann't multiply these matrixes, see the matrix multiplication rules");


int[,] CreateArray(string msg, string msg2)
{
    Console.Write(msg);
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write(msg2);
    int n = Convert.ToInt32(Console.ReadLine());
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

int[,] MultiplyMatrix(int[,] arr1, int[,] arr2)
{
    int result = 0;
    int[,] multipliedMatrixes = new int[arr1.GetLength(0), arr2.GetLength(1)];
    int currentIndex0 = 0;
    int currentIndex1 = 0;
    for (int i = 0, k = 0; i < arr1.GetLength(0); i++)
    {
        while (k < arr2.GetLength(1))
        {
            for (int j = 0, u = 0; j < arr1.GetLength(1); j++, u++)
            {
                result += arr1[i, j] * arr2[u, k];
            }
            multipliedMatrixes[currentIndex0, currentIndex1] = result;
            currentIndex1++;
            result = 0;
            k++;
        }
        currentIndex0++;
        currentIndex1 = 0;
        k = 0;
    }
    return multipliedMatrixes;
}

bool Validate(int[,] arr1, int[,] arr2)
{
    if (arr1.GetLength(1) == arr2.GetLength(0)) return true;
    else return false;
}