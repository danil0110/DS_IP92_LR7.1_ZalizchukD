using System;
using System.Collections.Generic;
using System.IO;

namespace DS_IP92_LR7._1_ZalizchukD
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "graph.txt", prufer = "prufer.txt", choice;
            Console.WriteLine("1. Дерево в код Прюфера\n2. Код Прюфера в дерево");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                Graph graph = new Graph(input);
            }
            else if (choice == "2")
            {
                Graph graph = new Graph(prufer);
            }
            else
            {
                Console.WriteLine("Ошибка: неверный ввод.");
                Environment.Exit(0);
            }
        }
    }

    class Graph
    {
        private int n, m;
        private int[,] mSmezh;
        private int[] vertexPowers;
        private List<int> pruferCode = new List<int>(), vertices;

        public Graph(string path)
        {
            StreamReader sr = new StreamReader(path);

            if (path == "graph.txt")
            {
                string read = sr.ReadLine();
                string[] temp = read.Split(' ');
                n = Convert.ToInt32(temp[0]);
                m = Convert.ToInt32(temp[1]);
                mSmezh = new int[n, n];
                vertexPowers = new int[n];

                for (int i = 0; i < m; i++)
                {
                    read = sr.ReadLine();
                    temp = read.Split(' ');
                    int a = Convert.ToInt32(temp[0]) - 1, b = Convert.ToInt32(temp[1]) - 1;
                    mSmezh[a, b] = 1;
                    mSmezh[b, a] = 1;
                }

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (mSmezh[i, j] == 1)
                            vertexPowers[i]++;
            }
            else if (path == "prufer.txt")
            {
                string read = sr.ReadLine();
                string[] temp = read.Split(' ');
                foreach (var el in temp)
                    pruferCode.Add(Convert.ToInt32(el) - 1);

                n = pruferCode.Count + 2;
                mSmezh = new int[n, n];
                vertices = new List<int>();
                for (int i = 0; i < n; i++)
                    vertices.Add(i);
                
            }
        }
    }
    
}