using PersonLibrary;
namespace lab13
{
    public class Program
    {
        static void Main(string[] args)
        {
            NewTree<Person> newTree1 = new NewTree<Person>(new Tree<Person>(), "Первое дерево");
            NewTree<Person> newTree2 = new NewTree<Person>(new Tree<Person>(), "Второе дерево"); 
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            newTree1.CollectionCountChanged += new CollectionHandler(journal1.CollectionCountChanged);
            newTree1.CollectionTriedToFind += new CollectionHandler(journal1.CollectionTriedToFind);

            newTree1.CollectionTriedToFind += new CollectionHandler(journal2.CollectionTriedToFind);
            newTree2.CollectionTriedToFind += new CollectionHandler(journal2.CollectionTriedToFind);

            Person loc1 = new Person("Alice", 17);
            Person loc2 = new Person("Bob", 35);
            Person loc3 = new Person("John", 60);
            Console.WriteLine("Добавление в коллекцию 1");
            newTree1.Add(loc1);
            newTree1.Add(loc2);
            newTree1.Add(loc3);
            newTree1.Print();

            Console.WriteLine("\n\nДобвление в коллекцию 2");
            newTree2.Add(loc1);
            newTree2.Add(loc2);
            newTree2.Add(loc3);
            newTree2.Print();


            Console.WriteLine("\n\nПоиск в коллеции 1");
            if (newTree1.Contains(loc1))
            {
                Console.WriteLine("Элемент найден!");
            }
            Console.WriteLine("Поиск в коллеции 2");
            if (newTree2.Contains(loc2))
            {
                Console.WriteLine("Элемент найден!");
            }

            Console.WriteLine("\n\nУдаление в коллеции 1");
            if (newTree1.Remove(loc1))
            {
                Console.WriteLine("Элемент удален!");
            }
            Console.WriteLine("Удаление в коллеции 2");
            if (newTree2.Remove(loc2))
            {
                Console.WriteLine("Элемент удален!");
            }

            Console.WriteLine("\n\n ЖУРНАЛ 1");
            journal1.Show();
            Console.WriteLine("\n\n ЖУРНАЛ 2");
            journal2.Show();
        }
    }
}
