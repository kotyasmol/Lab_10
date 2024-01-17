using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonstrationLabTen
{
    public class Part3
    {
        public static void RunPart3() // это мой новый мейн
        {

            Console.WriteLine("\nЧАСТЬ 3 - интерфейсы");
            Console.WriteLine("Реализация интерфейса IInit для класса Person");
            IInit initObject = new Person(); // Или Scholar, или Student, или PartTimeStudent
            initObject.Init();                // Вызов метода Init для инициализации объекта


            Console.WriteLine("Введите количество элементов (целое положительное число):");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
                    Console.Write("=> ");
                    continue;
                }
                // Создаем массив для всех типов
                Person[] peopleArray = new Person[n];
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    int randomType = random.Next(1, 5);

                    switch (randomType)
                    {
                        case 1:
                            peopleArray[i] = new Person();
                            peopleArray[i] = peopleArray[i].RandomInit();
                            break;
                        case 2:
                            peopleArray[i] = new Scholar();
                            peopleArray[i] = peopleArray[i].RandomInit();
                            break;
                        case 3:
                            peopleArray[i] = new Student();
                            peopleArray[i] = peopleArray[i].RandomInit();
                            break;
                        case 4:
                            peopleArray[i] = new PartTimeStudent();
                            peopleArray[i] = peopleArray[i].RandomInit();
                            break;
                    }
                }
                DisplayArrayInfo(peopleArray);



                Console.WriteLine("\nСортировка по имени");
                // Сортируем массив, используя метод Sort и интерфейс IComparable
                SortByName(peopleArray);
                // Выводим по имени
                foreach (var person in peopleArray)
                {
                    Console.WriteLine(person.ShowFullInfo());
                }

                Console.WriteLine("\nСортировка по возрасту");
                Array.Sort(peopleArray, (p1, p2) => p1.Age.CompareTo(p2.Age));
                // Выводим по возрасту
                foreach (var person in peopleArray)
                {
                    Console.WriteLine(person.ShowFullInfo());
                }

                Console.WriteLine("\nПоиск элемента по имени (например, имя = 'Bob'):");

                string searchName = Console.ReadLine();

                // Используем Array.FindAll для поиска всех элементов с указанным именем
                Person[] foundPeople = Array.FindAll(peopleArray, p => p.Name == searchName);

                if (foundPeople.Length > 0)
                {
                    Console.WriteLine("Найдены следующие элементы:");
                    foreach (var foundPerson in foundPeople)
                    {
                        Console.WriteLine(foundPerson.ShowFullInfo());
                    }
                }
                else
                {
                    Console.WriteLine("Элементы не найдены");
                }
                return;
            }
        }
           
        static void SortByName(Person[] array)
        {
            Array.Sort(array, (p1, p2) => p1.Name.CompareTo(p2.Name));
        }
        static void DisplayArrayInfo(Person[] array)
        {
            Console.WriteLine("Информация о массиве объектов:");

            foreach (var person in array)
            {
                Console.WriteLine(person.ShowFullInfo());
            }
        }

    }
}