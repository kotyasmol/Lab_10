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

            do
            {
                Console.WriteLine("\nВыберите опцию:");
                Console.WriteLine("1. Создать и отобразить объекты");
                Console.WriteLine("2. Студенты заданного курса");
                Console.WriteLine("3. Список людей младше заданного возраста");
                Console.WriteLine("4. Список людей с совпадающим именем");
                Console.WriteLine("5. Перейти к третьей части задания");
                Console.WriteLine("0. Назад");

                Console.Write("Ваш выбор: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 0 до 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nВведите количество объектов для создания:");
                        CreateAndDisplayObjects(GetValidNumberFromUser());
                        DisplayObjects();
                        break;

                    case 2:
                        RequestNumberOne();
                        break;

                    case 3:
                        RequestNumberTwo();
                        break;

                    case 4:
                        RequestNumberThree();
                        break;

                    case 5:
                        Console.WriteLine("Переход к третьей части задания...");
                        Part3.RunPart3();
                        break;

                    case 0:
                        Console.WriteLine("Выход из программы.");
                        return;

                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите опцию от 0 до 5.");
                        break;
                }
            } while (true);
        }

        static int GetValidNumberFromUser()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number) && number >= 0)
                {
                    return number;
                }

                Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
            }
        }
        static void CreateAndDisplayObjects(int n)
        {
            // Создаем и заполняем объекты Person
            for (int i = 0; i < n; i++)
            {
                Person newPerson = new Person();
                newPerson.RandomInit();
                persons.Add(newPerson);
            }
            // Создаем и заполняем объекты Scholar
            for (int i = 0; i < n; i++)
            {
                SchoolStudent newScholar = new SchoolStudent();
                newScholar.RandomInit();
                persons.Add(newScholar);
            }
            // Создаем и заполняем объекты Student
            for (int i = 0; i < n; i++)
            {
                Student newStudent = new Student();
                newStudent.RandomInit();
                persons.Add(newStudent);
            }
            // Создаем и заполняем объекты PartTimeStudent
            for (int i = 0; i < n; i++)
            {
                PartTimeStudent newPrtStudent = new PartTimeStudent();
                newPrtStudent.RandomInit();
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
                Console.WriteLine();
            }
        }
        // ПЕРВЫЙ ЗАПРОС
        static void RequestNumberOne()
        {
            while (true)
            {
                Console.WriteLine("\nЗапрос #1 - Студенты заданного курса \nВведите порядковый номер курса (от 1 до 6):");
                Console.Write("=> ");

                if (!int.TryParse(Console.ReadLine(), out int targetCourse) || targetCourse < 1 || targetCourse > 6)
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 1 до 6.");
                }
                else
                {
                    var studentsByCourse = GetStudentsByCourse(targetCourse);

                    Console.WriteLine($"Студенты на курсе {targetCourse}:");
                    foreach (var student in studentsByCourse)
                    {
                        Console.Write($"Тип: {student.GetType().Name}, ");
                        student.Show();
                        Console.WriteLine();
                    }
                    break; // Выходим из цикла, так как ввод корректен
                }
            }
        }
        static List<Person> GetStudentsByCourse(int targetCourse)
        {
            List<Person> studentsByCourse = new List<Person>();

            foreach (var person in persons)
            {
                if (person is Student student && student.Age == targetCourse)
                {
                    studentsByCourse.Add(person);
                }
                else if (person is PartTimeStudent partTimeStudent && partTimeStudent.Age == targetCourse)
                {
                    studentsByCourse.Add(person);
                }
            }

            return studentsByCourse;
        }
        // ВТОРОЙ ЗАПРОС
        static void RequestNumberTwo()
        {
            while (true)
            {
                Console.WriteLine("\nЗапрос #2 - Список людей младше заданного возраста \nВведите максимальный возраст:");
                Console.Write("=> ");

                if (!int.TryParse(Console.ReadLine(), out int maxAge) || maxAge <= 0 || maxAge >= 100)
                {
                    Console.WriteLine("Некорректный ввод. Введите положительное число от 1 до 99.");
                }
                else
                {
                    var peopleYoungerThanMaxAge = GetPeopleYoungerThanMaxAge(maxAge);

                    Console.WriteLine($"Люди младше {maxAge} лет:");
                    foreach (var person in peopleYoungerThanMaxAge)
                    {
                        Console.Write($"Тип: {person.GetType().Name}, ");
                        person.Show();
                        Console.WriteLine();
                    }
                    break; // Выходим из цикла, так как ввод корректен
                }
            }
        }
        static List<Person> GetPeopleYoungerThanMaxAge(int maxAge)
        {
            List<Person> peopleYoungerThanMaxAge = new List<Person>();

            foreach (var person in persons)
            {
                if (person.Age < maxAge)
                {
                    peopleYoungerThanMaxAge.Add(person);
                }
            }

            return peopleYoungerThanMaxAge;
        }
        // ТРЕТИЙ ЗАПРОС
        static void RequestNumberThree()
        {
            while (true)
            {
                Console.WriteLine("\nЗапрос #3 - Список людей с совпадающим именем\n В генераторе имён есть только: \"John\", \"Alice\", \"Bob\", \"Eva\", \"Charlie\", \"Olivia\", \"Daniel\", \"Sophia\" \nВведите имя:");
                Console.Write("=> ");

                string targetName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(targetName))
                {
                    Console.WriteLine("Некорректный ввод. Имя не должно быть пустым.");
                }
                else
                {
                    var peopleWithMatchingName = GetPeopleWithMatchingName(targetName);

                    if (peopleWithMatchingName.Count == 0)
                    {
                        Console.WriteLine($"Нет людей с именем {targetName}.");
                    }
                    else
                    {
                        Console.WriteLine($"Люди с именем {targetName}:");
                        foreach (var person in peopleWithMatchingName)
                        {
                            Console.Write($"Тип: {person.GetType().Name}, ");
                            person.Show();
                            Console.WriteLine();
                        }
                    }

                    break; // Выходим из цикла, так как ввод корректен
                }
            }
        }
        static List<Person> GetPeopleWithMatchingName(string targetName)
        {
            List<Person> peopleWithMatchingName = new List<Person>();

            foreach (var person in persons)
            {
                if (person.Name.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                {
                    peopleWithMatchingName.Add(person);
                }
            }

            return peopleWithMatchingName;
        }

    }
}