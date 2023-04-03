using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit14.Hw1V2
{
    internal class Program
    {
        static bool rqExit = false;
        static int pageIdx  = 0;
        const int pageItemNum = 2;
        static void Main(string[] args)
        {

            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            phoneBook.Add(new Contact("Артур", "Конан-Дойл", 099900000013, "artur@notexist.com"));
            phoneBook.Add(new Contact("Виктор", "Цой", 099900000001, "vtsoy@forever.ru"));
            ShowContactPaged(phoneBook, 0, phoneBook.Count);

            while (!rqExit)
            {
                Console.WriteLine("\nВведите номер страницы для просмотра ,\t0 - Выход");
                string str = Console.ReadLine();
                if (int.TryParse(str, out pageIdx))
                {
                    if (pageIdx < 1) rqExit = true;
                    else
                    {
                        pageIdx--;
                        if(((pageIdx * pageItemNum) + pageItemNum) <= phoneBook.Count) 
                            ShowContactPaged(phoneBook, (pageIdx ) * pageItemNum, pageItemNum);
                    }
                }
            }


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
