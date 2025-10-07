using System;

namespace LB04
{
    // Одновимірний вектор розмірності 4
    class Vector4
    {
        private double[] elements = new double[4];

        public virtual void ReadFromConsole(string name = "Vector")
        {
            Console.WriteLine($"Enter 4 elements for {name} (separated by spaces or newlines):");
            int idx = 0;
            while (idx < 4)
            {
                Console.Write($"Element [{idx}] = ");
                string? line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Empty input, try again.");
                    continue;
                }

                string[] parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var p in parts)
                {
                    if (idx >= 4) break;
                    if (double.TryParse(p, out double v))
                    {
                        elements[idx++] = v;
                    }
                    else
                    {
                        Console.WriteLine($"'{p}' is not a valid number. Try again for this element.");
                    }
                }
            }
        }

        public virtual void Print(string name = "Vector")
        {
            Console.WriteLine($"{name}:");
            Console.WriteLine(string.Join(" ", elements));
        }

        public virtual double MaxElement()
        {
            double max = elements[0];
            for (int i = 1; i < elements.Length; i++)
                if (elements[i] > max) max = elements[i];
            return max;
        }

        // For potential reuse
        public double[] Elements => elements;
    }

    // Похідний клас "матриця" розмірності 4x4
    class Matrix4 : Vector4
    {
        private double[,] data = new double[4, 4];

        public override void ReadFromConsole(string name = "Matrix")
        {
            Console.WriteLine($"Enter elements for {name} (4 rows, each row with 4 numbers, separated by spaces):");
            for (int i = 0; i < 4; i++)
            {
                int filled = 0;
                while (filled < 4)
                {
                    Console.Write($"Row {i}, enter numbers ({filled}/4): ");
                    string? line = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine("Empty input, try again.");
                        continue;
                    }
                    string[] parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var p in parts)
                    {
                        if (filled >= 4) break;
                        if (double.TryParse(p, out double v))
                        {
                            data[i, filled++] = v;
                        }
                        else
                        {
                            Console.WriteLine($"'{p}' is not a valid number. Try again for this position.");
                        }
                    }
                }
            }
        }

        public override void Print(string name = "Matrix")
        {
            Console.WriteLine($"{name}:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(data[i, j] + " ");
                Console.WriteLine();
            }
        }

        public override double MaxElement()
        {
            double max = data[0,0];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (data[i,j] > max) max = data[i,j];
            return max;
        }

        // Optional: expose data as a flattened vector (not required but useful)
        public double[] Flatten()
        {
            double[] flat = new double[16];
            int k = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    flat[k++] = data[i,j];
            return flat;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Програма: Vector4 та Matrix4 (4x4)");

            var v = new Vector4();
            v.ReadFromConsole("Vector v");
            v.Print("Vector v");
            Console.WriteLine($"Max element of vector v = {v.MaxElement()}");

            Console.WriteLine();

            var m = new Matrix4();
            m.ReadFromConsole("Matrix m");
            m.Print("Matrix m");
            Console.WriteLine($"Max element of matrix m = {m.MaxElement()}");

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
