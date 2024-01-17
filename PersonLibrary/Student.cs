using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Student : Person, IInit, IComparable<Person>, IComparer<Person>
    {
        private int year; // год обучения
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public Student() : base() // без параметров
        {
            year = 0;
        }
        public Student(string name, int age, int year) : base(name, age) // параметры
        {
            this.year = year;
        }
        public Student(Student otherStudent) : base(otherStudent) // копирование
        {
            this.year = otherStudent.year;
        }
        public override void Show()
        {
            base.Show();
            Console.Write($", Курс: {year}");
        }
        public void ShowInfo()
        {
            Console.Write($"Имя: {Name}, Возраст: {Age}, Курс: {year}");
        }

        public override string ShowFullInfo()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Курс: {Year}";
        }

        public override int CompareTo(Person other)
        {
            int baseComparison = base.CompareTo(other);
            if (baseComparison != 0)
            {
                return baseComparison;
            }

            if (other is Student student)
            {
                // Сравниваем по Year, если other является Student
                return this.Year.CompareTo(student.Year);
            }

            return 0;
        }
        public override int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }

        public override Person Init() // ВОЗМОЖНО есть смысл добавить специальность но это если тебе делать нехуй, в рандом тоже тогда ( с массивом специальностей)
        {
            Person basePerson = base.Init();
            Student newStudent = new Student
            {
                Name = basePerson.Name,
                Age = basePerson.Age
            };

            Console.WriteLine("Курс: ");
            int userYear;
            while (true)
            {
                Console.WriteLine("Введите год обучения (от 1 до 6):  ");
                if (!Int32.TryParse(Console.ReadLine(), out userYear) || userYear < 1 || userYear > 6)
                {
                    Console.WriteLine("Некорректный ввод! 1 <= Год обучения <= 6");
                    continue;
                }
                break;
            }
            newStudent.Year = userYear;
            return newStudent;
        }
        public override Person RandomInit()
        {
            Random random = new Random();
            Person basePerson = base.RandomInit();
            Student newStudent = new Student
            {
                Name = basePerson.Name,
                Age = random.Next(18, 98), 
                Year = random.Next(1, 7) 
            };
            return newStudent;
        }

        public override bool Equals(Person otherPerson)
        {
            if (otherPerson == null)
            {
                return false;
            }
            if (!base.Equals(otherPerson))
            {
                return false;
            }
            if (otherPerson is Student otherStudent)
            {
                return year == otherStudent.year;
            }
            return false;
        }

        public override int GetHashCode() // отладка
        {
            return HashCode.Combine(base.GetHashCode(), year);
        }
    }
}
