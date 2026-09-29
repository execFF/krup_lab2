using System;

namespace Lab2_Variant7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n=== Меню (Вариант 7) ===");
                Console.WriteLine("1. Сортировка массива (по возрастанию)");
                Console.WriteLine("2. Сумма элементов на главной и побочной диагонали матрицы NxN");
                Console.WriteLine("3. Определитель матрицы NxN");
                Console.WriteLine("4. Минимальный элемент матрицы NxM и его индексы");
                Console.WriteLine("5. Выйти");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": SortArray(); break;
                    case "2": DiagonalSums(); break;
                    case "3": MatrixDeterminant(); break;
                    case "4": FindMinElement(); break;
                    case "5": isRunning = false; break;
                    default: Console.WriteLine("Неверный выбор. Попробуйте снова."); break;
                }
            }
        }

        static void SortArray()
        {
            Console.Write("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++) arr[i] = int.Parse(Console.ReadLine());
            
            Array.Sort(arr); // Встроенная сортировка, можно заменить на пузырьковую
            Console.WriteLine("Отсортированный массив: " + string.Join(", ", arr));
        }

        static void DiagonalSums()
        {
            Console.Write("Введите размер квадратной матрицы N: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = int.Parse(Console.ReadLine());

            int mainDiagSum = 0, secondaryDiagSum = 0;
            for (int i = 0; i < n; i++)
            {
                mainDiagSum += matrix[i, i];
                secondaryDiagSum += matrix[i, n - 1 - i];
            }
            Console.WriteLine($"Сумма главной диагонали: {mainDiagSum}");
            Console.WriteLine($"Сумма побочной диагонали: {secondaryDiagSum}");
        }

        static void MatrixDeterminant()
        {
            Console.Write("Введите размер квадратной матрицы N (рекомендуется 2 или 3 для теста): ");
            int n = int.Parse(Console.ReadLine());
            double[,] matrix = new double[n, n];
            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = double.Parse(Console.ReadLine());

            double det = CalculateDeterminant(matrix, n);
            Console.WriteLine($"Определитель матрицы: {det}");
        }

        static double CalculateDeterminant(double[,] matrix, int n)
        {
            if (n == 1) return matrix[0, 0];
            if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            double det = 0;
            for (int i = 0; i < n; i++)
            {
                double[,] subMatrix = new double[n - 1, n - 1];
                for (int j = 1; j < n; j++)
                {
                    int subCol = 0;
                    for (int k = 0; k < n; k++)
                    {
                        if (k == i) continue;
                        subMatrix[j - 1, subCol++] = matrix[j, k];
                    }
                }
                det += Math.Pow(-1, i) * matrix[0, i] * CalculateDeterminant(subMatrix, n - 1);
            }
            return det;
        }

        static void FindMinElement()
        {
            Console.Write("Введите количество строк N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов M: ");
            int m = int.Parse(Console.ReadLine());
            
            double[,] matrix = new double[n, m];
            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = double.Parse(Console.ReadLine());

            double min = matrix[0, 0];
            int minRow = 0, minCol = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }

            Console.WriteLine($"Минимальный элемент: {min}");
            Console.WriteLine($"Его индексы: [{minRow}, {minCol}]");
        }
    }
}