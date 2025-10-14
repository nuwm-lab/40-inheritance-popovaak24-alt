using System;

namespace Lab4
{
    // Базовий клас одновимірного вектора розмірності 4
    public class Vector4D
    {
        protected double[] elements; // Масив елементів вектора

        // Конструктор
        public Vector4D()
        {
            elements = new double[4];
        }

        // Віртуальний метод для задання елементів вектора
        public virtual void SetElements()
        {
            Console.WriteLine("Введіть 4 елементи вектора:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                while (!double.TryParse(Console.ReadLine(), out elements[i]))
                {
                    Console.Write("Некоректне значення. Введіть число: ");
                }
            }
        }

        // Метод для задання елементів з масиву (для тестування)
        public virtual void SetElements(double[] values)
        {
            if (values.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    elements[i] = values[i];
                }
            }
        }

        // Віртуальний метод для виведення вектора на екран
        public virtual void Display()
        {
            Console.Write("Вектор: [");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(elements[i]);
                if (i < 3) Console.Write(", ");
            }
            Console.WriteLine("]");
        }

        // Віртуальний метод для знаходження максимального елемента
        public virtual double FindMax()
        {
            double max = elements[0];
            for (int i = 1; i < 4; i++)
            {
                if (elements[i] > max)
                    max = elements[i];
            }
            return max;
        }
    }

    // Похідний клас матриці 4x4
    public class Matrix : Vector4D
    {
        private double[,] matrix; // Двовимірний масив для матриці

        // Конструктор
        public Matrix()
        {
            matrix = new double[4, 4];
        }

        // Перевантажений метод для задання елементів матриці
        public override void SetElements()
        {
            Console.WriteLine("Введіть елементи матриці 4x4:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
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
            if (values.GetLength(0) == 4 && values.GetLength(1) == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        matrix[i, j] = values[i, j];
                    }
                }
            }
        }

        // Перевантажений метод для виведення матриці на екран
        public override void Display()
        {
            Console.WriteLine("Матриця 4x4:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{matrix[i, j]:F2} ");
                }
                Console.WriteLine("|");
            }
        }

        // Перевантажений метод для знаходження максимального елемента матриці
        public override double FindMax()
        {
            double max = matrix[0, 0];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
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
            Console.WriteLine("2 - Демонстрація з тестовими даними");
            Console.Write("Ваш вибір (1 або 2): ");
            
            string choice = Console.ReadLine();
            
            try
            {
                if (choice == "1")
                {
                    RunInteractiveMode();
                }
                else if (choice == "2")
                {
                    RunTestMode();
                }
                else
                {
                    Console.WriteLine("Некоректний вибір. Запускаю режим демонстрації.");
                    RunTestMode();
                }
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
            
            Vector4D vector = new Vector4D();
            vector.SetElements();
            
            Console.WriteLine("\nРезультат:");
            vector.Display();
            double vectorMax = vector.FindMax();
            Console.WriteLine($"Максимальний елемент вектора: {vectorMax}");
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Робота з матрицею
            Console.WriteLine("2. Робота з матрицею 4x4:");
            Console.WriteLine(new string('-', 50));
            
            Matrix matrix = new Matrix();
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
            
            Vector4D vector = new Vector4D();
            double[] testVector = { 1.5, 8.3, 3.7, 5.2 };
            vector.SetElements(testVector);
            
            Console.WriteLine("Тестові дані вектора: [1.5, 8.3, 3.7, 5.2]");
            Console.WriteLine("\nРезультат:");
            vector.Display();
            double vectorMax = vector.FindMax();
            Console.WriteLine($"Максимальний елемент вектора: {vectorMax}");
            
            Console.WriteLine("\n" + new string('=', 60) + "\n");
            
            // Робота з матрицею
            Console.WriteLine("2. Робота з матрицею 4x4:");
            Console.WriteLine(new string('-', 50));
            
            Matrix matrix = new Matrix();
            double[,] testMatrix = {
                { 2.1, 4.5, 1.8, 3.3 },
                { 7.2, 9.6, 2.4, 5.7 },
                { 1.1, 3.8, 12.5, 4.2 },
                { 6.3, 2.9, 8.1, 1.7 }
            };
            matrix.SetElements(testMatrix);
            
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
        }

        static void ShowSummary(double vectorMax, double matrixMax)
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("ПІДСУМОК:");
            Console.WriteLine($"Максимальний елемент вектора: {vectorMax}");
            Console.WriteLine($"Максимальний елемент матриці: {matrixMax}");
            
            if (vectorMax > matrixMax)
                Console.WriteLine("Максимальний елемент знаходиться у векторі.");
            else if (matrixMax > vectorMax)
                Console.WriteLine("Максимальний елемент знаходиться у матриці.");
            else
                Console.WriteLine("Максимальні елементи вектора та матриці рівні.");
        }
    }
}
