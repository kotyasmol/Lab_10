using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Student : Person
    {
        private int year; // год обучения
        public int Year
        {
            get { return year; }
            set { year = value; }
        } // гетсет
        public Student() : base() // без параметров
        {
            year = 1;
        }  //без параметров
        public Student(string name, int age, int year) : base(name, age) // параметры
        {
            this.year = year;
        } //с параметрами
        public override void Show()
        {
            base.Show();
            Console.Write($", Курс: {year}");
        } // виртуальный метод показа (использовать только его)
        public void ShowInfo()
        {
            Console.Write($"Имя: {Name}, Возраст: {Age}, Курс: {year}");
        } // метод показа - особо не нужен 

        public override void Init()
        {
            base.Init();
            int sYear = CustomFunctions.InputInteger("Введите курс ( от 1  до 6): ");
            CustomFunctions.CheckNumber(1,6, ref sYear);
            Year = sYear;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Year = random.Next(1, 7);
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

        public Student ShallowCopy() //поверхностное копирование
        {
            return (Student)this.MemberwiseClone();
        }
        public object Clone()
        {
            // Вызываем Clone базового класса Person
            Person baseClone = (Person)base.Clone();

            // Создаем новый объект Scholar с клонированными значениями
            Student clonedScholar = new Student
            {
                Name = baseClone.Name,
                Age = baseClone.Age,
                Year = this.Year // Добавляем клонированное поле Grade
            };

            return clonedScholar;
        }

        // НЕ ТРОГАТЬ ВСЁ ЧТО ВЫШЕ ( ЧАСТИ 1 И 2) 

    }
}
