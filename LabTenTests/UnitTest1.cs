using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PersonLibrary;
using DemonstrationLabTen;
using static PersonLibrary.Student;
namespace LabTenTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void PartTimeStudentTest()
        {
            PartTimeStudent student = new PartTimeStudent();
            Assert.IsNotNull(student);
        }

        [TestMethod()]
        public void PartTimeStudentTest1()
        {
            PartTimeStudent student = new PartTimeStudent("Александр", 19, "ПНИПУ", "ПНИПУ");
            Assert.AreEqual(student.Name, "Александр");
            Assert.AreEqual(student.Age, 19);
            Assert.AreEqual(student.University, "ПНИПУ");
            Assert.AreEqual(student.Employer, "ПНИПУ");
        }

        [TestMethod()]
        public void PartTimeStudentTest2()
        {
            PartTimeStudent student = new PartTimeStudent();
            PartTimeStudent student2 = new PartTimeStudent(student);
            Assert.IsNotNull(student2);
        }

        [TestMethod()]
        public void RandomInitTest()
        {
            PartTimeStudent student = new PartTimeStudent();
            student.RandomInit();
            Assert.AreNotEqual(student.Name, "name");
            Assert.AreNotEqual(student.Age, 0);
            Assert.AreNotEqual(student.University, "university");
            Assert.AreNotEqual(student.Employer, "employer");
        }

        [TestMethod()]
        public void EqualsTest()
        {
            PartTimeStudent student = new PartTimeStudent();
            student.RandomInit();
            PartTimeStudent student2 = new PartTimeStudent(student);
            Assert.IsTrue(student2.Equals(student));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            PartTimeStudent student = new PartTimeStudent();
            student.RandomInit();
            Assert.IsNotNull(student.GetHashCode());
        }
        [TestMethod()]
        public void CompareTest()
        {
            Person person = new Person();
            person.RandomInit();
            Person person2 = new Person(person);
            PersonAge personAge = new PersonAge();
            Assert.AreEqual(personAge.Compare(person, person2), 0);
        }
        [TestMethod()]
        public void PersonTest()
        {
            Person person = new Person();
            Assert.IsNotNull(person);
        }

        [TestMethod()]
        public void PersonTest1()
        {
            Person person = new Person("Александр", 19);
            Assert.AreEqual(person.Name, "Александр");
            Assert.AreEqual(person.Age, 19);
        }

        [TestMethod()]
        public void PersonTest2()
        {
            Person person = new Person();
            Person person2 = new Person(person);
            Assert.IsNotNull(person2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTest3()
        {
            Person person = new Person("", 19);
        }

        [TestMethod()]
        public void RandomInitTest3()
        {
            Person person = new Person();
            person.RandomInit();
            Assert.AreNotEqual(person.Name, "name");
            Assert.AreNotEqual(person.Age, 0);
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Person person = new Person();
            person.RandomInit();
            Person person2 = new Person(person);
            Assert.IsTrue(person2.Equals(person));
        }

        [TestMethod()]
        public void GetHashCodeTest2()
        {
            Person person = new Person();
            person.RandomInit();
            Assert.IsNotNull(person.GetHashCode());
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Person person = new Person();
            person.RandomInit();
            Person person2 = new Person(person);
            Assert.AreEqual(person.CompareTo(person2), 0);
        }

        [TestMethod()]
        public void CloneTest()
        {
            Person person = new Person();
            person.RandomInit();
            Person person2 = (Person)person.Clone();
            Assert.AreEqual((Person)person, person2);
        }
        [TestMethod()]
        public void PlantTest()
        {
            Plant plant = new Plant();
            Assert.IsNotNull(plant);
        }

        [TestMethod()]
        public void PlantTest1()
        {
            Plant plant = new Plant("Роза", "Дикая");
            Assert.AreEqual(plant.Name, "Роза");
            Assert.AreEqual(plant.Description, "Дикая");
        }

        [TestMethod()]
        public void PlantTest2()
        {
            Plant plant = new Plant();
            Plant plant2 = new Plant(plant);
            Assert.IsNotNull(plant2);
        }

        [TestMethod()]
        public void CloneTest7()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Plant plant2 = (Plant)plant.Clone();
            Assert.AreEqual((Plant)plant, plant2);
        }

        [TestMethod()]
        public void RandomInitTest5()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Assert.AreNotEqual(plant.Name, "name");
            Assert.AreNotEqual(plant.Description, "description");
        }

        [TestMethod()]
        public void ShallowCopyTest()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Plant plant2 = (Plant)plant.ShallowCopy();
            Assert.AreEqual((Plant)plant, plant2);
        }

        [TestMethod()]
        public void EqualsTest4()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Plant plant2 = new Plant(plant);
            Assert.IsTrue(plant2.Equals(plant));
        }

        [TestMethod()]
        public void GetHashCodeTest6()
        {
            Plant plant = new Plant();
            plant.RandomInit();
            Assert.IsNotNull(plant.GetHashCode());
        }
        [TestMethod()]
        public void SchoolStudentTest()
        {
            SchoolStudent student = new SchoolStudent();
            Assert.IsNotNull(student);
        }

        [TestMethod()]
        public void SchoolStudentTest1()
        {
            SchoolStudent student = new SchoolStudent("Александр", 19, "Лицей №1");
            Assert.AreEqual(student.Name, "Александр");
            Assert.AreEqual(student.Age, 19);
            Assert.AreEqual(student.School, "Лицей №1");
        }

        [TestMethod()]
        public void SchoolStudentTest2()
        {
            SchoolStudent student = new SchoolStudent();
            SchoolStudent student2 = new SchoolStudent(student);
            Assert.IsNotNull(student2);
        }

        [TestMethod()]
        public void RandomInitTest7()
        {
            SchoolStudent student = new SchoolStudent();
            student.RandomInit();
            Assert.AreNotEqual(student.Name, "name");
            Assert.AreNotEqual(student.Age, 0);
            Assert.AreNotEqual(student.School, "school");
        }

        [TestMethod()]
        public void EqualsTest7()
        {
            SchoolStudent student = new SchoolStudent();
            student.RandomInit();
            SchoolStudent student2 = new SchoolStudent(student);
            Assert.IsTrue(student2.Equals(student));
        }

        [TestMethod()]
        public void GetHashCodeTest7()
        {
            SchoolStudent student = new SchoolStudent();
            student.RandomInit();
            Assert.IsNotNull(student.GetHashCode());
        }
        [TestMethod()]
        public void StudentTest()
        {
            Student student = new Student();
            Assert.IsNotNull(student);
        }

        [TestMethod()]
        public void StudentTest1()
        {
            Student student = new Student("Александр", 19, "ПНИПУ");
            Assert.AreEqual(student.Name, "Александр");
            Assert.AreEqual(student.Age, 19);
            Assert.AreEqual(student.University, "ПНИПУ");
        }

        [TestMethod()]
        public void StudentTest2()
        {
            Student student = new Student();
            Student student2 = new Student(student);
            Assert.IsNotNull(student2);
        }

        [TestMethod()]
        public void RandomInitTest4()
        {
            Student student = new Student();
            student.RandomInit();
            Assert.AreNotEqual(student.Name, "name");
            Assert.AreNotEqual(student.Age, 0);
            Assert.AreNotEqual(student.University, "university");
        }

        [TestMethod()]
        public void EqualsTest41()
        {
            Student student = new Student();
            student.RandomInit();
            Student student2 = new Student(student);
            Assert.IsTrue(student2.Equals(student));
        }

        [TestMethod()]
        public void GetHashCodeTest4()
        {
            Student student = new Student();
            student.RandomInit();
            Assert.IsNotNull(student.GetHashCode());
        }
    }
}                          