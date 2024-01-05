using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pz3_prog
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

            // Поиск среднего арифметического значений информационных полей
            double average = CalculateAverage(root);
            Console.WriteLine($"Среднее арифметическое значений информационных полей: {average}");
            Console.ReadLine();
        }
        static double CalculateAverage(Node node)
        {
            if (node == null)
                return 0;

            double sum = node.Value;
            int count = 1;

            if (node.Left != null)
            {
                sum += CalculateSum(node.Left, ref count);
            }

            if (node.Right != null)
            {
                sum += CalculateSum(node.Right, ref count);
            }

            return sum / count;
        }

        static double CalculateSum(Node node, ref int count)
        {
            double sum = node.Value;
            count++;

            if (node.Left != null)
            {
                sum += CalculateSum(node.Left, ref count);
            }

            if (node.Right != null)
            {
                sum += CalculateSum(node.Right, ref count);
            }

            return sum;
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