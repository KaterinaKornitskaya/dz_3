using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

/*
 Напишите метод, который отображает квадрат из 
некоторого символа. Метод принимает в качестве параметра: 
длину стороны квадрата, символ.
 */
namespace task1
{
    internal class Program
    {
        static void Square(int length, char sym)  // метод Квадрат, в параметрах размер стороны и символ
        {
           int[,] arr = new int[length, length];  // создание и инициализация матрицы
           for (int i = 0; i < length; i++)
           {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(sym + " ");  // вывод в консоль символов построчно
                }
                Console.WriteLine();
           }      
        }
        static void Main1(string[] args)
        {
            Console.WriteLine("Enter length ");  
            int length = Convert.ToInt32(Console.ReadLine());  // длину вводит пользователь
            Console.WriteLine("Enter symbol");
            char sym = Convert.ToChar(Console.ReadLine());  // символ вводт пользователь
          
            Console.WriteLine(length + " + " + sym);  // вывод в косноль введенных значений
            Console.WriteLine("---------------------");
            Square(length, sym);  // применения метода Квадрат

        }
    }
}


/*
Задание 2
Напишите метод, который проверяет является ли переданное число «палиндромом». 
Число передаётся в качестве параметра. Если число палиндром нужно вернуть из 
метода true, иначе false.
*/
namespace task2
{
    internal class Program
    {
        static bool palindrom()  // булевый метод для определения, является ли число палиндромом
        {
            Console.WriteLine("Enter number");
            long number = Convert.ToInt64(Console.ReadLine());  // считываем номер из консоли
            string string_number = Convert.ToString(number);  // конвертируем в стринг

            char[] arr1 = new char[string_number.Length];  // создание массива char
            string_number.CopyTo(0, arr1, 0, string_number.Length);  // копирование данных из строки в массив char
           
            char[] arr2 = new char[arr1.Length];  // создание 2го массива символов
            arr1.CopyTo(arr2, 0);  // копирование 1го массива во 2ой

            Array.Reverse(arr1);  // реверсирование массива
           
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] !=arr2[i])  // сравнение исходного и реверсированного массивов
                    return false;
            }
            return true;
        
        }
        static void Main2(string[] args)
        {
            if (palindrom())  // если метод palindrom вернул true
                Console.WriteLine("it is true");
            else
                Console.WriteLine("it is false");
        }
    }
}

/*
 Второй вариант задачи выше (про палиндром)
*/
namespace task2a
{
    internal class Program
    {
        static bool IsPalindrome(string s)   // булевый метод для определения, является ли число палиндромом
        {
            for (int i = 0; i < s.Length / 2; ++i)  // цикл до середины строки
            {
                if (s[i] != s[s.Length - 1 - i])  // сравнение 1го и последнего символов
                    return false;
            }                  
            return true;
        }
        static void Main3(string[] args)
        {
            var v = 123321;  // число для анализа
            var s = v.ToString();  // конвертируем число в строку

            if (IsPalindrome(s))  // если метод IsPalindrome вернул true
                Console.WriteLine("it is true");
            else
                Console.WriteLine("it is false");

        }
    }
}


/*
 Задание 3
Напишите метод, фильтрующий массив на основании переданных параметров. 
Метод принимает параметры: оригинальный_массив, массив_с_данными_для_фильтрации.

Метод возвращает оригинальный массив без элементов, которые есть в 
массиве для фильтрации.
Например:
1 2 6 -1 88 7 6 — оригинальный массив;
6 88 7 — массив для фильтрации;
1 2 -1 — результат работы метода.
 */
namespace task3
{
    internal class Program
    {
        static void Func(int[] arr1, int[]arr2)  // метод, принимает два массива
        {
            // int k = arr1.Length;  // переменная для размера
            for (int i = 0; i < arr1.Length; i++)  // цикл по массиву1
            {
                bool buffer = false;  // булевая переменная
                for (int j = 0; j < arr2.Length; j++)  // цикл по массиву2
                {
                    if (arr1[i] == arr2[j])  // если элементы массива 1 и масива 2 равны
                    {
                        buffer = true;  // возвращаем true
                        // k--;  // новый размер массива
                        break;
                    }
                }
                if (!buffer)  // если не true
                {
                    Console.Write(arr1[i] + " ");  // выводим НЕодинаковые элементы из 1го массива
                }

            }
        }
        static void Main4(string[] args)
        {
            int[] arr1 = { 1, 2, 6, -1, 88, 7, 6 };  // массив1
            int[] arr2 = { 6, 88, 7 };               // массив2

            Func(arr1, arr2);  // вызов метода

            /*
            Элементы у меня выводятся верно, все ок. Но сам массив arr1 не изменился.
            Он должен был изменится? Для этого я чситала новый размер массива - 
            закомментированный строки int k = arr1.Length;  // переменная для размера
            и  // k--;  // новый размер массива, дальше пыталась применить Resize к arr1,
            но в итоге не получилось.
            Еще я пыталась решить с помощью метода Consist, но тоже не вышло.
            */
        }
    }
}


