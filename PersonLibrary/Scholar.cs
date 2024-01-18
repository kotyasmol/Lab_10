using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Scholar : Person
    {
        private int grade; // год обучения ( первый раз в первый класс)
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
        public override void Show()
        {
            base.Show(); // Вызываем базовый метод Show

            // Добавляем дополнительную информацию для Scholar
            Console.Write($"Год обучения (класс): {grade}");
        }
        public void ShowInfo()
        {
            Console.Write($"Имя: {Name}, Возраст: {Age}, Год обучения (класс): {grade}");
        }
        public override void Init()
        {
            base.Init();
            int sGrade = CustomFunctions.InputInteger("Введите класс в котором обучается школьник: ");
            CustomFunctions.CheckNumber(1, 11, ref sGrade);
            Grade = sGrade;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Grade = random.Next(1, 12);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Scholar scholar = (Scholar)obj;
                return base.Equals(obj) && (Grade == scholar.Grade);
            }
        }

        public Scholar ShallowCopy() //поверхностное копирование
        {
            return (Scholar)this.MemberwiseClone();
        }
        public object Clone()
        {
            // Вызываем Clone базового класса Person
            Person baseClone = (Person)base.Clone();

            // Создаем новый объект Scholar с клонированными значениями
            Scholar clonedScholar = new Scholar
            {
                Name = baseClone.Name,
                Age = baseClone.Age,
                Grade = this.Grade // Добавляем клонированное поле Grade
            };

            return clonedScholar;
        }

        // НЕ ТРОГАТЬ ВСЁ ЧТО ВЫШЕ ( ЧАСТИ 1 И 2) 
    }
}
