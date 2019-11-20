using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList.models;

namespace SingleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Klasse Person testen
            Person p1 = new Person("Elias", "Rist", new DateTime(2000, 4, 24));
            //Console.WriteLine(p);

            Person p2 = new Person("Christian", "Schwöllo", new DateTime(2000, 4, 24));
            Person p3 = new Person("Tobias", "Flöckinger", new DateTime(2000, 4, 24));
            Person p4 = new Person("Thomas", "MairiKairi", new DateTime(2000, 4, 24));

            SingleLinkedList<Person> sll = new SingleLinkedList<Person>();

            /*if (sll.Remove(null))
            {
                Console.WriteLine("Person wurde nicht entfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Parameter = Null");
            }

            if (sll.Remove(p))
            {
                Console.WriteLine("Person wurde nicht entfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Liste ist leer");
            }
            */

            sll.Add(p1);
            sll.Add(p2);
            sll.Add(p3);
            sll.Add(p4);

            //sll.Find(p4);
            //Console.WriteLine("Hier die gewünschte Person : {0}", p4);


            if(sll.Change(p2, new Person("Raphael"," Garzaner", new DateTime(2001,06,99) ) ) )
            {
                Console.WriteLine("Daten wurden geändert");
            }

            if(sll.Change(null, null))
            {
                Console.WriteLine("Es existieren keine Daten");
            }




            /*
            bool isStartItem;
            SingleLinkedListItem<Person> personbefore = sll.FindItemBeforeItem(p3, out isStartItem);
            if (isStartItem)
            {
                Console.WriteLine("Es existiert kein Eintrag vor dem gesuchten Eintrag");
                Console.WriteLine("Die gesuchte Person ist im Starteintrag enthalten");
            }
            else if(personbefore != null)
            {
                Console.WriteLine("Item vor gesuchter Person existiert.");
                Console.WriteLine("Person vor der agesuchten Person lautet: ");
                Console.WriteLine(personbefore);
            }

            else
            {
                Console.WriteLine("gesuchte Person ist in dieser Liste nicht enthalten");
            }

            */



            /*
            if (sll.Remove(p3))
            {
                Console.WriteLine("Person wurde nicht entfernt - Eintrag dazwischen wurde entfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Eintrag dazwischen");
            }

            Console.WriteLine(sll);
            */

            /* if (p == p2)
               {
                   Console.WriteLine("p und p2 sind gleich: ==");
               }
               else
               {
                   Console.WriteLine("p und p2 sind nicht gleich: ==");
               }

               if (p.Equals(p2))
               {
                   Console.WriteLine("p und p2 sind gleich.Equals()");
               }
               else
               {
                   Console.WriteLine("p und p2 sind nicht gleich:Equals()");
               }

               if (p == p3)
               {
                   Console.WriteLine("p und p2 sind gleich: ==");
               }
               else
               {
                   Console.WriteLine("p und p2 sind nicht gleich: ==");
               }

               if (p.Equals(p3))
               {
                   Console.WriteLine("p und p2 sind gleich.Equals()");
               }
               else
               {
                   Console.WriteLine("p und p2 sind nicht gleich:Equals()");
               }





               //Klasse SingleListItem testen

               SingleLinkedListItem<Person> item = new SingleLinkedListItem<Person>(p, null);
               //Console.WriteLine(item);

               //Klasse SLL Testen
               SingleLinkedList<Person> singleLL = new SingleLinkedList<Person>();
               if (singleLL.Add(p))
               {
                   Console.WriteLine("Person wurde hinzugefügt.");
               }
               else
               {
                   Console.WriteLine("Person konnte nicht hinzugefügt werden.");
               }
               if (singleLL.Add(new Person("Tobias", "Pflöckinger", new DateTime(2000,8,12))))
               {
                   Console.WriteLine("Person wurde hinzugefügt.");
               }
               else
               {
                   Console.WriteLine("Person konnte nicht hinzugefügt werden.");
               }
               if (singleLL.AddAfterItem(p, new Person("Raphael", "Garz", new DateTime(2001,10,4))))
               {
                   Console.WriteLine("Person wurde eingeschoben.");
               }

               Console.WriteLine();
               Console.WriteLine("Komplette Liste ausgeben:");
               Console.WriteLine(singleLL);


               */
            Console.ReadKey();

        }
    }
}
