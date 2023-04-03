using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Unit14
{
    internal class Program
    {
        
            static void Main(string[] args)
            {
                string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Алекс", "Ян" };

            var objects = new List<object>()
            {
               1,
               "Сергей ",
               "Андрей ",
               300,
               "Юра ",
            };

            var selectedPeople = from p in people // промежуточная переменная p 
                                     where p.StartsWith("А") // фильтрация по условию
                                     orderby p  // сортировка по возрастанию (дефолтная)
                                     //orderby p descending// сортировка по возрастанию (дефолтная)
                                     select p; // выбираем объект и сохраняем в выборку

                foreach (string s in selectedPeople)
                    Console.WriteLine(s);
            //Console.WriteLine("--------------------");
            Console.ReadKey();

            Console.WriteLine("--------------------"); 
            var selectedPeopleByExt = people.Where(p => p.StartsWith("А")).OrderByDescending(p=>p);
            foreach (string s in selectedPeopleByExt)
                Console.WriteLine(s);
            Console.ReadKey();
            Console.WriteLine("--------------------");
            var selPeopleCnt = (from p in people
                                  where p.ToUpper().StartsWith("А")
                                  orderby p
                                  select p).Count();

            Console.WriteLine($"В выборке {selPeopleCnt} чел");
            Console.ReadKey();
            Console.WriteLine("--------------------");

            foreach (var varseObj in objects.Where(o1 => o1 is String).OrderByDescending(o11 => o11))
                Console.WriteLine($"В objects: {varseObj} ");
            //Console.WriteLine("--------------------");
            Console.ReadKey();
            var names = from a in objects
                        where a is string // проверка на совместимость с типом
                        orderby a // сортировка по имени
                        select a; // выборка
            Console.WriteLine("--------------------");
            //Console.ReadKey();
            foreach (var name in names)
                Console.WriteLine("В objects:" + name);
            Console.ReadKey();

            // Словарь для хранения стран с городами
            var Countries = new Dictionary<string, List<City>>();

            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));
            Countries.Add("Россия", russianCities);

            // Добавим Беларусь
            var belarusCities = new List<City>();
            belarusCities.Add(new City("Минск", 1200000));
            belarusCities.Add(new City("Витебск", 362466));
            belarusCities.Add(new City("Гродно", 368710));
            Countries.Add("Беларусь", belarusCities);

            // Добавим США
            var americanCities = new List<City>();
            americanCities.Add(new City("Нью-Йорк", 8399000));
            americanCities.Add(new City("Вашингтон", 705749));
            americanCities.Add(new City("Альбукерке", 560218));
            Countries.Add("США", americanCities);
            
            Console.WriteLine("--------------------");
            foreach (var rc in russianCities)
            { Console.WriteLine("В russianCities:" + rc.Name+" "+ rc.Population ); }
            Console.ReadKey();

            Console.WriteLine("--------------------");
            foreach (var rc in russianCities.Where(cP => cP.Population >= 1000000).OrderByDescending(cN => cN.Population))
            { Console.WriteLine("В russianCities:" + rc.Name + " " + rc.Population); }
            Console.ReadKey();

            Console.WriteLine("--------------------");
            foreach (var cn in Countries)
            { Console.WriteLine("В Countries:" + cn.Key + " "  +cn.Value.ToArray()); }
            Console.ReadKey();
        }
        
    }
}
