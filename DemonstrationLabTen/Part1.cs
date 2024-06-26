﻿using PersonLibrary;
using System.Security.Cryptography.X509Certificates;
namespace DemonstrationLabTen;
public class Part1
{
    public static List<Person> persons = new List<Person>();
    public static void PrintMenu()
    {
        Console.WriteLine("1. Создание пустого объекта");
        Console.WriteLine("2. Создание рандомного объекта");
        Console.WriteLine("3. Создание пользовательского объекта");
        Console.WriteLine("4. Назад");
        Console.Write("=> ");
    }
    public static void Main()
    {
        Console.WriteLine("ЧАСТЬ 1 - создание иерархии классов");
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Работа с классом ПЕРСОНА");
            Console.WriteLine("2. Работа с классом СТУДЕНТ");
            Console.WriteLine("3. Работа с классом ЗАОЧНИК");
            Console.WriteLine("4. Работа с классом ШКОЛЬНИК");
            Console.WriteLine("5. Вывод созданных объектов");
            Console.WriteLine("6. Перейти ко второй части л/р 10 - динамическая идентификация типов");
            Console.WriteLine("7. Перейти к третьей части л/р 10 - интерфейсы");
            Console.Write("=> ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 7)
            {
                Console.WriteLine("Некорректный выбор. Пожалуйста, выберите от 1 до 7.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    WorkWithPerson();
                    break;
                case 2:
                    WorkWithStudent();
                    break;
                case 3:
                    WorkWithPartTimeStudent();
                    break;
                case 4:
                    WorkWithScholar();
                    break;
                case 5:
                    DisplayObjects();
                    break;
                case 6:
                    Part2.RunPart2();  // перейти ко второй части
                    return;
                case 7:
                    Part3.RunPart3();
                    return;
            }
        }
    }

    public static void WorkWithPerson() 
    {
        while (true)
        {
            Console.WriteLine("Работа с классом ПЕРСОНА:");
            PrintMenu();
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Некорректный выбор. Пожалуйста, выберите от 1 до 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    persons.Add(new Person());
                    break;
                case 2:
                    Person randomPerson = new Person();
                    randomPerson.RandomInit();
                    persons.Add(randomPerson);
                    break;
                case 3:
                    Person newPerson = new Person();
                    newPerson.Init();
                    persons.Add(newPerson);
                    break;
                case 4:
                    return;
            }
        }
    }

    public static void WorkWithStudent()
    {
        while (true)
        {
            Console.WriteLine("Работа с классом СТУДЕНТ:");
            PrintMenu();

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Некорректный выбор. Пожалуйста, выберите от 1 до 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    persons.Add(new Student());
                    break;
                case 2:
                    Student randomPerson = new Student();
                    randomPerson.RandomInit();
                    persons.Add(randomPerson);
                    break;
                case 3:
                    Student userPerson = new Student();
                    userPerson.Init();
                    persons.Add(userPerson);
                    break;
                case 4:
                    return;
            }
        }
    }

    public static void WorkWithPartTimeStudent()
    {
        while (true)
        {
            Console.WriteLine("Работа с классом PARTTIMESTUDENT:");
            PrintMenu();

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Некорректный выбор. Пожалуйста, выберите от 1 до 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    persons.Add(new PartTimeStudent());
                    break;
                case 2:
                    PartTimeStudent randomPerson = new PartTimeStudent();
                    randomPerson.RandomInit();
                    persons.Add(randomPerson);
                    break;
                case 3:
                    PartTimeStudent userPerson = new PartTimeStudent();
                    userPerson.Init();
                    persons.Add(userPerson);
                    break;
                case 4:
                    return;
            }
        }
    }

    public static void WorkWithScholar()
    {
        while (true)
        {
            Console.WriteLine("Работа с классом ШКОЛЬНИК:");
            PrintMenu();

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Некорректный выбор. Пожалуйста, выберите от 1 до 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    persons.Add(new SchoolStudent());
                    break;
                case 2:
                    SchoolStudent randomPerson = new SchoolStudent();
                    randomPerson.RandomInit();
                    persons.Add(randomPerson);
                    break;
                case 3:
                    SchoolStudent userPerson = new SchoolStudent();
                    userPerson.Init();
                    persons.Add(userPerson);
                    break;
                case 4:
                    return;
            }
        }
    }

    public static void DisplayObjects()
    {
        if (persons.Count == 0)
        {
            Console.WriteLine("Еще не создано ни одного объекта. Вернитесь и создайте объект.");
            return;
        }

        Console.WriteLine("Созданные объекты (виртуальный метод):");

        foreach (var person in persons)
        {
            Console.Write($"Тип: {person.GetType().Name}, ");
            person.Show();
            Console.WriteLine(); 
        }
        Console.WriteLine("\nСозданные объекты (метод):"); // заменить, здеесь нет нонвиртуал метода
        foreach (var person in persons)
        {
            Console.Write($"Тип: {person.GetType().Name}, ");
            person.Show();
            Console.WriteLine(); 
        }
    }
}
