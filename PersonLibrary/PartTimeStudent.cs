using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class PartTimeStudent : Student
    {
        private static readonly string[] WorkPlaces = { "Yandex", "Mail.ru Group", "Kaspersky Lab", "Acronis", "JetBrains", "EPAM Systems", "ABBYY", "Luxoft" };
        private string work; // место работы - название компании
        public string Work 
        { 
            get { return work; }
            set {  work = value; } 
        }
        public PartTimeStudent() : base() // без параметров
        {
            work = "unemployed";
        }
        public PartTimeStudent(string name, int age, int year, string work) : base(name, age, year) // параметры
        {
            this.work = work;
        }
        public PartTimeStudent(PartTimeStudent otherPrtStudent) : base(otherPrtStudent) // копирование
        {
            this.work = otherPrtStudent.work;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Место работы: {work}");
        }
        public override Person Init() 
        {
            Student basePerson = (Student)base.Init();
            PartTimeStudent newPrtStudent = new PartTimeStudent
            {
                Name = basePerson.Name,
                Age = basePerson.Age,
                Year = basePerson.Year
            };

            Console.WriteLine("Место работы: ");
            string userWork;
            while (true) 
            {
                Console.WriteLine("Введите название компании:");
                userWork = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userWork) || string.IsNullOrEmpty(userWork) || userWork.Any(char.IsDigit))
                {
                    Console.WriteLine("Некорректный ввод! Строка не должна быть пустой и содержать цифры");
                    continue;
                }
                break;
            }
            newPrtStudent.Work = userWork;
            return newPrtStudent;
        }
        public override Person RandomInit()
        {
            Random random = new Random();
            Student basePerson = (Student)base.RandomInit();
            PartTimeStudent newPrtStudent = new PartTimeStudent
            {
                Name = basePerson.Name,
                Age = basePerson.Age,
                Year = basePerson.Year,
                Work = WorkPlaces[random.Next(WorkPlaces.Length)]
        };
            return newPrtStudent;
        }

        public override bool Equals(Person otherPerson) // ПОДУМАТЬ
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

        public override int GetHashCode() 
        {
            return HashCode.Combine(base.GetHashCode(), work);
        }
    }
}
