using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static PersonLibrary.Student;

namespace DemonstrationLabTen
{
    public class Part3
    {
        public static void RunPart3() // это мой новый мейн
        {
            Console.WriteLine("\nЧАСТЬ 3 - интерфейсы");
            Person[] locations = new Person[25];
            for (int i = 0; i < 10; ++i)
            {
                locations[i] = new Person();
                locations[i].RandomInit();
            }
            for (int i = 10; i < 15; ++i)
            {
                locations[i] = new Student();
                locations[i].RandomInit();
            }
            for (int i = 15; i < 20; ++i)
            {
                locations[i] = new Scholar();
                locations[i].RandomInit();
            }
            for (int i = 20; i < 25; ++i)
            {
                locations[i] = new PartTimeStudent();
                locations[i].RandomInit();
            }
            IInit[] inits = new IInit[20];
            for (int i = 0; i < 10; ++i)
            {
                inits[i] = new Animal();
                inits[i].RandomInit();
            }
            for (int i = 10; i < 15; ++i)
            {
                inits[i] = new Person();
                inits[i].RandomInit();
            }
            for (int i = 15; i < 20; ++i)
            {
                inits[i] = new Student();
                inits[i].RandomInit();
            }
            int choice1 = 0;
            do
            {
                Console.Clear();
                Console.Write(
                "0. Вернуться к общему меню\n" +
                "1. Отсортировать массив объектов по ИМЕНИ (используя IComparable)\n" +
                "2. Отсортировать массив объектов ВОЗРАСТУ (используя IComparer)\n" +
                "3. Найти элемент с заданным именем \n" +
                "4. Просмотр массива элементов типа IInit\n" +
                "5. Демонстрация работы методов клонирования IClonable\n");
                choice1 = CustomFunctions.InputInteger();
                CustomFunctions.CheckNumber(0, 5, ref choice1);
                switch (choice1)
                {
                    case 1:
                        Array.Sort(locations);
                        Console.WriteLine("Сортировка по Имени:");
                        ShowLocations(locations);
                        CustomFunctions.Pause();
                        break;
                    case 2:
                        Console.WriteLine("Сортировка по возрасту"); // почему
                        Array.Sort(locations, new SortByLatitude());
                        ShowLocations(locations);
                        CustomFunctions.Pause();
                        break;
                    case 3:
                        string longitude = CustomFunctions.InputString("Введите искомое имя");
                        Array.Sort(locations);
                        var res = SearchBinaryByName(locations, longitude);
                        res.Show();
                        Console.WriteLine(); // показывает только ПЕЕРВОЕ вхождение
                        CustomFunctions.Pause();
                        break;
                    case 4:
                        Console.WriteLine("Массив элементов типа IInit");
                        foreach (var item in inits)
                        {
                            item.Show();
                            Console.WriteLine();
                        }
                        CustomFunctions.Pause();
                        break;
                    case 5:
                        PartTimeStudent newItem = new PartTimeStudent();
                        newItem.RandomInit();
                        PartTimeStudent shallowCopyItem = CopyShallow(newItem);
                        PartTimeStudent deepCopyItem = CopyDeep(newItem);

                        Console.WriteLine("Поверхностное копирование (ShallowCopy):");
                        shallowCopyItem.Show();
                        Console.WriteLine();

                        Console.WriteLine("Глубокое копирование (Clone): ");
                        deepCopyItem.Show();
                        Console.WriteLine();

                        CustomFunctions.Pause();
                        break;
                }
            } while (choice1 > 0);
        }
        public static PartTimeStudent CopyShallow(PartTimeStudent copyAddress)
        {
            return copyAddress.ShallowCopy();
        }
        public static PartTimeStudent CopyDeep(PartTimeStudent copyAddress)
        {
            return (PartTimeStudent)copyAddress.Clone();
        }
        public static void ShowLocations(Person[] locations)
        {
            foreach (var item in locations)
            {
                item.Show();
                Console.WriteLine();
            }
        }
        public static Person SearchBinaryByName(Person[] people, string targetName)
        {
            int left = 0;
            int right = people.Length - 1;
            int middle;

            // Сортируем массив перед бинарным поиском
            Array.Sort(people, new SortByName());

            while (left <= right)
            {
                middle = (left + right) / 2;

                if (string.Equals(people[middle].Name, targetName, StringComparison.OrdinalIgnoreCase))
                {
                    return people[middle];
                }
                else if (string.Compare(people[middle].Name, targetName, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            // Если объект не найден, возвращаем null
            return null;
        }
    }
 }



