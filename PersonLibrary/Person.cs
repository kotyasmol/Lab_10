using System.IO;
using System.Xml.Linq;

namespace PersonLibrary
{
    public class Person : IInit,  ICloneable, IComparable<Person>
    {
        protected static Random rnd = new Random();
        protected string name = "name";
        protected int age;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException("Ошибка: введённое значение не может являться именем!");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (age < 0)
                {
                    throw new ArgumentNullException("Ошибка: введённое значение не может являться возрастом!");
                }
                age = value;
            }
        }

        public Person() { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(Person other) : this(other.Name, other.Age) { }

        public virtual void Show()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Возраст: {Age}");
        }

        public virtual void Init()
        {
            Console.Write("Введите имя: ");
            Name = GetString();
            Console.Write("Введите возраст: ");
            Age = GetInt();
        }

        public virtual void RandomInit()
        {
            string[] names = { "John", "Alice", "Mary", "Vlad", "Andrew", "Sarah", "Boris", "July" };
            Name = names[rnd.Next(names.Length)];
            Age = rnd.Next(7, 70);
        }

        public int GetInt()
        {
            int x;
            string buf;
            bool correct;
            do
            {
                buf = Console.ReadLine();
                correct = int.TryParse(buf, out x);
                if (!correct)
                    Console.Write("Ошибка! Введите ещё раз.\n  ");
            }
            while (!correct);
            return x;
        }
        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}";
        }
        public string GetString()
        {
            string x;
            do
            {
                x = Console.ReadLine();
                if (x == null || x == "")
                    Console.Write("Ошибка: пустая строка. Введите ещё раз...\n  ");
            }
            while (x == null || x == "");
            return x;
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Age == person.Age;
        }

        public override int GetHashCode()
        {
            int hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + Name.GetHashCode(); // EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            return hashCode;
        }

        public virtual int CompareTo(Person other)
        {
            return string.Compare(Name, other.Name);
        }
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        // Метод для глубокого копирования
        public object Clone()
        {
            // Создаем новый объект PartTimeStudent
            PartTimeStudent cloned = new PartTimeStudent();

            // Копируем значения полей
            cloned.name = this.name;
            cloned.age = this.age;


            return cloned;
        }
    }
}
