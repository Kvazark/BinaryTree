using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            IAbstractBinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(12);
            bst.Insert(21);
            bst.Insert(5);
            bst.Insert(1);
            bst.Insert(8);
            bst.Insert(18);
            bst.Insert(23);


            TreePrinter<int>.Print(bst);
            var bfs = bst.BFS();
            Console.Write("Сортировка в ширину: ");
            foreach (var e in bfs)
            {
                Console.Write($"{e} ");
            }
            
            Console.WriteLine();
            
            var dfs = bst.DFS();
            Console.Write("Сортировка в глубину: ");
            foreach (var e in dfs)
            {
                Console.Write($"{e} ");
            }
        }
    }
}