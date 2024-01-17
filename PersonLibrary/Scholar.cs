using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Scholar : Person, IInit, IComparable<Person>, IComparer<Person>
    {
        private int grade; // год обучения
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Scholar() : base() // без параметров
        {
            grade = 0;
        }
        public Scholar(string name, int age, int grade) : base(name, age) // параметры
        {
            this.grade = grade;
        }
        public Scholar(Scholar otherScholar) : base(otherScholar) // копирование
        {
            this.grade = otherScholar.grade;
        }

        public override string ShowFullInfo()
        {
            return this.ToString();
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Год обучения (класс): {Grade}";
        }

        public override int CompareTo(Person other)
        {
            int baseComparison = base.CompareTo(other);
            if (baseComparison != 0)
            {
                return baseComparison;
            }

            if (other is Scholar scholar)
            {
                // Сравниваем по Grade, если other является Scholar
                return this.Grade.CompareTo(scholar.Grade);
            }

            return 0;
        }
        public override int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
        public override void Show()
        {
            base.Show(); // Вызываем базовый метод Show

            // Добавляем дополнительную информацию для Scholar
            Console.Write($", Год обучения (класс): {grade}");
        }
        public void ShowInfo()
        {
            Console.Write($"Имя: {Name}, Возраст: {Age}, Год обучения (класс): {grade}");
        }
        public override Person Init()
        {
            Person basePerson = base.Init();
            Scholar newScholar = new Scholar
            {
                Name = basePerson.Name,
                Age = basePerson.Age
            };

            // Логика ввода года обучения
            Console.WriteLine("Год обучения (класс): ");
            int userGrade;
            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out userGrade) || userGrade < 1 || userGrade > 11)
                {
                    Console.WriteLine("Некорректный ввод! 1 <= Год обучения <= 11");
                    continue;
                }
                break;
            }
            newScholar.Grade = userGrade;
            return newScholar;
        }
        public override Person RandomInit()
        {
            Random random = new Random();
            // Вызываем базовый метод RandomInit из класса Person
            Person basePerson = base.RandomInit();
            // Создаем новый объект Scholar, используя базовый объект Person
            Scholar newScholar = new Scholar
            {
                Name = basePerson.Name,
                Age = random.Next(7, 18), // изменено потому что 80 летние обычно не ходят в школу, но если передумаешь то можно вернуть на место Age = basePeson.Age
                Grade = random.Next(1, 12) // Пример логики для инициализации Grade для Scholar
            };

            return newScholar;
        }

        public override bool Equals(Person otherPerson)
        {
            if (otherPerson == null)
            {
                return false;
            }
            // Вызываем базовый Equals из класса Person
            if (!base.Equals(otherPerson))
            {
                return false;
            }
            // Сравниваем дополнительные свойства класса Scholar
            if (otherPerson is Scholar otherScholar)
            {
                return grade == otherScholar.grade;
            }

            // Если объект не является Scholar, считаем их не равными
            return false;
        }

        public override int GetHashCode() // отладка
        {
            return HashCode.Combine(base.GetHashCode(), grade);
        }
    }
}
