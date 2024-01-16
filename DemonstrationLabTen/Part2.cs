using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonstrationLabTen
{
    public class Part2
    {
        static List<Person> persons = new List<Person>();
        public static void RunPart2() // это мой новый мейн
        {
            Console.WriteLine("ЧАСТЬ 2 - динамическая идентификация типов");
            Console.WriteLine("Введите количество объектов для создания:");
            Console.Write("=> ");
            while (true)
            { 
                if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
                    Console.Write("=> ");
                    continue;
                }
                CreateAndDisplayObjects(n);
                return;
            }
        }
        static void CreateAndDisplayObjects(int n)
        {
            // Создаем и заполняем объекты Person
            for (int i = 0; i < n; i++)
            {
                Person newPerson = new Person();
                newPerson = newPerson.RandomInit();
                persons.Add(newPerson);
            }
            // Создаем и заполняем объекты Scholar
            for (int i = 0; i < n; i++)
            {
                Scholar newScholar = new Scholar();
                newScholar = (Scholar)newScholar.RandomInit();
                persons.Add(newScholar);
            }
            // Создаем и заполняем объекты Student
            for (int i = 0; i < n; i++)
            {
                Student newStudent = new Student();
                newStudent = (Student)newStudent.RandomInit();
                persons.Add(newStudent);
            }
            // Создаем и заполняем объекты PartTimeStudent
            for (int i = 0; i < n; i++)
            {
                PartTimeStudent newPrtStudent = new PartTimeStudent();
                newPrtStudent = (PartTimeStudent)newPrtStudent.RandomInit();
                persons.Add(newPrtStudent);
            }
            // Выводим созданные объекты
            DisplayObjects();
        }

        static void DisplayObjects()
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("Еще не создано ни одного объекта. Вернитесь и создайте объект.");
                return;
            }

            Console.WriteLine("Созданные объекты:");

            foreach (var person in persons)
            {
                Console.Write($"Тип: {person.GetType().Name}, ");
                person.Show();
                Console.WriteLine(); // Добавляем пустую строку между объектами для читаемости
            }
        }
    }
}