using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz3_zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
            {
                // Создание сбалансированного дерева
                Node root = new Node(5);
                root.Left = new Node(3);
                root.Right = new Node(8);
                root.Left.Left = new Node(-1);
                root.Left.Right = new Node(4);
                root.Right.Left = new Node(6);
                root.Right.Right = new Node(-9);

                // Подсчет количества узлов с положительными и отрицательными значениями информационных полей
                int positiveCount = 0;
                int negativeCount = 0;

                CountPositiveAndNegative(root, ref positiveCount, ref negativeCount);

                Console.WriteLine($"Количество узлов с положительными значениями: {positiveCount}");
                Console.WriteLine($"Количество узлов с отрицательными значениями: {negativeCount}");
            Console.ReadLine();
        }

            static void CountPositiveAndNegative(Node node, ref int positiveCount, ref int negativeCount)
            {
                if (node == null)
                    return;

                if (node.Value > 0)
                    positiveCount++;
                else if (node.Value < 0)
                    negativeCount++;

                if (node.Left != null)
                {
                    CountPositiveAndNegative(node.Left, ref positiveCount, ref negativeCount);
                }

                if (node.Right != null)
                {
                    CountPositiveAndNegative(node.Right, ref positiveCount, ref negativeCount);
                }
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
