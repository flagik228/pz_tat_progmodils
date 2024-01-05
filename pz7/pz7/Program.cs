using System;
using System.Collections.Generic;

public abstract class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public abstract double GetDiscount(double totalPurchases);
}

public class Product1 : Product
{
    public override double GetDiscount(double totalPurchases)
    {
        // Логика расчета скидки на товар 1
        return 0.1; // Скидка в 10%
    }
}

public class Product2 : Product
{
    public override double GetDiscount(double totalPurchases)
    {
        // Логика расчета скидки на товар 2
        return 0.2; // Скидка в 20%
    }
}

public class Product3 : Product
{
    public override double GetDiscount(double totalPurchases)
    {
        // Логика расчета скидки на товар 3
        return 0.15; // Скидка в 15%
    }
}

public class Client
{
    public string Name { get; set; }
    public double AllPurchases { get; set; }

    public void AddPurchase(Product product)
    {
        // Логика добавления покупки клиента в общий список покупок магазина
        AllPurchases += product.Price;
    }
}

public class Store
{
    public List<Product> AllPurchases { get; set; }

    public Store()
    {
        AllPurchases = new List<Product>();
    }

    public void SaveOrder(Product product)
    {
        // Логика проверки данных и сохранения покупки в списке покупок магазина
        AllPurchases.Add(product);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();
        Client client1 = new Client { Name = "Клиент 1" };
        Client client2 = new Client { Name = "Клиент 2" };

        Product product1 = new Product1 { Name = "Товар 1", Price = 100 };
        Product product2 = new Product2 { Name = "Товар 2", Price = 200 };
        Product product3 = new Product3 { Name = "Товар 3", Price = 300 };

        store.SaveOrder(product1);
        store.SaveOrder(product2);
        store.SaveOrder(product3);

        client1.AddPurchase(product1);
        client1.AddPurchase(product2);

        client2.AddPurchase(product3);

        Console.WriteLine("Общая сумма покупок магазина: " + store.AllPurchases.Count);
        Console.WriteLine("Общая сумма покупок клиента 1: " + client1.AllPurchases);
        Console.WriteLine("Общая сумма покупок клиента 2: " + client2.AllPurchases);

        Console.ReadLine();
    }
}

//Переопределение методов в этом примере полезно,
//    так как позволяет определить уникальную логику расчета скидок
//    на каждый тип товара. Это удобно и гибко, так как можно легко добавлять
//    новые типы товаров и определять для них свои собственные правила расчета скидок.

//В данном примере функционал можно было бы реализовать и без переопределения методов,
//например, с помощью условных операторов внутри метода GetDiscount базового класса Product.
//Однако, использование наследования и переопределения методов позволяет создать более ясную и модульную структуру кода,
//а также упрощает добавление новых типов товаров и изменение правил расчета скидок.