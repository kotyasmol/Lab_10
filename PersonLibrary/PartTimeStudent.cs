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
            set { work = value; }
        }
        public PartTimeStudent() : base() // без параметров
        {
            work = "unemployed";
        }
        public PartTimeStudent(string name, int age, int year, string work) : base(name, age, year) // параметры
        {
            this.work = work;
        }
        public override void Show()
        {
            base.Show();
            Console.Write($", Место работы: {work}");
        }
        public void ShowInfo()
        {
            Console.Write($"Имя: {Name}, Возраст: {Age}, Курс: {Year}, Место работы: {work}");
        }
        public override void Init()
        {
            base.Init();
            string swork = CustomFunctions.InputString("Введите Название компании (не должно быть пустым и содержать цифры)");
            Work = swork;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            int randomIndex = random.Next(WorkPlaces.Length);
            Work = WorkPlaces[randomIndex];
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Student scholar = (Student)obj;
                return base.Equals(obj) && (Year == scholar.Year);
            }
        }

        public PartTimeStudent ShallowCopy() //поверхностное копирование
        {
            return (PartTimeStudent)this.MemberwiseClone();
        }
        public object Clone()
        {
            // Вызываем Clone базового класса Person
            Student baseClone = (Student)base.Clone();

            // Создаем новый объект Scholar с клонированными значениями
            PartTimeStudent clonedScholar = new PartTimeStudent
            {
                Name = baseClone.Name,
                Age = baseClone.Age,
                Year = baseClone.Year,
                Work = this.Work,
            };

            return clonedScholar;
        }
        // НЕ ТРОГАЙ


    }
}
