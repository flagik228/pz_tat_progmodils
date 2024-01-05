using System;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}


//Cоздаybt класса BinaryTree, который будет содержать методы для работы с деревом:

public class BinaryTree
{
    private Node root;

    public void Insert(int value)
    {
        Node newNode = new Node(value);

        if (root == null)
        {
            root = newNode;
        }
        else
        {
            Node current = root;
            Node parent;

            while (true)
            {
                parent = current;

                if (value < current.Value)
                {
                    current = current.Left;

                    if (current == null)
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                else
                {
                    current = current.Right;

                    if (current == null)
                    {
                        parent.Right = newNode;
                        return;
                    }
                }
            }
        }
    }

    public int GetSumOfValues()
    {
        return GetSumOfValues(root);
    }

    private int GetSumOfValues(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Value + GetSumOfValues(node.Left) + GetSumOfValues(node.Right);
    }

    public int GetInternalNodeCount()
    {
        return GetInternalNodeCount(root);
    }

    private int GetInternalNodeCount(Node node)
    {
        if (node == null || (node.Left == null && node.Right == null))
        {
            return 0;
        }

        return 1 + GetInternalNodeCount(node.Left) + GetInternalNodeCount(node.Right);
    }

    public List<int> GetNegativeValues()
    {
        List<int> negativeValues = new List<int>();
        GetNegativeValues(root, negativeValues);
        return negativeValues;
    }

    private void GetNegativeValues(Node node, List<int> negativeValues)
    {
        if (node != null)
        {
            if (node.Value < 0)
            {
                negativeValues.Add(node.Value);
            }

            GetNegativeValues(node.Left, negativeValues);
            GetNegativeValues(node.Right, negativeValues);
        }
    }

    public List<int> GetDuplicateValues(BinaryTree otherTree)
    {
        List<int> duplicateValues = new List<int>();
        GetDuplicateValues(root, otherTree.root, duplicateValues);
        return duplicateValues;
    }

    private void GetDuplicateValues(Node node1, Node node2, List<int> duplicateValues)
    {
        if (node1 != null && node2 != null)
        {
            if (node1.Value == node2.Value)
            {
                duplicateValues.Add(node1.Value);
            }

            GetDuplicateValues(node1.Left, node2.Left, duplicateValues);
            GetDuplicateValues(node1.Right, node2.Right, duplicateValues);
        }
    }
}


//Создание класса Program для тестирования функциональности дерева:

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        // Задание 1
        for (int i = 0; i < 10; i++)
        {
            int value = new Random().Next(10, 1000);
            tree.Insert(value);
        }

        int sumOfValues = tree.GetSumOfValues();
        Console.WriteLine("Сумма значений информационных полей дерева: " + sumOfValues);

        // Задание 2
        int internalNodeCount = tree.GetInternalNodeCount();
        Console.WriteLine("Количество внутренних узлов дерева: " + internalNodeCount);

        // Задание 3
        List<int> negativeValues = tree.GetNegativeValues();
        Console.WriteLine("Отрицательные значения информационных полей дерева:");
        foreach (int value in negativeValues)
        {
            Console.WriteLine(value);
        }

        // Задание 4
        BinaryTree otherTree = new BinaryTree();
        otherTree.Insert(50);
        otherTree.Insert(20);
        otherTree.Insert(70);
        otherTree.Insert(30);
        otherTree.Insert(40);

        List<int> duplicateValues = tree.GetDuplicateValues(otherTree);
        Console.WriteLine("Значения информационных полей, которые совпадают в обоих деревьях:");
        foreach (int value in duplicateValues)
        {
            Console.WriteLine(value);
        }

        Console.ReadLine();
    }
}