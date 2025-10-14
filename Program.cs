using System;

    public interface IMathObject
    {
        void SetElements();
        void Display();
        double FindMax();
    }


namespace Lab4
{
    public static class MathConstants
    {
        public const int VECTOR_SIZE = 4;
        public const int MATRIX_SIZE = 4;
    }
    // Базовий клас одновимірного вектора
    public class Vector4D : IMathObject
    {
        protected double[] elements; // Масив елементів вектора

        // Конструктор
        public Vector4D()
        {
            elements = new double[MathConstants.VECTOR_SIZE];
        }

        // Встановлення елементів з консолі
        public void SetElements()
        {
            Console.WriteLine($"Введіть {MathConstants.VECTOR_SIZE} елементи вектора:");
            for (int i = 0; i < MathConstants.VECTOR_SIZE; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                while (!double.TryParse(Console.ReadLine(), out elements[i]))
                {
                    Console.Write("Некоректне значення. Введіть число: ");
                }
            }
        }

        // Встановлення елементів з масиву
        public void SetElements(double[] values)
        {
            if (values.Length == MathConstants.VECTOR_SIZE)
            {
                for (int i = 0; i < MathConstants.VECTOR_SIZE; i++)
                {
                    elements[i] = values[i];
                }
            }
        }

        // Виведення вектора
        public void Display()
        {
            Console.Write("Вектор: [");
            for (int i = 0; i < MathConstants.VECTOR_SIZE; i++)
            {
                Console.Write(elements[i]);
                if (i < MathConstants.VECTOR_SIZE - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }

        // Пошук максимального елемента
        public double FindMax()
        {
            double max = elements[0];
            for (int i = 1; i < MathConstants.VECTOR_SIZE; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }
            return max;
        }
    }

    // Похідний клас матриці 4x4
        public class Matrix : IMathObject
    {
        private double[,] matrix; // Двовимірний масив для матриці

        // Конструктор
        public Matrix()
        {
            matrix = new double[MathConstants.MATRIX_SIZE, MathConstants.MATRIX_SIZE];
        }

        // Перевантажений метод для задання елементів матриці
            public void SetElements()
        {
            Console.WriteLine($"Введіть елементи матриці {MathConstants.MATRIX_SIZE}x{MathConstants.MATRIX_SIZE}:");
            for (int i = 0; i < MathConstants.MATRIX_SIZE; i++)
            {
                for (int j = 0; j < MathConstants.MATRIX_SIZE; j++)
                {
                    Console.Write($"Елемент [{i},{j}]: ");
                    while (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.Write("Некоректне значення. Введіть число: ");
                    }
                }
            }
        }

        // Метод для задання елементів з двовимірного масиву (для тестування)
        public void SetElements(double[,] values)
        {
            if (values.GetLength(0) == MathConstants.MATRIX_SIZE && values.GetLength(1) == MathConstants.MATRIX_SIZE)
            {
                for (int i = 0; i < MathConstants.MATRIX_SIZE; i++)
                {
                    for (int j = 0; j < MathConstants.MATRIX_SIZE; j++)
                    {
                        matrix[i, j] = values[i, j];
                    }
                }
            }
        }

        // Перевантажений метод для виведення матриці на екран
            public void Display()
        {
            Console.WriteLine($"Матриця {MathConstants.MATRIX_SIZE}x{MathConstants.MATRIX_SIZE}:");
            for (int i = 0; i < MathConstants.MATRIX_SIZE; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < MathConstants.MATRIX_SIZE; j++)
                {
                    Console.Write($"{matrix[i, j]:F2} ");
                }
                Console.WriteLine("|");
            }
        }

        // Перевантажений метод для знаходження максимального елемента матриці
            public double FindMax()
        {
            double max = matrix[0, 0];
            for (int i = 0; i < MathConstants.MATRIX_SIZE; i++)
            {
                for (int j = 0; j < MathConstants.MATRIX_SIZE; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }
    }

    // Головний клас програми
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота 4: Спадкування класів ===\n");
            
            // Вибір режиму роботи
            Console.WriteLine("Виберіть режим роботи:");
            Console.WriteLine("1 - Ввід з клавіатури");
            Console.Write("Ваш вибір (1): ");

            string choice = Console.ReadLine();

            try
            {
                RunInteractiveMode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            try
            {
                Console.ReadKey();
            }
            catch (InvalidOperationException)
            {
                // Ігноруємо помилку при перенаправленні вводу
            }
        }

        static void RunInteractiveMode()
        {
            // Робота з одновимірним вектором
            Console.WriteLine("1. Робота з одновимірним вектором розмірності 4:");
            Console.WriteLine(new string('-', 50));
            
                IMathObject vector = new Vector4D();
            vector.SetElements();
            
            Console.WriteLine("\nРезультат:");
            vector.Display();
            double vectorMax = vector.FindMax();
            Console.WriteLine($"Максимальний елемент вектора: {vectorMax}");
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Робота з матрицею
            Console.WriteLine("2. Робота з матрицею 4x4:");
            Console.WriteLine(new string('-', 50));
            
                IMathObject matrix = new Matrix();
            matrix.SetElements();
            
            Console.WriteLine("\nРезультат:");
            matrix.Display();
            double matrixMax = matrix.FindMax();
            Console.WriteLine($"Максимальний елемент матриці: {matrixMax}");
            
            ShowSummary(vectorMax, matrixMax);
        }

        static void RunTestMode()
        {
            Console.WriteLine("ДЕМОНСТРАЦІЯ З ТЕСТОВИМИ ДАНИМИ:\n");
            
            // Робота з одновимірним вектором
            Console.WriteLine("1. Робота з одновимірним вектором розмірності 4:");
            Console.WriteLine(new string('-', 50));
            
                IMathObject vector = new Vector4D();
            double[] testVector = { 1.5, 8.3, 3.7, 5.2 };
            
            Console.WriteLine("Тестові дані вектора: [1.5, 8.3, 3.7, 5.2]");
            Console.WriteLine("\nРезультат:");
            vector.Display();
            double vectorMax = vector.FindMax();
            Console.WriteLine($"Максимальний елемент вектора: {vectorMax}");
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Робота з матрицею
            Console.WriteLine("2. Робота з матрицею 4x4:");
            Console.WriteLine(new string('-', 50));
            
                IMathObject matrix = new Matrix();
            double[,] testMatrix = {
                { 2.1, 4.5, 1.8, 3.3 },
                { 7.2, 9.6, 2.4, 5.7 },
                { 1.1, 3.8, 12.5, 4.2 },
                { 6.3, 2.9, 8.1, 1.7 }
            };
            
            Console.WriteLine("Тестові дані матриці:");
            Console.WriteLine("2.1  4.5  1.8  3.3");
            Console.WriteLine("7.2  9.6  2.4  5.7");
            Console.WriteLine("1.1  3.8  12.5 4.2");
            Console.WriteLine("6.3  2.9  8.1  1.7");
            
            Console.WriteLine("\nРезультат:");
            matrix.Display();
            double matrixMax = matrix.FindMax();
            Console.WriteLine($"Максимальний елемент матриці: {matrixMax}");
            
            ShowSummary(vectorMax, matrixMax);
                // Тестовий режим видалено. Програма працює лише в інтерактивному режимі.
        }

        static void ShowSummary(double vectorMax, double matrixMax)
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("ПІДСУМОК:");
            Console.WriteLine($"Максимальний елемент вектора: {vectorMax}");
            Console.WriteLine($"Максимальний елемент матриці: {matrixMax}");
            
            if (vectorMax > matrixMax)
            {
                Console.WriteLine("Максимальний елемент знаходиться у векторі.");
            }
            else if (matrixMax > vectorMax)
            {
                Console.WriteLine("Максимальний елемент знаходиться у матриці.");
            }
            else
            {
                Console.WriteLine("Максимальні елементи вектора та матриці рівні.");
            }
        }
    }
}
