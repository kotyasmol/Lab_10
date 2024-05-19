using System;
using System.Collections.Generic;
using System.Linq;
using LaboratoryWork_13;
using LaboratoryWork_12;
using PersonLibrary;


namespace LaboratoryWork_14
{
    internal class Program
    {
        static void Menu()
        {
            MyCollections col = new MyCollections(3, 3);
            Tree<City> cityTree = new Tree<City>();
            for (int i = 0; i < 7; i++)
            {
                City city = new City();
                city.RandomInit();
                cityTree.Add(city);
            }
            NewTree<City> newTree = new NewTree<City>(cityTree, "дуб");

            int choice;
            City сity;
            IEnumerable<Location> result = null;

            do
            {
                Console.Clear();
                Console.WriteLine("\tМЕНЮ\n"
                    + "0. Выход\n"
                    + " ПЕРВАЯ ЧАСТЬ\n"
                    + "1. Where-запрос\n"
                    + "2. Count-запрос\n"
                    + "3. Union-запрос\n"
                    + "4. Average-запрос\n"
                    + "5. Group-запрос\n"
                    + " ВТОРАЯ ЧАСТЬ\n"
                    + "6. Выборка данных для дерева\n"
                    + "7. Агрегирование данных для дерева\n"
                    + "8. Сортировка дерева (по другому ключу)");
                choice = CustomFunctions.InputInteger("Введите число: ");
                switch (choice)
                {
                    case 0:
                        {
                            Console.WriteLine("Завершение работы программы");
                            break;
                        }
                    case 1: // 
                        {
                            Console.Clear();
                            Console.WriteLine("\t-| Коллекция |-");
                            Print(col.sortedDictionary);
                            var v = CustomFunctions.InputInteger("1: LINQ\n2: Метод расширения\n 1 или 2: ");
                            var longitude = CustomFunctions.InputInteger("Выведутся все объекты, долготой больше заданной.\nВведите долготу: ");
                            switch (v)
                            {
                                case 1:
                                    {
                                        result = Query.WhereLINQ(col.sortedDictionary, longitude);

                                        break;
                                    }
                                case 2:
                                    {
                                        result = col.sortedDictionary.WhereExtension(el => el.Longitude > longitude);
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Выберите 1 или 2");
                                        break;
                                    }
                            }
                            foreach (var elem in result)
                            {
                                Console.WriteLine(elem.ToString() + "\n");
                            }
                            CustomFunctions.Pause();
                            break;
                        }
                    case 2: //
                        {
                            Console.Clear();
                            Console.WriteLine("\t-| Коллекция |-");
                            Print(col.sortedDictionary);
                            var v = CustomFunctions.InputInteger("1: LINQ\n2: Метод расширения\n 1 или 2: ");
                            var populationCount = CustomFunctions.InputInteger("Выведутся все города с населением, меньше заданного. Введите население: ");
                            switch (v)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Кол-во объектов: " + Query.CountLINQ(col.sortedDictionary, populationCount));
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Кол-во объектов: " + col.sortedDictionary.CountExtension(el => el.PopulationCount < populationCount));
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Выберите 1 или 2");
                                        break;
                                    }
                            }
                            CustomFunctions.Pause();
                            break;
                        }
                    case 3: //
                        {
                            Console.Clear();
                            Console.WriteLine("\t-| Коллекция |-");
                            Print(col.sortedDictionary);
                            MyCollections newcol = new MyCollections(3, 3);
                            Console.WriteLine("\n\t-| НОВАЯ КОЛЛЕКЦИЯ |-");
                            Print(newcol.sortedDictionary);
                            var v = CustomFunctions.InputInteger("Выведется объединение всех городов с окончанием \"град\"\n1: LINQ\n2: Метод расширения\n 1 или 2: ");
                            switch (v)
                            {
                                case 1:
                                    {
                                        result = Query.UnionLINQ(col.sortedDictionary, newcol.sortedDictionary, "град");

                                        break;
                                    }
                                case 2:
                                    {
                                        result = col.sortedDictionary.UnionExtension(newcol.sortedDictionary, "град");
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Выберите 1 или 2");
                                        break;
                                    }
                            }
                            Console.WriteLine("\t!РЕЗУЛЬТАТ!: " + result.Count() + " объектов.");

                            foreach (var elem in result)
                            {
                                Console.WriteLine(elem.ToString() + "\n");
                            }

                            CustomFunctions.Pause();
                            break;
                        }
                    case 4: // 
                        {
                            Console.Clear();
                            Console.WriteLine("\t-| Коллекция |-");
                            Print(col.sortedDictionary);
                            var v = CustomFunctions.InputInteger("Выведется среднее население городов\n1: LINQ\n2: Метод расширения\n 1 или 2: ");
                            switch (v)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Среднее население: " + Query.AverageLINQ(col.sortedDictionary));
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Среднее население: " + col.sortedDictionary.AverageExtension());
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Выберите 1 или 2");
                                        break;
                                    }
                            }
                            CustomFunctions.Pause();
                            break;
                        }
                    case 5: // 
                        {
                            Console.Clear();
                            Console.WriteLine("\t-| Коллекция |-");
                            Print(col.sortedDictionary);
                            var v = CustomFunctions.InputInteger("Выведутся группы городов по странам\n1: LINQ\n2: Метод расширения\n 1 или 2: ");
                            IEnumerable<IGrouping<string, Location>> group = null;
                            switch (v)
                            {
                                case 1:
                                    {
                                        Query.GroupLINQ(col.sortedDictionary);

                                        break;
                                    }
                                case 2:
                                    {
                                        group = col.sortedDictionary.GroupExtension();
                                        foreach (var signa in group)
                                        {
                                            Console.WriteLine("\t-> " + signa.Key + " <-");
                                            foreach (var elem in signa)
                                            {
                                                Console.WriteLine(elem.ToString() + "\n");
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Выберите 1 или 2");
                                        break;
                                    }
                            }
                            CustomFunctions.Pause();
                            break;
                        }
                    case 6: // 
                        {
                            Console.Clear();
                            Console.WriteLine("\t-| Дерево |-");
                            newTree.Tree.Print();
                            var v = CustomFunctions.InputInteger("1: LINQ\n2: Метод расширения\n 1 или 2: ");
                            string type = "";
                            switch (v)
                            {
                                case 1:
                                    {
                                        type = " ";
                                        result = Query.TreeSelectLINQ(newTree, type);
                                        break;
                                    }
                                case 2:
                                    {
                                        type = " ";
                                        result = newTree.TreeSelectExtension(el => el.CountryName.Contains(type));

                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Выберите 1 или 2");
                                        break;
                                    }
                            }
                            Console.WriteLine($"Объекты, содержащие в названии страны пробел\n");
                            foreach (var el in result)
                            {
                                Console.WriteLine(el.ToString() + "\n");
                            }
                            CustomFunctions.Pause();
                            break;
                        }
                    case 7: // 
                        {
                            Console.Clear();
                            Console.WriteLine("\t-| Дерево |-");
                            newTree.Tree.Print();
                            var v = CustomFunctions.InputInteger("1: LINQ\n2: Метод расширения\n 1 или 2: ");
                            object minimum = new object();
                            switch (v)
                            {
                                case 1:
                                    {
                                        minimum = newTree.TreeAggregateLINQ();
                                        Console.WriteLine("Минимальное население: " + minimum.ToString() + "\n");
                                        break;
                                    }
                                case 2:
                                    {
                                        minimum = newTree.TreeAggregateExtension(el => el.PopulationCount);
                                        Console.WriteLine("Минимальное население: " + minimum.ToString() + "\n");
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Выберите 1 или 2");
                                        break;
                                    }
                            }
                            CustomFunctions.Pause();
                            break;
                        }
                    case 8: // 
                        {
                            Console.Clear();
                            Console.WriteLine("\t-| Дерево |-");
                            newTree.Tree.Print();
                            var v = CustomFunctions.InputInteger("1: LINQ\n2: Метод расширения\n 1 или 2: ");

                            switch (v)
                            {
                                case 1:
                                    {
                                        result = Query.TreeOrderByAscescendingLINQ(newTree);
                                        break;
                                    }
                                case 2:
                                    {
                                        result = newTree.TreeOrderByDescendingExtension(el => el.PopulationCount);
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Выберите 1 или 2");
                                        break;
                                    }
                            }
                            Console.WriteLine("Отсортированная по населению последовательность");
                            foreach (var el in result)
                            {
                                Console.WriteLine(el.ToString() + "\n");
                            }
                            CustomFunctions.Pause();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Выберите из списка");
                            break;
                        }
                }
            } while (choice != 0);
        }
        static void Print(SortedDictionary<int, List<City>> collection)
        {
            int i = 0;
            foreach (var v in collection)
            {
                Console.WriteLine($"\t Коллекция {++i}");
                foreach (var elem in v.Value)
                {
                    Console.WriteLine(elem.ToString() + "\n");
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
