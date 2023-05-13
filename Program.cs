//базовый класс
using System.Security.Cryptography.X509Certificates;

abstract class Delivery
{
    public string Address;
}

//доставка на дом. Этот тип будет подразумевать наличие курьера или передачу курьерской компании, в нём будет располагаться своя, отдельная от прочих типов доставки, логика.
class HomeDelivery : Delivery
{
    //--------------------Поля
    //Дата и время заказа
    private DateTime orderData;

    //-------------------Свойства
    //Записываем дату и время заказа
    public DateTime OrderData
    {
        set { orderData = value; }
    }


}
//доставка в пункт выдачи. Здесь будет храниться какая-то ещё логика, необходимая для процесса доставки в пункт выдачи, например, хранение компании и точки выдачи, а также какой-то ещё информации.
class PickPointDelivery : Delivery
{
    private string addressOfTheIssuingPoint;

    public string AddressOfTheIssuingPoint
    { get { return addressOfTheIssuingPoint; } set { addressOfTheIssuingPoint = value; } }

}
// доставка в розничный магазин. Эта доставка может выполняться внутренними средствами компании и совсем не требует работы с «внешними» элементами.
class ShopDelivery : Delivery
{
    private string addressShop;
    public string AddressShop
    { get { return addressShop; } set { addressShop = value; } }
}

class Product<T> : Order
{
    private T barCode;
    public string productName;

    public Product(T barCode)
    {
        this.barCode = barCode;
    }
}

//класс заказа
class Order : Delivery
{
    public int Number;
    public string Description;

}
//Класс для данных о покупателе
class UserData : HomeDelivery
{

    //Поля
    private string login;
    private int age;
    private string email;
    private string address;
    private string numberPhone;

    //Свойства
    public string Login
    {
        get
        {
            return login;
        }
        set
        {
            if (login.Length < 3)
            {
                Console.WriteLine("Логин должен быть длинной от 3 символов.");
            }
            else
            {
                login = value;
            }
        }
    }

    public int Age
    {
        get
        { return age; }
        set
        {
            if (age > 14)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Заказать через интернет можно с 14 лет.");
            }
        }
    }

    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            //Проверка на корректность email
            if (email.Length < 5 || !email.Contains('@'))
            {
                Console.WriteLine("Введён неверный адрес электронной почты.");
            }
            else
            {
                email = value;
            }
        }
    }
    public string Address { get { return address; } set { address = value; } }
    public string NumberPhone
    {
        get
        {
            return numberPhone;
        }
        set
        {
            if (numberPhone.Length == 11)
            {
                numberPhone = value;
            }
            else
            {
                Console.WriteLine("Номер телефона должен содержать 11 цифр.");
            }

        }
    }
}

class UserCollection : UserData
{
    private UserData[] collection;

    public UserCollection(UserData[] collection)
    {
        this.collection = collection;
    }

    public UserData this[int index]
    {
        get
        {
            if (index >= 0 && index < collection.Length)
            {
                return collection[index];
            }
            else
            {
                return null;
            }
        }

        private set
        {
            if(index >= 0 && index < collection.Length)
            {
                collection[index] = value;
            }
        }
    }
}

class Program
{
    //Проверка на корректность ввода цифр
    public static int CheckAge()
    {
        var IfInt = int.TryParse(Console.ReadLine(), out int number);
        int result = 0;

        if (IfInt && number > 1)
        {
            result = number;
        }
        else
        {
            Console.WriteLine("Input error!");
        }
        return result; ;
    }

    static void Main(string[] args)
    {

    }
}

