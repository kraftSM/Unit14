using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit14.Hw1
{
    internal class Program
    {
        static bool rqExit = false;
        static void Main(string[] args)
        {
            //string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Алекс", "Ян" };
            //var selectedPeople = from p in people // промежуточная переменная p 
            //                     where p.StartsWith("А") // фильтрация по условию
            //                     orderby p descending // сортировка по возрастанию (дефолтная)
            //                     select p; // выбираем объект и сохраняем в выборку
            //foreach (string s in selectedPeople)
            //    Console.WriteLine(s);
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));


            //foreach (var s in phoneBook.OrderBy(s => s.Name).ThenBy(s => s.LastName))
            //    Console.WriteLine(s);
            Console.WriteLine("Вeсь список:"); 
            ShowContactPaged(phoneBook, 0, 6);
            Console.WriteLine("\nВведите номер страницы для просмотра ,\tEscape,0 - Выход");
            while (!rqExit)
            {
                //Console.WriteLine("Press a key, together with Alt, Ctrl, or Shift.");
                
                //Console.WriteLine("Press Esc to exit.");
                ConsoleKeyInfo input = Console.ReadKey(true);
                //StringBuilder output = new StringBuilder(String.Format("\nYou pressed [{0}]", input.Key.ToString()));
                //if ((input.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt) output.Append("+ALT");
                //if ((input.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift) output.Append("+SFT");
                //if ((input.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control) output.Append("+CNT");
                //Console.WriteLine(output);
                if ((input.Key == ConsoleKey.Escape) | (input.Key == ConsoleKey.D0) | (input.Key == ConsoleKey.NumPad0)) rqExit = true;
                else
                {
                    switch (input.Key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            ShowContactPaged(phoneBook, 0, 2);
                            break;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            ShowContactPaged(phoneBook, 2, 2);
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            ShowContactPaged(phoneBook, 4, 2);
                            break;
                        default:
                            Console.WriteLine("\nВведите номер страницы для просмотра ,\t0 - Выход");
                            break;
                    }
                }
            }
            //Console.ReadKey();
        }
        static public void ShowContactPaged(List<Contact> phBook, int skipContacts, int showContacts)
        {
            //Console.WriteLine("\n");
            foreach (var s in phBook.OrderBy(s => s.Name).ThenBy(s => s.LastName).Skip(skipContacts).Take(showContacts))
                Console.WriteLine(s);
            Console.WriteLine("-------  Start from:{0} / Show:{1}", skipContacts, showContacts);

        }
    }
}
