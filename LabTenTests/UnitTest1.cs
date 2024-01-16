using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PersonLibrary;
namespace LabTenTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DefaultConstructor_ShouldSetNonameAndDefaultAge()
        {
            // Arrange
            Person person = new Person();

            // Assert
            Assert.AreEqual("Noname", person.Name);
            Assert.AreEqual(0, person.Age); // или любое значение, которое вы считаете подходящим
        }

        [TestMethod]
        public void CopyConstructor_ShouldCopyValues()
        {
            // Arrange
            Person originalPerson = new Person("John", 25);

            // Act
            Person copiedPerson = new Person(originalPerson);

            // Assert
            Assert.AreEqual(originalPerson.Name, copiedPerson.Name);
            Assert.AreEqual(originalPerson.Age, copiedPerson.Age);
        }

        [TestMethod]
        public void ParameterizedConstructor_ShouldSetValues()
        {
            // Arrange
            string expectedName = "Alice";
            int expectedAge = 30;

            // Act
            Person person = new Person(expectedName, expectedAge);

            // Assert
            Assert.AreEqual(expectedName, person.Name);
            Assert.AreEqual(expectedAge, person.Age);
        }

        [TestMethod]
        public void ShowMethod_ShouldPrintCorrectInfo()
        {
            // Arrange
            Person person = new Person("Bob", 40);

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                person.Show();

                // Assert
                string expectedOutput = $"Name: {person.Name}, Age: {person.Age}{Environment.NewLine}";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
        [TestMethod]
        public void InitMethod_ShouldReturnPersonWithValidInput()
        {
            // Arrange
            string nameInput = "John";
            string ageInput = "25";

            using (StringReader nameReader = new StringReader(nameInput))
            using (StringReader ageReader = new StringReader(ageInput))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(nameReader);
                Console.SetOut(sw);

                // Act
                Person person = new Person().Init();

                // Assert
                Assert.AreEqual("John", person.Name);
                Assert.AreEqual(25, person.Age);

                // Additional assertion for console output (if needed)
                string expectedOutput = $"Создайте нового человека!{Environment.NewLine}Имя:{Environment.NewLine}Возраст:{Environment.NewLine}";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [TestMethod]
        public void InitMethod_ShouldRepeatForInvalidName()
        {
            // Arrange
            string invalidNameInput = "\nJohn123\nAlice";
            string ageInput = "25";

            using (StringReader nameReader = new StringReader(invalidNameInput))
            using (StringReader ageReader = new StringReader(ageInput))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(nameReader);
                Console.SetOut(sw);

                // Act
                Person person = new Person().Init();

                // Assert
                Assert.AreEqual("Alice", person.Name); // последнее корректное имя должно быть установлено
                Assert.AreEqual(25, person.Age);

                // Additional assertion for console output (if needed)
                string expectedOutput = $"Создайте нового человека!{Environment.NewLine}Имя:{Environment.NewLine}Некорректный ввод! Имя не должно быть пустым и содержать цифры{Environment.NewLine}Имя:{Environment.NewLine}Возраст:{Environment.NewLine}";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
        [TestMethod]
        public void RandomInit_ShouldSetRandomNameAndAge()
        {
            // Arrange
            Person person = new Person();

            // Act
            person.RandomInit();

            // Assert
            Assert.IsNotNull(person.Name); // Проверяем, что имя не null
            Assert.IsFalse(string.IsNullOrWhiteSpace(person.Name)); // Проверяем, что имя не пустое или состоит только из пробелов
            Assert.IsTrue(person.Age >= 1 && person.Age <= 98); // Проверяем, что возраст в пределах от 1 до 98
        }

        [TestMethod]
        public void RandomInit_MultipleCalls_ShouldProduceDifferentResults()
        {
            // Arrange
            Person person = new Person();

            // Act
            person.RandomInit();
            string firstName = person.Name;
            int firstAge = person.Age;

            person.RandomInit();

            // Assert
            Assert.AreNotEqual(firstName, person.Name); // Убеждаемся, что новое имя отличается от предыдущего
            Assert.AreNotEqual(firstAge, person.Age); // Убеждаемся, что новый возраст отличается от предыдущего
        }
        [TestMethod]
        public void Init_ShouldSetUserInputNameAndAge()
        {
            // Arrange
            Person userPerson = new Person();
            using (StringReader input = new StringReader("John\n25\n"))
            {
                Console.SetIn(input);

                // Act
                userPerson.Init();

                // Assert
                Assert.AreEqual("John", userPerson.Name);
                Assert.AreEqual(25, userPerson.Age);
            }
        }
    }
}