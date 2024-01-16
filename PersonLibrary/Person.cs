namespace PersonLibrary
{
    public class Person 
    {
        private static readonly string[] Names = { "John", "Alice", "Bob", "Eva", "Charlie", "Olivia", "Daniel", "Sophia" }; // нет необходимости перезаписывать поэтому readonly
        private string name; // не string? потому что не должен допускать NULL
        private int age;

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
        public Person() // конструктор без параметров
        {
            Name = "Noname";
            Age = age;
        }
        public Person(Person person) // конструктор копирования
        {
            this.Name = person.Name;
            this.Age = person.Age;
        }
        public Person(string name, int age) // конструктор с параметрами
        {
            Name = name;
            Age = age;
        }
        public virtual void Show()
        {
            Console.Write($"Имя: {Name}, Возраст: {Age}");
        }
        public void ShowInfo()
        {
            Console.Write($"Имя: {Name}, Возраст: {Age}");
        }
        public virtual Person Init() // ввод объекта класса с консоли //невозможно протестировать на 100% потому что стек переполняется
        {
            int userAge;
            string userName;
            while (true)
            {
                Console.WriteLine("Создайте нового человека!");
                Console.WriteLine("Имя:");
                userName = Console.ReadLine();
                if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName) || userName.Any(char.IsDigit)) // если пустая или содержит цифры то continue;
                {
                    Console.WriteLine("Некорректный ввод! Имя не должно быть пустым и содержать цифры");
                    continue;
                }
                Console.WriteLine("Возраст:");
                if (!Int32.TryParse(Console.ReadLine(), out userAge) || userAge < 0 || userAge > 99)
                {
                    Console.WriteLine("Некорректный ввод! 0 < Возраст < 99");
                    continue;
                }
                break;
            }
            return new Person { Name = userName, Age = userAge };
        }
        public virtual Person RandomInit()
        {
            Random random = new Random();
            string randomName = Names[random.Next(Names.Length)]; // массив имен
            int randomAge = random.Next(1, 99);
            return new Person { Name = randomName, Age = randomAge };
        }
        public virtual bool Equals(Person otherPerson)
        {
            if (otherPerson == null)
            {
                return false;
            }

            // Сравниваем поля на равенство
            return Name == otherPerson.Name && Age == otherPerson.Age;
        }

        public override int GetHashCode() // метод нужен для вывода хэш кода (если равны то их хэ
        {
            return HashCode.Combine(Name, Age);
        }
    }
}
