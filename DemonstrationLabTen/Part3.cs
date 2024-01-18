using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DemonstrationLabTen
{
    public class Part3
    {
        public static void RunPart3() // это мой новый мейн
        {
            Console.WriteLine("\nЧАСТЬ 3 - интерфейсы");
            IInit[] inits = new IInit[20];
            for (int i = 0; i < 10; ++i)
            {
                inits[i] = new Animal();
                inits[i].RandomInit();
            }
            for (int i = 10; i < 15; ++i)
            {
                inits[i] = new Location();
                inits[i].RandomInit();
            }
            for (int i = 15; i < 20; ++i)
            {
                inits[i] = new City();
                inits[i].RandomInit();
            }
            int choice1 = 0;
            do
            {
                Console.Clear();
                Console.Write(
                "0. Вернуться к общему меню\n" +
                "1. Отсортировать массив объектов по ВСТАВИТЬ ЧТО-ТО (используя IComparable)\n" +
                "2. Отсортировать массив объектов ВСТАВИТЬ ЧТО-ТО (используя IComparer)\n" +
                "3. Найти элемент ЧТО-ТО КАКОЙ-ТО \n" +
                "4. Просмотр массива элементов типа IInit\n" +
                "5. Демонстрация работы методов клонирования IClonable\n");
                choice1 = CustomFunctions.InputInteger();
                CustomFunctions.CheckNumber(0, 5, ref choice1);
                switch (choice1)
                {
                    case 1:
                        Array.Sort(locations);
                        Console.WriteLine("Сортировка по долготе:");
                        ShowLocations(locations);
                        CustomFunctions.Pause();
                        break;
                    case 2:
                        Console.WriteLine("Сортировка по широте");
                        Array.Sort(locations, new SortByLatitude());
                        ShowLocations(locations);
                        CustomFunctions.Pause();
                        break;
                    case 3:
                        double longitude = CustomFunctions.InputDouble("Введите долготу (значение от -180.0000 до 180.0000)");
                        CustomFunctions.CheckNumber(-180, 180, ref longitude);
                        Array.Sort(locations);
                        var res = SearchBinary(locations, longitude);
                        res.Show();
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

                        Console.WriteLine("Глубокое копирование (Clone): ");
                        deepCopyItem.Show();

                        CustomFunctions.Pause();
                        break;
                }
            } while (choice1 > 0);
        }
    }
 }