/*
 Создайте класс «Веб-сайт». Необходимо хранить в 
полях класса: название сайта, путь к сайту, описание 
сайта, ip адрес сайта. Реализуйте методы класса для ввода 
данных, вывода данных, реализуйте доступ к отдельным 
полям через методы класса.
 */
namespace task4
{
    internal class Program
    {
        class WebSite
        {
            private string site_name;
            private string site_path;
            private string site_description;
            long ip;

            public WebSite() { }  // конструктор по умолчанию
            public WebSite(string s_n, string s_p, string s_d, long i)  // конструктор с параметрами
            {
                site_name = s_n;
                site_path = s_p;
                site_description = s_d;
                ip = i;
            }

            public void SetWebSite()  // общий сеттер для всех полей
            {
                Console.WriteLine("Enter site name: ");
                site_name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter path to site: ");
                site_path = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter description of site: ");
                site_description = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter ip without '-' (only digits)");
                ip = Convert.ToInt64(Console.ReadLine());
            }
            public void ShowWebSite()  // метод Вывод в консоль
            {
                Console.WriteLine("Site name: " + site_name);
                Console.WriteLine("Path to site: " + site_path);
                Console.WriteLine("Description of the site: " + site_description);
                Console.WriteLine("Site ip: " + ip);
            }
            // дальше отдельные геттеры для полей
            public string GetSiteName()
            { 
                return site_name; 
            }
            public string GetSitePath()
            {
                return site_path;
            }
            public string GetSiteDescription()
            {
                return site_description;
            }
            public long GetIp()
            {
                return ip;
            }
        }

        static void Main5(string[] args)
        {
           //WebSite obj = new WebSite();
           //obj.SetWebSite();
           //obj.ShowWebSite();
            WebSite obj2 = new WebSite("Mystat", "https://mystat.itstep.org/", "electronic diary ", 12345678);
            obj2.ShowWebSite();
            Console.WriteLine("=========");
            //obj2.GetSiteName();
            Console.WriteLine(obj2.GetSiteName());
            Console.WriteLine(obj2.GetSitePath());
            Console.WriteLine(obj2.GetSiteDescription());
            Console.WriteLine(obj2.GetIp());

        }
    }
}


/*
 Создайте класс «Журнал». Необходимо хранить в 
полях класса: название журнала, год основания, описание журнала, 
контактный телефон, контактный e-mail. 
Реализуйте методы класса для ввода данных, вывода 
данных, реализуйте доступ к отдельным полям через 
методы класса.
 */
namespace task5
{
    internal class Program
    {
        class Journal
        {
            private string j_name;
            private int year;
            private string j_description;
            private long tel;
            private string email;
            
            long ip;

            public Journal() { }  // конструктор по умолчанию
            public Journal(string n, int y, string p, long t, string e )  // конструктор с параметрами
            {
                j_name = n;
                year = y;
                j_description = p;
                tel = t;
                email = e;
            }

