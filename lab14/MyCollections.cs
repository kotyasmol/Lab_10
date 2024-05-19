using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using lab13;
using PersonLibrary;

namespace LaboratoryWork_14
{
    internal class MyCollections
    {
        public List<City> list = new List<City>();
        public SortedDictionary<int, List<City>> sortedDictionary = new SortedDictionary<int, List<City>>();
        public MyCollections(int amount, int size)
        {
            for (int i = 0; i < amount; ++i)
            {
                list = new List<City>();
                for (int j = 0; j < size; ++j)
                {
                    City current = new City();
                    current.RandomInit();
                    list.Add(current);
                }
                sortedDictionary.Add(list.GetHashCode(), list);
            }
        }
    }
    public static class Query
    {
        public static IEnumerable<Location>
            WhereLINQ(SortedDictionary<int, List<City>> collection, int longitude)
        {
            return from f in collection
                   from el in f.Value
                   where el.Longitude > longitude
                   select el;
        }
        public static IEnumerable<Location>
            WhereExtension(this SortedDictionary<int, List<City>> collection, Func<City, bool> predicate)
        {
            var query =
                collection.Values
                .SelectMany(pair => pair)
                .Where(predicate)
                .Select(elem => elem);
            return query;
        }

        public static int
            CountLINQ(SortedDictionary<int, List<City>> collection, int populationCount)
        {
            return (from f in collection
                    from el in f.Value
                    where el.PopulationCount <= populationCount
                    select el).ToArray().Count();
        }
        public static int
            CountExtension(this SortedDictionary<int, List<City>> collection, Func<City, bool> predicate)
        {
            var query =
                collection.Values
                .SelectMany(pair => pair)
                .Where(predicate)
                .Select(elem => elem)
                .Count();
            return query;
        }

        public static IEnumerable<Location>
            UnionLINQ(SortedDictionary<int, List<City>> collection1, SortedDictionary<int, List<City>> collection2, string city)
        {
            var query = (from f in collection1
                         from el in f.Value
                         where el.CityName.Contains(city) == true
                         select el).Union(from f in collection2
                                          from el in f.Value
                                          where el.CityName.Contains(city) == true
                                          select el);

            return query;
        }

        public static IEnumerable<Location>
            UnionExtension(this SortedDictionary<int, List<City>> collection, SortedDictionary<int, List<City>> collection2, string city)
        {
            var query1 =
                collection.Values
                .SelectMany(pair => pair)
                .Where(elem => elem.CityName.Contains(city) == true)
                .Select(elem => elem);

            var query2 =
                collection2.Values
                .SelectMany(pair => pair)
                .Where(elem => elem.CityName.Contains(city))
                .Select(elem => elem);
            var result = query1.Union(query2);
            return result;
        }

        public static int
            AverageLINQ(SortedDictionary<int, List<City>> collection)
        {
            var query = ((int)(from f in collection
                               from el in f.Value
                               select el.PopulationCount).Average());

            return query;
        }
        public static int
            AverageExtension(this SortedDictionary<int, List<City>> collection)
        {
            var query =
                ((int)collection.Values
                .SelectMany(pair => pair)
                .Select(elem => elem.PopulationCount)
                .Average());

            return query;
        }

        public static void
            GroupLINQ(SortedDictionary<int, List<City>> collection)
        {
            var group = from f in collection
                        from el in f.Value
                        group el by el.CountryName;
            foreach (var signa in group)
            {
                Console.WriteLine("\t-> " + signa.Key + " - " + signa.Count() + " <-");
                foreach (var elem in signa)
                {
                    Console.WriteLine(elem.ToString() + "\n");
                }
            }

        }

        public static IEnumerable<IGrouping<string, Location>>
            GroupExtension(this SortedDictionary<int, List<City>> collection)
        {
            var query =
                collection.Values
                .SelectMany(pair => pair)
                .GroupBy(el => el.CountryName)
                .Select(elem => elem);
            return query;
        }

        // Для дерева
        public static IEnumerable<City>
            TreeSelectExtension(this NewTree<City> tree, Func<City, bool> predicate)
        {
            var query =
                tree.Tree.Select(elem => elem)
                .Where(predicate);
            return query;
        }
        public static IEnumerable<City>
            TreeSelectLINQ(NewTree<City> tree, string type)
        {
            var query = from el in tree.Tree
                        where el.CountryName.Contains(type)
                        select el;
            return query;
        }

        public static object
            TreeAggregateExtension(this NewTree<City> tree, Func<City, object> compare)
        {
            var query =
                tree.Tree.Select(elem => elem).Min(compare);
            return query;

        }
        public static int
            TreeAggregateLINQ(this NewTree<City> tree)
        {
            var query = (from el in tree.Tree
                         select el.PopulationCount).Min();
            return query;
        }

        public static IEnumerable<City>
            TreeOrderByDescendingExtension(this NewTree<City> tree, Func<City, object> predicate)
        {
            var query =
                tree.Tree.Select(elem => elem)
                .OrderByDescending(predicate);
            return query;
        }
        public static IEnumerable<City>
            TreeOrderByAscescendingLINQ(NewTree<City> tree)
        {
            var query = from el in tree.Tree
                        orderby el.PopulationCount
                        select el;
            return query;
        }
    }
}