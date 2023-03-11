/* Вывести первые N строк треугольника Паскаля. Сделать вывод в виде равнобедренного треугольника */

// как доходит до десяток уже не красивый вывод

PrintPascalTriangle(CreatePascalTriangle());

int[,] CreatePascalTriangle()
{
    Console.Write("Hello! How much rows do we need? - ");
    int N = Convert.ToInt32(Console.ReadLine());
    int[,] triangle = new int[N, N];
    int j = 0, i = 0;
    for (i = 0; i < N; i++)
    {
        triangle[i, j] = 1;
    }
    for (i = 1; i < N; i++)
    {
        for (j = 1; j < N; j++)
        {
            triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j];
        }
    }
    return triangle;
}

void PrintPascalTriangle(int[,] triangle)
{
    string space = String.Empty;
    int N = triangle.GetLength(0) - 1;
    int spaceCount = N;
    int elementsInRow = 1;
    for (int i = 0; i < triangle.GetLength(0); i++)
    {
        while (spaceCount > 0)
        {
            space += " ";
            spaceCount--;
        }
        Console.Write(space);
        for (int j = 0; j < elementsInRow; j++)
        {
            Console.Write($"{triangle[i, j]} ");
        }
        elementsInRow++;
        N--;
        spaceCount = N;
        space = String.Empty;
        Console.WriteLine();
    }
}