            // отдельные сеттеры для каждого поля:
            public void SetName()
            {
                Console.WriteLine("Enter journal name: ");
                j_name = Convert.ToString(Console.ReadLine());
            }
            public void SetYear()
            {
                Console.WriteLine("Enter year of release: ");
                year = Convert.ToInt32(Console.ReadLine());
            }
            public void SetDescription()
            {
                Console.WriteLine("Enter description: ");
                j_description = Convert.ToString(Console.ReadLine());
            }
            public void SetTel()
            {
                Console.WriteLine("Enter contact telephone: ");
                tel = Convert.ToInt64(Console.ReadLine());
            }
            public void SetEmail()
            {
                Console.WriteLine("Enter contact email: ");
                email = Convert.ToString(Console.ReadLine());
            }
            public void ShowInfo()  // метод вывод в консоль
            {
                Console.WriteLine("Journal name: " + j_name);
                Console.WriteLine("Year of release: " + year);
                Console.WriteLine("Journal description: " + j_description);
                Console.WriteLine("Contact tel: " + tel);
                Console.WriteLine("Contact email: " + email);
            }
            // отдельные геттеры для каждого поля
            public string GetName()
            {
                return j_name;
            }
            public int GetYear()
            {
                return year;
            }
            public string GetDescription()
            {
                return j_description;
            }
            public long GetTel()
            {
                return tel;
            }
            public string GetEmail()
            {
                return email;
            }
        }
        static void Main6(string[] args)
        {
            Journal obj = new Journal();
            obj.SetName();
            obj.SetDescription();
            obj.SetYear();
            obj.SetTel();
            obj.SetEmail();

            Console.WriteLine();
            obj.ShowInfo();
            Console.WriteLine("-----------------------------"); 
            Console.WriteLine("Infornation from getters: ");
          
            Console.WriteLine(obj.GetName());
            Console.WriteLine(obj.GetDescription());
            Console.WriteLine(obj.GetYear());
            Console.WriteLine(obj.GetTel());
            Console.WriteLine(obj.GetEmail());

        }
    }
}

/*
 * Создайте класс «Магазин». Необходимо хранить в 
полях класса: название магазина, адрес, описание профиля магазина, 
контактный телефон, контактный e-mail. 
Реализуйте методы класса для ввода данных, вывода 
данных, реализуйте доступ к отдельным полям через 
методы класса.
 */


namespace task6
{
    internal class Program
    {
        class Shop
        {  
            /*
            здесь аналогичну классу в задаче выше, только сгруппировала все иначе:
            сначала конструкторы, потом поле и к нему сеттер и геттер, и так к 
            каждому полю. Так правильно строить класс, да?
            */

            public Shop() { }  // конструктор по умолчанию
            public Shop(string n, string a, string p, long t, string e)  // конструктор с параметрами
            {
                name = n;
                address = a;
                profile = p;
                tel = t;
                email = e;
            }

            private string name;    // поле имя 
            public void SetName()   // сеттер для ввода данных поля имя
            {
                Console.WriteLine("Enter shop name: ");
                name = Convert.ToString(Console.ReadLine());
            }
            public string GetName()  // геттер для вывода данных поля имя
            {
                return name;
            }

            private string address;    // поле адрес
            public void SetAddress()   // сеттер для ввода данных поля адрес
            {
                Console.WriteLine("Enter shop address: ");
                address = Convert.ToString(Console.ReadLine());
            }
            public string GetAddress()  // геттер для вывода данных поля адрес
            {
                return address;
            }

            private string profile;     // поле профиль
            public void SetProfile()    // сеттер для ввода данных поля профиль
            {
                Console.WriteLine("Enter profile: ");
                profile = Convert.ToString(Console.ReadLine());
            }
            public string GetProfile()  // геттер для вывода данных поля профиль
            {
                return profile;
            }

            private long tel;     // поле телефон
            public void SetTel()  // сеттер для ввода данных поля телефон
            {
                Console.WriteLine("Enter contact telephone: ");
                tel = Convert.ToInt64(Console.ReadLine());
            }
            public long GetTel()  // геттер для вывода данных поля телефон
            {
                return tel;
            }

            private string email;    // поле email
            public void SetEmail()   // сеттер для ввода данных поля email
            {
                Console.WriteLine("Enter contact email: ");
                email = Convert.ToString(Console.ReadLine());
            }
            public string GetEmail()  // геттер для вывода данных поля email
            {
                return email;
            }

            public void ShowInfo()  // метод Вывод в консоль
            {
                Console.WriteLine("Shop name: " + name);
                Console.WriteLine("Shop address: " + address);
                Console.WriteLine("Shop profile: " + profile);
                Console.WriteLine("Contact tel: " + tel);
                Console.WriteLine("Contact email: " + email);
            }
        }
        static void Main(string[] args)
        {
            Shop obj = new Shop();
            obj.SetName();
            obj.SetAddress();
            obj.SetProfile();
            obj.SetTel();
            obj.SetEmail();
            Console.WriteLine("------------------------");
            obj.ShowInfo();           
        }
    }
}


