using System;

class Origin
{
    public void OriginDouble(double value)
    {
        Console.WriteLine(value);
    }

    public void OriginInt(int value)
    {
        Console.WriteLine(value);
    }

    public void OriginChar(char value)
    {
        Console.WriteLine(value);
    }
}


//Создание класса Client, который будет адаптировать функциональность класса Origin:

class Client
{
    private Origin origin;

    public Client(Origin origin)
    {
        this.origin = origin;
    }

    public void ClientDouble(double value)
    {
        origin.OriginDouble(value);
    }

    public void ClientInt(int value)
    {
        origin.OriginInt(2 * value);
    }

    public void ClientChar(char value)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write(value);
        }
        Console.WriteLine();
    }
}


//Здесь использовалась композиция, чтобы класс Client имел доступ к функциональности класса Origin.

//В методе Main создаем экземпляры классов Origin и Client и вызовем соответствующие методы:

class Program
{
    static void Main(string[] args)
    {
        Origin origin = new Origin();
        Client client = new Client(origin);

        double doubleValue = 3.14;
        int intValue = 5;
        char charValue = 'Б';

        client.ClientDouble(doubleValue);
        client.ClientInt(intValue);
        client.ClientChar(charValue);

        Console.ReadKey();
    }
}