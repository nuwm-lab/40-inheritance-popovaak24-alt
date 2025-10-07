using System;

namespace Lab04
{
    // Одновимірний вектор розмірності 4
    class Vector4
    {
        private double[] elements = new double[4];

        // задавання елементів вектора
        public void SetElements(double e0, double e1, double e2, double e3)
        {
            elements[0] = e0;
            elements[1] = e1;
            elements[2] = e2;
            elements[3] = e3;
        }

        // альтернативний спосіб задати з масиву
        public void SetElements(double[] values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length != 4) throw new ArgumentException("Array must have exactly 4 elements.");
            Array.Copy(values, elements, 4);
        }

        // виведення вектора на екран
        public virtual void Print()
        {
            Console.WriteLine("Vector4: [{0}, {1}, {2}, {3}]", elements[0], elements[1], elements[2], elements[3]);
        }

        // знаходження максимального елемента
        public virtual double MaxElement()
        {
            double max = elements[0];
            for (int i = 1; i < 4; i++)
                if (elements[i] > max) max = elements[i];
            return max;
        }

        // індексатор для доступу до елементів
        public double this[int index]
        {
            get => elements[index];
            set => elements[index] = value;
        }
    }

    // Матриця, похідний від Vector4
    // Трактуємо матрицю як 4x4, де кожен рядок — це Vector4
    class Matrix4x4 : Vector4
    {
        private double[,] data = new double[4, 4];

        // задавання елементів матриці з 2D масиву
        public void SetElements(double[,] values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.GetLength(0) != 4 || values.GetLength(1) != 4)
                throw new ArgumentException("Array must be 4x4.");
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    data[i, j] = values[i, j];
        }

        // задавання елементів матриці по рядку
        public void SetRow(int row, Vector4 rowVector)
        {
            if (row < 0 || row >= 4) throw new ArgumentOutOfRangeException(nameof(row));
            for (int j = 0; j < 4; j++) data[row, j] = rowVector[j];
        }

        // виведення матриці
        public override void Print()
        {
            Console.WriteLine("Matrix 4x4:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("[");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(data[i, j]);
                    if (j < 3) Console.Write(", ");
                }
                Console.WriteLine("]");
            }
        }

        // знаходження максимального елемента матриці
        public override double MaxElement()
        {
            double max = data[0, 0];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (data[i, j] > max) max = data[i, j];
            return max;
        }
    }

    class Program
    {
        static void Main()
        {
            // Демонстрація роботи

            // Створюємо вектор і задаємо елементи
            var v = new Vector4();
            v.SetElements(1.5, 3.2, -0.7, 8.0);
            v.Print();
            Console.WriteLine("Max element of vector: {0}", v.MaxElement());

            Console.WriteLine();

            // Створюємо матрицю і задаємо елементи
            var m = new Matrix4x4();
            double[,] values = new double[4, 4]
            {
                { 1, 2, 3, 4 },
                { -5, 6, 7, 8 },
                { 9, 10, -11, 12 },
                { 13, 14, 15, 16 }
            };
            m.SetElements(values);
            m.Print();
            Console.WriteLine("Max element of matrix: {0}", m.MaxElement());

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
