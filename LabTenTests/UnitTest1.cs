using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PersonLibrary;
using DemonstrationLabTen;
namespace LabTenTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Student_DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            Student student = new Student();

            // Assert
            Assert.AreEqual("", student.Name); // Assuming the base class Person has an empty string as default
            Assert.AreEqual(0, student.Age); // Assuming the base class Person has 0 as default
            Assert.AreEqual(0, student.Year);
        }

        [TestMethod]
        public void Student_ParameterizedConstructor_ShouldInitializeWithGivenValues()
        {
            // Arrange
            Student student = new Student("John", 20, 3);

            // Assert
            Assert.AreEqual("John", student.Name);
            Assert.AreEqual(20, student.Age);
            Assert.AreEqual(3, student.Year);
        }


        [TestMethod]
        public void Student_CompareTo_ShouldReturnCorrectComparison()
        {
            // Arrange
            Student student1 = new Student("Bob", 25, 2);
            Student student2 = new Student("Charlie", 25, 3);

            // Act
            int result = student1.CompareTo(student2);

            // Assert
            Assert.IsTrue(result < 0); // Assuming the comparison is based on age first, then year
        }
        [TestMethod]
        public void Student_ShowFullInfo_ShouldReturnFullInformationString()
        {
            // Arrange
            Student student = new Student("Mark", 21, 5);

            // Act
            string result = student.ShowFullInfo();

            // Assert
            Assert.AreEqual($"Name: Mark, Age: 21, Курс: 5", result);
        }

        [TestMethod]
        public void Student_Init_ShouldReturnNewStudentWithUserProvidedYear()
        {
            // Arrange
            var mockConsoleInput = new System.IO.StringReader("4");
            System.Console.SetIn(mockConsoleInput);

            // Act
            Student result = (Student)new Student().Init();

            // Assert
            Assert.AreEqual(4, result.Year);
        }

        [TestMethod]
        public void Student_RandomInit_ShouldReturnNewStudentWithRandomValues()
        {
            // Arrange
            // Assuming RandomInit doesn't interact with the console

            // Act
            Student result = (Student)new Student().RandomInit();

            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(result.Name));
            Assert.IsTrue(result.Age >= 18 && result.Age <= 98);
            Assert.IsTrue(result.Year >= 1 && result.Year <= 6);
        }

        [TestMethod]
        public void Student_Equals_ShouldReturnTrueForEqualStudents()
        {
            // Arrange
            Student student1 = new Student("John", 20, 3);
            Student student2 = new Student("John", 20, 3);

            // Act
            bool result = student1.Equals(student2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Student_Equals_ShouldReturnFalseForDifferentStudents()
        {
            // Arrange
            Student student1 = new Student("Alice", 22, 4);
            Student student2 = new Student("Bob", 25, 2);

            // Act
            bool result = student1.Equals(student2);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Student_ToString_ShouldReturnFormattedString()
        {
            // Arrange
            Student student = new Student("Sophie", 23, 6);

            // Act
            string result = student.ToString();

            // Assert
            Assert.AreEqual($"Name: Sophie, Age: 23, Курс: 6", result);
        }

        [TestMethod]
        public void Student_Compare_ShouldReturnCorrectComparison()
        {
            // Arrange
            Student student1 = new Student("Emma", 28, 4);
            Student student2 = new Student("Olivia", 22, 4);

            // Act
            int result = student1.Compare(student1, student2);

            // Assert
            Assert.IsTrue(result > 0); // Assuming the comparison is based on age
        }

        [TestMethod]
        public void Student_Init_WithInvalidInput_ShouldRetryUntilValidInput()
        {
            // Arrange
            var mockConsoleInput = new System.IO.StringReader("invalid\n3");
            System.Console.SetIn(mockConsoleInput);

            // Act
            Student result = (Student)new Student().Init();

            // Assert
            Assert.AreEqual(3, result.Year);
        }

        [TestMethod]
        public void Student_Equals_ShouldReturnFalseForNullInput()
        {
            // Arrange
            Student student = new Student("James", 25, 5);

            // Act
            bool result = student.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Student_GetHashCode_ShouldNotThrowException()
        {
            // Arrange
            Student student = new Student("David", 30, 3);

            // Act & Assert
            Assert.IsNotNull(student.GetHashCode());
        }
        [TestMethod]
        public void Student_CopyConstructor_ShouldCreateCopyWithSameValues()
        {
            // Arrange
            Student originalStudent = new Student("Alice", 22, 4);

            // Act
            Student copiedStudent = new Student(originalStudent);

            // Assert
            Assert.AreEqual(originalStudent.Name, copiedStudent.Name);
            Assert.AreEqual(originalStudent.Age, copiedStudent.Age);
            Assert.AreEqual(originalStudent.Year, copiedStudent.Year);
        }
        [TestMethod]
        public void Scholar_DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            Scholar scholar = new Scholar();

            // Assert
            Assert.AreEqual("", scholar.Name);
            Assert.AreEqual(0, scholar.Age);
            Assert.AreEqual(0, scholar.Grade);
        }

        [TestMethod]
        public void Scholar_ParameterizedConstructor_ShouldInitializeWithGivenValues()
        {
            // Arrange
            Scholar scholar = new Scholar("John", 15, 9);

            // Assert
            Assert.AreEqual("John", scholar.Name);
            Assert.AreEqual(15, scholar.Age);
            Assert.AreEqual(9, scholar.Grade);
        }

        [TestMethod]
        public void Scholar_CopyConstructor_ShouldCreateCopyWithSameValues()
        {
            // Arrange
            Scholar originalScholar = new Scholar("Alice", 14, 8);

            // Act
            Scholar copiedScholar = new Scholar(originalScholar);

            // Assert
            Assert.AreEqual(originalScholar.Name, copiedScholar.Name);
            Assert.AreEqual(originalScholar.Age, copiedScholar.Age);
            Assert.AreEqual(originalScholar.Grade, copiedScholar.Grade);
        }

        [TestMethod]
        public void Scholar_CompareTo_ShouldReturnCorrectComparison()
        {
            // Arrange
            Scholar scholar1 = new Scholar("Bob", 15, 10);
            Scholar scholar2 = new Scholar("Charlie", 14, 10);

            // Act
            int result = scholar1.CompareTo(scholar2);

            // Assert
            Assert.IsTrue(result > 0); // Assuming the comparison is based on age
        }

        [TestMethod]
        public void Scholar_Init_WithInvalidInput_ShouldRetryUntilValidInput()
        {
            // Arrange
            var mockConsoleInput = new System.IO.StringReader("invalid\n5");
            System.Console.SetIn(mockConsoleInput);

            // Act
            Scholar result = (Scholar)new Scholar().Init();

            // Assert
            Assert.AreEqual(5, result.Grade);
        }

        [TestMethod]
        public void Scholar_Equals_ShouldReturnTrueForEqualScholars()
        {
            // Arrange
            Scholar scholar1 = new Scholar("James", 13, 8);
            Scholar scholar2 = new Scholar("James", 13, 8);

            // Act
            bool result = scholar1.Equals(scholar2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Scholar_Equals_ShouldReturnFalseForDifferentScholars()
        {
            // Arrange
            Scholar scholar1 = new Scholar("Alice", 14, 7);
            Scholar scholar2 = new Scholar("Bob", 15, 10);

            // Act
            bool result = scholar1.Equals(scholar2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Scholar_GetHashCode_ShouldNotThrowException()
        {
            // Arrange
            Scholar scholar = new Scholar("David", 13, 6);

            // Act & Assert
            Assert.IsNotNull(scholar.GetHashCode());
        }
        [TestMethod]
        public void PartTimeStudent_DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            PartTimeStudent prtStudent = new PartTimeStudent();

            // Assert
            Assert.AreEqual("", prtStudent.Name);
            Assert.AreEqual(0, prtStudent.Age);
            Assert.AreEqual(0, prtStudent.Year);
            Assert.AreEqual("unemployed", prtStudent.Work);
        }

        [TestMethod]
        public void PartTimeStudent_ParameterizedConstructor_ShouldInitializeWithGivenValues()
        {
            // Arrange
            PartTimeStudent prtStudent = new PartTimeStudent("John", 25, 3, "Microsoft");

            // Assert
            Assert.AreEqual("John", prtStudent.Name);
            Assert.AreEqual(25, prtStudent.Age);
            Assert.AreEqual(3, prtStudent.Year);
            Assert.AreEqual("Microsoft", prtStudent.Work);
        }

        [TestMethod]
        public void PartTimeStudent_CopyConstructor_ShouldCreateCopyWithSameValues()
        {
            // Arrange
            PartTimeStudent originalPrtStudent = new PartTimeStudent("Alice", 22, 4, "Google");

            // Act
            PartTimeStudent copiedPrtStudent = new PartTimeStudent(originalPrtStudent);

            // Assert
            Assert.AreEqual(originalPrtStudent.Name, copiedPrtStudent.Name);
            Assert.AreEqual(originalPrtStudent.Age, copiedPrtStudent.Age);
            Assert.AreEqual(originalPrtStudent.Year, copiedPrtStudent.Year);
            Assert.AreEqual(originalPrtStudent.Work, copiedPrtStudent.Work);
        }

        [TestMethod]
        public void PartTimeStudent_ShowInfo_ShouldReturnFormattedString()
        {
            // Arrange
            PartTimeStudent prtStudent = new PartTimeStudent("Emma", 23, 6, "Apple");

            // Act
            string result = prtStudent.ShowFullInfo();

            // Assert
            Assert.AreEqual("Имя: Emma, Возраст: 23, Курс: 6, Место работы: Apple", result);
        }

        [TestMethod]
        public void PartTimeStudent_CompareTo_ShouldReturnCorrectComparison()
        {
            // Arrange
            PartTimeStudent prtStudent1 = new PartTimeStudent("Bob", 25, 2, "IBM");
            PartTimeStudent prtStudent2 = new PartTimeStudent("Charlie", 25, 3, "IBM");

            // Act
            int result = prtStudent1.CompareTo(prtStudent2);

            // Assert
            Assert.IsTrue(result < 0); // Assuming the comparison is based on year
        }

        [TestMethod]
        public void PartTimeStudent_Init_WithInvalidInput_ShouldRetryUntilValidInput()
        {
            // Arrange
            var mockConsoleInput = new System.IO.StringReader("invalid\nMicrosoft");
            System.Console.SetIn(mockConsoleInput);

            // Act
            PartTimeStudent result = (PartTimeStudent)new PartTimeStudent().Init();

            // Assert
            Assert.AreEqual("Microsoft", result.Work);
        }

        [TestMethod]
        public void PartTimeStudent_Equals_ShouldReturnTrueForEqualPartTimeStudents()
        {
            // Arrange
            PartTimeStudent prtStudent1 = new PartTimeStudent("James", 23, 5, "Intel");
            PartTimeStudent prtStudent2 = new PartTimeStudent("James", 23, 5, "Intel");

            // Act
            bool result = prtStudent1.Equals(prtStudent2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PartTimeStudent_Equals_ShouldReturnFalseForDifferentPartTimeStudents()
        {
            // Arrange
            PartTimeStudent prtStudent1 = new PartTimeStudent("Alice", 22, 4, "Microsoft");
            PartTimeStudent prtStudent2 = new PartTimeStudent("Bob", 25, 2, "IBM");

            // Act
            bool result = prtStudent1.Equals(prtStudent2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PartTimeStudent_GetHashCode_ShouldNotThrowException()
        {
            // Arrange
            PartTimeStudent prtStudent = new PartTimeStudent("David", 30, 3, "Samsung");

            // Act & Assert
            Assert.IsNotNull(prtStudent.GetHashCode());
        }

        [TestMethod]
        public void PartTimeStudent_RandomInit_ShouldReturnNewPartTimeStudentWithRandomValues()
        {
            // Arrange
            // Assuming RandomInit doesn't interact with the console

            // Act
            PartTimeStudent result = (PartTimeStudent)new PartTimeStudent().RandomInit();

            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(result.Name));
            Assert.IsTrue(result.Age >= 18 && result.Age <= 98);
            Assert.IsTrue(result.Year >= 1 && result.Year <= 6);
        }
        [TestMethod]
        public void NameComparer_Compare_ShouldReturnNegativeValueWhenXNameIsLessThanYName()
        {
            // Arrange
            Person person1 = new Person { Name = "Alice" };
            Person person2 = new Person { Name = "Bob" };
            NameComparer comparer = new NameComparer();

            // Act
            int result = comparer.Compare(person1, person2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void NameComparer_Compare_ShouldReturnZeroWhenXNameEqualsYName()
        {
            // Arrange
            Person person1 = new Person { Name = "Charlie" };
            Person person2 = new Person { Name = "Charlie" };
            NameComparer comparer = new NameComparer();

            // Act
            int result = comparer.Compare(person1, person2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NameComparer_Compare_ShouldReturnPositiveValueWhenXNameIsGreaterThanYName()
        {
            // Arrange
            Person person1 = new Person { Name = "David" };
            Person person2 = new Person { Name = "Alice" };
            NameComparer comparer = new NameComparer();

            // Act
            int result = comparer.Compare(person1, person2);

            // Assert
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void WorkWithPerson_CreateEmptyObject_ShouldAddPersonToPersonsList()
        {
            // Arrange
            var part1 = new Part1();
            var mockConsoleInput = new StringReader("1\n1\n");
            System.Console.SetIn(mockConsoleInput);

            // Act
            Part1.WorkWithPerson();

            // Assert
            Assert.AreEqual(1, Part1.persons.Count);
        }

        [TestMethod]
        public void WorkWithPerson_CreateRandomObject_ShouldAddRandomPersonToPersonsList()
        {
            // Arrange
            var part1 = new Part1();
            var mockConsoleInput = new StringReader("2\n1\n");
            System.Console.SetIn(mockConsoleInput);

            // Act
            Part1.WorkWithPerson();

            // Assert
            Assert.AreEqual(1, Part1.persons.Count);
            Assert.IsInstanceOfType(Part1.persons[0], typeof(Person));
        }

        [TestMethod]
        public void WorkWithPerson_CreateUserObject_ShouldAddUserPersonToPersonsList()
        {
            // Arrange
            var part1 = new Part1();
            var mockConsoleInput = new StringReader("3\nJohn\n25\n");
            System.Console.SetIn(mockConsoleInput);

            // Act
            Part1.WorkWithPerson();

            // Assert
            Assert.AreEqual(1, Part1.persons.Count);
            Assert.AreEqual("John", Part1.persons[0].Name);
            Assert.AreEqual(25, Part1.persons[0].Age);
        }

        [TestMethod]
        public void WorkWithStudent_CreateEmptyObject_ShouldAddStudentToPersonsList()
        {
            // Arrange
            var part1 = new Part1();
            var mockConsoleInput = new StringReader("1\n2\n");
            System.Console.SetIn(mockConsoleInput);

            // Act
            Part1.WorkWithStudent();

            // Assert
            Assert.AreEqual(1, Part1.persons.Count);
            Assert.IsInstanceOfType(Part1.persons[0], typeof(Student));
        }

        // Add more test methods for other scenarios...

        [TestMethod]
        public void DisplayObjects_NoObjectsCreated_ShouldPrintNoObjectsMessage()
        {
            // Arrange
            var part1 = new Part1();
            Part1.persons.Clear(); // Ensure no objects are created

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Part1.DisplayObjects();
                string result = sw.ToString().Trim();

                // Assert
                StringAssert.Contains(result, "Еще не создано ни одного объекта");
            }
        }

        [TestMethod]
        public void DisplayObjects_ObjectsCreated_ShouldPrintObjectInfo()
        {
            // Arrange
            var part1 = new Part1();
            Part1.persons.Clear(); // Ensure no objects are created
            Part1.persons.Add(new Person { Name = "Alice", Age = 25 });
            Part1.persons.Add(new Student { Name = "Bob", Age = 22, Year = 3 });
            Part1.persons.Add(new PartTimeStudent { Name = "Charlie", Age = 30, Year = 6, Work = "Microsoft" });

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Part1.DisplayObjects();
                string result = sw.ToString().Trim();

                // Assert
                StringAssert.Contains(result, "Тип: Person, Имя: Alice, Возраст: 25");
                StringAssert.Contains(result, "Тип: Student, Имя: Bob, Возраст: 22, Курс: 3");
                StringAssert.Contains(result, "Тип: PartTimeStudent, Имя: Charlie, Возраст: 30, Курс: 6, Место работы: Microsoft");
            }
        }
    }
}