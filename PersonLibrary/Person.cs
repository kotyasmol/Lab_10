namespace PersonLibrary
{
    public class Person 
    {
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
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
        public virtual Person Init() // ввод объекта класса с консоли
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
    }
}
