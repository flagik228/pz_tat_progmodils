using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz3_zadanie3
{
    internal class Program
    {
        static void Main(string[] args)
            {
                // Создание сбалансированного дерева
                Node root = new Node(5);
                root.Left = new Node(3);
                root.Right = new Node(8);
                root.Left.Left = new Node(1);
                root.Left.Right = new Node(4);
                root.Right.Left = new Node(6);
                root.Right.Right = new Node(9);

                // Заданное значение для подсчета
                int valueToCount = 4;

                // Подсчет количества узлов с заданным значением информационных полей
                int count = CountNodesWithValue(root, valueToCount);

                Console.WriteLine($"Количество узлов со значением {valueToCount}: {count}");
            Console.ReadLine();
        }

            static int CountNodesWithValue(Node node, int value)
            {
                if (node == null)
                    return 0;

                int count = node.Value == value ? 1 : 0;

                if (node.Left != null)
                {
                    count += CountNodesWithValue(node.Left, value);
                }

                if (node.Right != null)
                {
                    count += CountNodesWithValue(node.Right, value);
                }

                return count;
            }
        }

        class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
    }
