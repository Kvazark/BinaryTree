using System;
using System.Collections.Generic;

namespace Tree
{
    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T> where T : IComparable
    {
        private IAbstractBinarySearchTree<T> _abstractBinarySearchTreeImplementation;

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;
        public void SearchInWidth(T element)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T element)
        {
            var current = this.Root;
            while (current != null)
            {
                if (element.CompareTo(current.Value) < 0)
                {
                    current = current.LeftChild;
                }
                else if (element.CompareTo(current.Value) > 0)
                {
                    current = current.RightChild;
                }
                else
                {
                    break;
                }
            }

            return current != null;
        }

        public void Insert(T element)
        {
            var newElement = new Node<T>(element, null, null);

            if (this.Root == null)
            {
                this.Root = newElement;
            }
            else
            {
                var childElement = this.Root;
                Node<T> parentElement = null;

                while (childElement != null)
                {
                    parentElement = childElement;

                    if (newElement.Value.CompareTo(childElement.Value) < 0)
                    {
                        childElement = childElement.LeftChild;
                    }
                    else if (newElement.Value.CompareTo(childElement.Value) > 0)
                    {
                        childElement = childElement.RightChild;
                    }
                    else
                    {
                        return;
                    }
                }

                if (parentElement.Value.CompareTo(newElement.Value) < 0)
                {
                    parentElement.RightChild = newElement;
                }
                else
                {
                    parentElement.LeftChild = newElement;
                }
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (element.CompareTo(current.Value) < 0)
                {
                    current = current.LeftChild;
                }
                else if (element.CompareTo(current.Value) > 0)
                {
                    current = current.RightChild;
                }
                else
                {
                    break;
                }
            }

            return new BinarySearchTree<T>(current);
        }

        public List<T> BFS()
        {
            var result = new List<T>();
            var queue = new Queue<Node<T>>();
            
            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                Node<T> tempNode = queue.Dequeue();
                if (tempNode.LeftChild != null)
                {
                    queue.Enqueue(tempNode.LeftChild);
                }

                if (tempNode.RightChild != null)
                {
                    queue.Enqueue(tempNode.RightChild);
                }
                result.Add(tempNode.Value);
            }
            return result;
        }

        public List<T> DFS()
        {
            var order = new List<T>();
            this.Dfs(Root, order);
            return order;
        }

        private void Dfs(Node<T> tempNode, List<T> order)
        {
            if (tempNode.LeftChild != null && tempNode.RightChild != null)
            {
                this.Dfs(tempNode.LeftChild, order);
                this.Dfs(tempNode.RightChild, order);
            }
            order.Add(tempNode.Value);
        }
    }
}