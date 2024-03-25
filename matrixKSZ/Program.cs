using System;
using System.IO;

namespace matrixKSZ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\t1. Új mátrix létrehozása.\n\t2. Előző mátrix betöltése.\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                int oszlop = 0;
                int sor = 0;

                Console.WriteLine("Oszlopok: ");
                oszlop = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Sorok: ");
                sor = Convert.ToInt32(Console.ReadLine());

                int[,] matrix = new int[sor, oszlop];
                Random rnd = new Random();
                for (int i = 0; i < sor; i++)
                {
                    for (int j = 0; j < oszlop; j++)
                    {
                        matrix[i, j] = rnd.Next(1, 100);
                    }
                }

                using (StreamWriter writer = new StreamWriter("matrix.txt"))
                {
                    for (int i = 0; i < sor; i++)
                    {
                        for (int j = 0; j < oszlop; j++)
                        {
                            writer.Write(matrix[i, j] + " ");
                        }
                        writer.WriteLine();
                    }
                }

                for (int i = 0; i < sor; i++)
                {
                    for (int j = 0; j < oszlop; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                int legnagyobb = 0;
                int legnagyobbsor = 0;
                int legnagyobboszlop = 0;

                for (int i = 0; i < sor; i++)
                {
                    for (int j = 0; j < oszlop; j++)
                    {
                        if (matrix[i, j] > legnagyobb)
                        {
                            legnagyobb = matrix[i, j];
                            legnagyobbsor = i;
                            legnagyobboszlop = j;
                        }
                    }
                }

                Console.WriteLine($"A legnagyobb szám: {legnagyobb}, a {legnagyobbsor + 1}. Sor {legnagyobboszlop + 1}. tagja.");

                Console.ReadKey();
            }
            else if (choice == 2)
            {
                if (File.Exists("matrix.txt"))
                {
                    string[] lines = File.ReadAllLines("matrix.txt");

                    int sor = lines.Length;
                    int oszlop = lines[0].Trim().Split(' ').Length;

                    int[,] matrix = new int[sor, oszlop];

                    for (int i = 0; i < sor; i++)
                    {
                        string[] values = lines[i].Trim().Split(' ');
                        for (int j = 0; j < oszlop; j++)
                        {
                            matrix[i, j] = int.Parse(values[j]);
                        }
                    }

                    Console.WriteLine("Mátrix:");
                    for (int i = 0; i < sor; i++)
                    {
                        for (int j = 0; j < oszlop; j++)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    int legnagyobb = 0;
                    int legnagyobbsor = 0;
                    int legnagyobboszlop = 0;

                    for (int i = 0; i < sor; i++)
                    {
                        for (int j = 0; j < oszlop; j++)
                        {
                            if (matrix[i, j] > legnagyobb)
                            {
                                legnagyobb = matrix[i, j];
                                legnagyobbsor = i;
                                legnagyobboszlop = j;
                            }
                        }
                    }

                    Console.WriteLine($"A legnagyobb szám: {legnagyobb}, a {legnagyobbsor + 1}. Sor {legnagyobboszlop + 1}. tagja.");

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("A 'matrix.txt' fájl nem található!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Nem megfelelő választás!");
                Console.ReadKey();
            }
        }
    }
}
