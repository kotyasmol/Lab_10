using System.IO;
using System.Xml.Linq;

namespace PersonLibrary
{
    public class Person : IInit, IComparable, ICloneable
    {
        public static readonly string[] Names = { "John", "Alice", "Bob", "Eva", "Charlie", "Olivia", "Daniel", "Sophia" }; // нет необходимости перезаписывать поэтому readonly
        private string name; // не string? потому что не должен допускать NULL
        private int age;
        protected static Random random = new Random();
        //свойства
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        //конструкторы
        public Person() // конструктор по умолчанию
        {
            Name = "Noname";
            Age = age;
        }
        public Person(string name, int age) // конструктор с параметрами
        {
            Name = name;
            Age = age;
        }
        //методы
        virtual public void Show()
        {
            Console.Write($"Имя: {Name}  Возраст: {Age}  ");
        }
        public void ShowInfo()
        {
            Console.Write($"Имя: {Name}, Возраст: {Age}");
        }
        public virtual void Init()
        {
            string name = CustomFunctions.InputString("Введите имя (не должно быть пустым и содержать цифры)");
            Name = name;
            int age = CustomFunctions.InputInteger("Введите возраст ( от 1 до 99)");
            CustomFunctions.CheckNumber(1, 99, ref age);
            Age = age;

        }
        virtual public void RandomInit()
        {
            int randomIndex = random.Next(Names.Length);
            Name = Names[randomIndex];
            Age = (int)random.Next(1, 100);
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person loc = (Person)obj;
                return (Name == loc.Name) && (Age == loc.Age);
            }
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Person otherPerson = obj as Person;
            if (otherPerson != null)
                return string.Compare(this.Name, otherPerson.Name, StringComparison.Ordinal);
            else
                throw new ArgumentException("Object is not a Person");
        }
        public Person ShallowCopy() //поверхностное копирование
        {
            return (Person)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Person(Name, Age);
        }

        // НЕ ТРОГАТЬ ВСЁ ЧТО ВЫШЕ ( ЧАСТИ 1 И 2) 

        public override string ToString()
        {
            return $"{Age}:{Name}";
        }
    }

}
