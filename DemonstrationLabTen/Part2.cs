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
                RequestNumberOne();
                RequestNumberTwo();
               
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
                Console.WriteLine();
            }
        }
        static List<string> GetNamesOfStudentsByCourse(int targetCourse)
        {
            List<string> result = new List<string>();

            foreach (var person in persons)
            {
                if (person is Student || person is PartTimeStudent) // Проверяем, что объект является Student или PartTimeStudent
                {
                    int year = GetCourseFromPerson(person);
                    if (year == targetCourse)
                    {
                        string name = GetNameFromPerson(person);
                        result.Add(name);
                    }
                }
            }
            return result;
        }
        static int GetCourseFromPerson(Person person)
        {
            // Используем динамическую идентификацию типа
            if (person is Student student)
            {
                return student.Year;
            }
            else if (person is PartTimeStudent partTimeStudent)
            {
                return partTimeStudent.Year;
            }

            return 0; // Если не является ни Student, ни PartTimeStudent
        }

        static string GetNameFromPerson(Person person)
        {
            return person.Name;
        }
        static void RequestNumberOne() // ЗАПРОС 1
        {
            Console.WriteLine("\nЗапрос #1 - Имена студентов заданного курса \n Введите порядковый номер курса (от 1 до 6):");
            Console.Write("=> ");
            if (!int.TryParse(Console.ReadLine(), out int targetCourse) || targetCourse < 1 || targetCourse > 6)
            {
                Console.WriteLine("Некорректный ввод. Введите число от 1 до 6.");
                return;
            }
            List<string> namesOfStudents = GetNamesOfStudentsByCourse(targetCourse);
            Console.WriteLine($"Имена студентов заданного курса ({targetCourse}):");
            foreach (var name in namesOfStudents)
            {
                Console.Write($"Форма обучения: {name.GetType().Name}, "); // ПОДУМАТЬ
                Console.WriteLine(name);
            }
        }
        static void RequestNumberTwo() // ЗАПРОС 2
        {
            Console.WriteLine("Введите возраст для поиска студентов старше:");
            if (!int.TryParse(Console.ReadLine(), out int targetAge) || targetAge < 1 || targetAge > 99)
            {
                Console.WriteLine("Некорректный ввод. Введите число от 1 до 99.");
                return;
            }

            static List<string> GetNamesOfStudentsOlderThanAge(int targetAge)
            {
                List<string> result = new List<string>();

                foreach (var person in persons)
                {
                    if (person is Student || person is PartTimeStudent) // Проверяем, что объект является Student или PartTimeStudent
                    {
                        int age = GetAgeFromPerson(person);
                        if (age > targetAge)
                        {
                            string name = GetNameFromPerson(person);
                            result.Add(name);
                        }
                    }
                }
                return result;
            }

            static int GetAgeFromPerson(Person person)
            {
                // Используем динамическую идентификацию типа
                if (person is Student student)
                {
                    return student.Age;
                }
                else if (person is PartTimeStudent partTimeStudent)
                {
                    return partTimeStudent.Age;
                }

                return -1; // Если не является ни Student, ни PartTimeStudent
            }

            static string GetNameFromPerson(Person person)
            {
                return person.Name;
            }

            List<string> namesOfStudents = GetNamesOfStudentsOlderThanAge(targetAge);

            // Выводим результат
            Console.WriteLine($"Имена студентов старше {targetAge} лет:");
            foreach (var name in namesOfStudents)
            {
                Console.WriteLine(name);
            }
        }
    }
}