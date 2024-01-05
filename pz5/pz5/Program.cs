using System;

// Создание класса по требованиям
public class MyClass : ICloneable, IComparable
{
    private int numericField;
    private DateTime dateField;
    private AnotherClass objectField;

    public int NumericField
    {
        get { return numericField; }
        set { numericField = value; }
    }

    public DateTime DateField
    {
        get { return dateField; }
        set { dateField = value; }
    }

    public AnotherClass ObjectField
    {
        get { return objectField; }
        set { objectField = value; }
    }

    public override string ToString()
    {
        return $"Числовое поле: {NumericField}, Поле даты: {DateField}, Поле объекта: {ObjectField.ToString()}";
    }

    // Реализация интерфейса ICloneable
    public object Clone()
    {
        return this.MemberwiseClone();
    }

    // Реализация интерфейса IComparable
    public int CompareTo(object obj)
    {
        MyClass other = obj as MyClass;
        if (other == null)
            throw new ArgumentException("Объект не относится к типу MyClass");

        // Сравниваем поля объектов для определения порядка
        if (this.NumericField != other.NumericField)
            return this.NumericField.CompareTo(other.NumericField);
        else
            return this.DateField.CompareTo(other.DateField);
    }
}

// Второй класс, используемый в качестве поля пользовательского типа
public class AnotherClass
{

    public override string ToString()
    {
        return "Другой класс";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Использование класса MyClass
        MyClass obj1 = new MyClass();
        obj1.NumericField = 10;
        obj1.DateField = DateTime.Now;
        obj1.ObjectField = new AnotherClass();

        MyClass obj2 = (MyClass)obj1.Clone();
        Console.WriteLine(obj2.ToString());

        int comparisonResult = obj1.CompareTo(obj2);
        Console.WriteLine($"Результат: {comparisonResult}");
    }
}