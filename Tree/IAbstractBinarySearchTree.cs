using System;
using System.Collections.Generic;

namespace Tree
{
    public interface IAbstractBinarySearchTree<T> where T : IComparable
    {
        //Вставка элемента
        void Insert(T element);

        //Содержит ли дерево данный элемент?
        bool Contains(T element);

        //Поиск
        IAbstractBinarySearchTree<T> Search(T element);

        //Корень дерева/поддерева
        Node<T> Root { get; }

        //Дочерний элемент слева
        Node<T> LeftChild { get; }

        //Дочерний элемент справа
        Node<T> RightChild { get; }

        //Значение
        T Value { get; }
        //Обход в ширину
        List<T> BFS();
        //Обход в глубину
        List<T> DFS();
    }
}