public class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}


//Cоздание абстрактного класса PhoneBookObject, который будет являться базовым классом для всех объектов телефонной книги. 

public abstract class PhoneBookObject
{
    public abstract Contact GetContact();
}


//Создание конкретных классов для каждой категории объектов, которые реализуют метод GetContact():

public class Person : PhoneBookObject
{
    public override Contact GetContact()
    {
        return new Contact
        {
            Name = "Татаринов Артем",
            Phone = "89878836502",
            Email = "tatarinov@gmail.com"
        };
    }
}

public class EducationalInstitution : PhoneBookObject
{
    public override Contact GetContact()
    {
        return new Contact
        {
            Name = "Логинов Сергей",
            Phone = "89876543210",
            Email = "loginov@gmail.com"
        };
    }
}

public class IndividualEntrepreneur : PhoneBookObject
{
    public override Contact GetContact()
    {
        return new Contact
        {
            Name = "Карасева Анна",
            Phone = "5555555555",
            Email = "annkaras@gmail.com"
        };
    }
}


//ТСоздание класса Factory, который будет генерировать новые объекты в зависимости от выбранной категории:

public class Factory
{
    public static PhoneBookObject CreateObject(string category)
    {
        switch (category)
        {
            case "Person":
                return new Person();
            case "EducationalInstitution":
                return new EducationalInstitution();
            case "IndividualEntrepreneur":
                return new IndividualEntrepreneur();
            default:
                throw new NotSupportedException("Неподдерживаемая категория");
        }
    }
}


//Создание класса Program, в котором можно будет тестировать функционал:

public class Program
{
    public static void Main(string[] args)
    {
        string category = "Person"; // Можно выбрать другую категорию

        PhoneBookObject phoneBookObject = Factory.CreateObject(category);
        Contact contact = phoneBookObject.GetContact();

        Console.WriteLine("Name: " + contact.Name);
        Console.WriteLine("Phone: " + contact.Phone);
        Console.WriteLine("Email: " + contact.Email);

        Console.ReadLine();
    }
}