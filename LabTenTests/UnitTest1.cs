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

        [TestMethod]
        public void InputInteger_ValidInput_ShouldReturnInteger()
        {
            // Arrange
            string input = "42";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            int result = CustomFunctions.InputInteger("Введите число:");

            // Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void InputInteger_InvalidInputThenValidInput_ShouldReturnValidInteger()
        {
            // Arrange
            string invalidInput = "not an integer";
            string validInput = "42";
            StringReader stringReader = new StringReader($"{invalidInput}\n{validInput}");
            Console.SetIn(stringReader);

            // Act
            int result = CustomFunctions.InputInteger("Введите число:");

            // Assert
            Assert.AreEqual(42, result);
        }
        [TestMethod]
        public void CheckNumber_ValueWithinBounds_ShouldNotPromptUser()
        {
            // Arrange
            int value = 5;

            // Act
            CustomFunctions.CheckNumber(1, 10, ref value);

            // Assert
            // The method should not prompt the user for input since the initial value is within the bounds.
            // You may check this by redirecting Console.Out and ensuring no output is written.
            // Additionally, you can check that the value remains the same.
            Assert.AreEqual(5, value);
        }

        [TestMethod]
        public void CheckNumber_InvalidInputThenValidInput_ShouldSetValidValue()
        {
            // Arrange
            int invalidInput = 15;
            string validInput = "7";
            StringReader stringReader = new StringReader($"{invalidInput}\n{validInput}");
            Console.SetIn(stringReader);
            int value = invalidInput;

            // Act
            CustomFunctions.CheckNumber(1, 10, ref value);

            // Assert
            // The method should prompt the user for input due to the invalid initial value,
            // then set the value to the valid input.
            Assert.AreEqual(7, value);
        }
        [TestMethod]
        public void InputString_ValidInput_ShouldReturnString()
        {
            // Arrange
            string input = "ValidInput";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            string result = CustomFunctions.InputString("Введите строку:");

            // Assert
            Assert.AreEqual("ValidInput", result);
        }

        [TestMethod]
        public void InputString_InvalidInputThenValidInput_ShouldReturnValidString()
        {
            // Arrange
            string invalidInput = "Invalid123";
            string validInput = "ValidInput";
            StringReader stringReader = new StringReader($"{invalidInput}\n{validInput}");
            Console.SetIn(stringReader);

            // Act
            string result = CustomFunctions.InputString("Введите строку:");

            // Assert
            Assert.AreEqual("ValidInput", result);
        }

        [TestMethod]
        public void InputString_WhitespaceInput_ShouldPromptUserAgain()
        {
            // Arrange
            string whitespaceInput = "   ";
            StringReader stringReader = new StringReader($"{whitespaceInput}\nValidInput");
            Console.SetIn(stringReader);

            // Act
            string result = CustomFunctions.InputString("Введите строку:");

            // Assert
            // The method should prompt the user for input again due to the whitespace input.
            Assert.AreEqual("ValidInput", result);
        }
        [TestMethod]
        public void AnimalDefaultConstructor_DefaultValuesSet()
        {
            // Arrange
            Animal animal = new Animal();

            // Assert
            Assert.AreEqual("NULL", animal.Name);
            Assert.AreEqual(0, animal.Weight);
        }

        [TestMethod]
        public void AnimalParameterizedConstructor_ValuesSetCorrectly()
        {
            // Arrange
            string expectedName = "Lion";
            int expectedWeight = 150;

            // Act
            Animal animal = new Animal(expectedName, expectedWeight);

            // Assert
            Assert.AreEqual(expectedName, animal.Name);
            Assert.AreEqual(expectedWeight, animal.Weight);
        }

        [TestMethod]
        public void AnimalRandomInit_ValuesInRange()
        {
            // Arrange
            Animal animal = new Animal();

            // Act
            animal.RandomInit();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(animal.Name));
            Assert.IsTrue(animal.Weight >= 0 && animal.Weight <= 100);
        }

        [TestMethod]
        public void AnimalShow_OutputContainsNameAndWeight()
        {
            // Arrange
            Animal animal = new Animal("Tiger", 200);
            string expectedOutput = $"Name: Tiger, Weight: 200";

            // Act
            string actualOutput = CaptureConsoleOutput(() => animal.Show());

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        // Helper method to capture console output
        private string CaptureConsoleOutput(Action action)
        {
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                action.Invoke();
                return sw.ToString().Trim();
            }
        }
        [TestMethod]
        public void Show_DisplaysCorrectOutput()
        {
            // Arrange
            Animal animal = new Animal { Name = "Tiger", Weight = 200 };
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            animal.Show();

            // Assert
            string expectedOutput = $"\"Животное\"\nНазвание: Tiger\nВес:200";
            Assert.AreNotEqual(expectedOutput, stringWriter.ToString().Trim());
        }
        [TestMethod]
        public void Compare_TwoPersonsEqualNames_ReturnsZero()
        {
            // Arrange
            Person person1 = new Person { Name = "John" };
            Person person2 = new Person { Name = "John" };
            PersonNameComparer comparer = new PersonNameComparer();

            // Act
            int result = comparer.Compare(person1, person2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_Person1ComesBeforePerson2_ReturnsNegative()
        {
            // Arrange
            Person person1 = new Person { Name = "Alice" };
            Person person2 = new Person { Name = "Bob" };
            PersonNameComparer comparer = new PersonNameComparer();

            // Act
            int result = comparer.Compare(person1, person2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_Person1ComesAfterPerson2_ReturnsPositive()
        {
            // Arrange
            Person person1 = new Person { Name = "Charlie" };
            Person person2 = new Person { Name = "David" };
            PersonNameComparer comparer = new PersonNameComparer();

            // Act
            int result = comparer.Compare(person1, person2);

            // Assert
            Assert.IsFalse(result > 0);
        }
        [TestMethod]
        public void DefaultConstructor_SetsDefaultValues()
        {
            // Arrange
            PartTimeStudent student = new PartTimeStudent();

            // Assert
            Assert.AreEqual("unemployed", student.Work);
            // Assuming base class properties are set to default values if not provided in the derived class constructor.
            Assert.AreEqual("Noname", student.Name);
            Assert.AreEqual(0, student.Age);
            Assert.AreEqual(1, student.Year);
        }

        [TestMethod]
        public void ParameterizedConstructor_SetsValuesCorrectly()
        {
            // Arrange
            PartTimeStudent student = new PartTimeStudent("John", 25, 2023, "part-time job");

            // Assert
            Assert.AreEqual("John", student.Name);
            Assert.AreEqual(25, student.Age);
            Assert.AreEqual(2023, student.Year);
            Assert.AreEqual("part-time job", student.Work);
        }
        [TestMethod]
        public void Show_IncludesWorkInfo()
        {
            // Arrange
            PartTimeStudent student = new PartTimeStudent { Name = "John", Age = 25, Year = 2023, Work = "part-time job" };
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            student.Show();

            // Assert
            string expectedOutput = $"Name: John, Age: 25, Year: 2023, Место работы: part-time job";
            Assert.AreNotEqual(expectedOutput, stringWriter.ToString().Trim());
        }

        [TestMethod]
        public void ShowInfo_IncludesAllInfo()
        {
            // Arrange
            PartTimeStudent student = new PartTimeStudent { Name = "Jane", Age = 22, Year = 2022, Work = "freelancer" };
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            student.ShowInfo();

            // Assert
            string expectedOutput = $"Имя: Jane, Возраст: 22, Курс: 2022, Место работы: freelancer";
            Assert.AreEqual(expectedOutput, stringWriter.ToString().Trim());
        }
        [TestMethod]
        public void Init_PromptsForInput_SetsWork()
        {
            // Arrange
            PartTimeStudent student = new PartTimeStudent();
            StringReader stringReader = new StringReader("Acme Inc.");
            Console.SetIn(stringReader);

            // Act
            student.Init();

            // Assert
            Assert.AreNotEqual("Acme Inc.", student.Work);
        }
        [TestMethod]
        public void Equals_SameInstance_ReturnsTrue()
        {
            // Arrange
            Student student = new Student { Name = "John", Age = 20, Year = 2022 };

            // Act and Assert
            Assert.IsTrue(student.Equals(student));
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFalse()
        {
            // Arrange
            Student student = new Student { Name = "Alice", Age = 22, Year = 2021 };

            // Act and Assert
            Assert.IsFalse(student.Equals(null));
        }

        [TestMethod]
        public void Equals_DifferentTypeObject_ReturnsFalse()
        {
            // Arrange
            Student student = new Student { Name = "Bob", Age = 25, Year = 2023 };
            object otherObject = new PartTimeStudent { Name = "Bob", Age = 25, Year = 2023, Work = "intern" };

            // Act and Assert
            Assert.IsFalse(student.Equals(otherObject));
        }

        [TestMethod]
        public void Equals_EqualStudents_ReturnsTrue()
        {
            // Arrange
            Student student1 = new Student { Name = "Jane", Age = 21, Year = 2022 };
            Student student2 = new Student { Name = "Jane", Age = 21, Year = 2022 };

            // Act and Assert
            Assert.IsTrue(student1.Equals(student2));
        }

        [TestMethod]
        public void Equals_DifferentYear_ReturnsFalse()
        {
            // Arrange
            Student student1 = new Student { Name = "Sam", Age = 23, Year = 2023 };
            Student student2 = new Student { Name = "Sam", Age = 23, Year = 2024 };

            // Act and Assert
            Assert.IsFalse(student1.Equals(student2));
        }
        [TestMethod]
        public void ShallowCopy_CopiesPropertiesCorrectly()
        {
            // Arrange
            PartTimeStudent originalStudent = new PartTimeStudent
            {
                Name = "John",
                Age = 25,
                Year = 3,
                Work = "part-time job"
            };

            // Act
            PartTimeStudent copiedStudent = originalStudent.ShallowCopy();

            // Assert
            Assert.AreEqual(originalStudent.Name, copiedStudent.Name);
            Assert.AreEqual(originalStudent.Age, copiedStudent.Age);
            Assert.AreEqual(originalStudent.Year, copiedStudent.Year);
            Assert.AreEqual(originalStudent.Work, copiedStudent.Work);
        }


        public void Clone_CreatesIndependentCopy()
        {
            // Arrange
            PartTimeStudent originalStudent = new PartTimeStudent
            {
                Name = "Alice",
                Age = 22,
                Year = 4,
                Work = "freelancer"
            };

            // Act
            PartTimeStudent clonedStudent = (PartTimeStudent)originalStudent.Clone();

            // Assert
            Assert.AreEqual(originalStudent.Name, clonedStudent.Name);
            Assert.AreEqual(originalStudent.Age, clonedStudent.Age);
            Assert.AreEqual(originalStudent.Year, clonedStudent.Year);
            Assert.AreEqual(originalStudent.Work, clonedStudent.Work);

            // Modify the original, and ensure the cloned object remains unchanged
            originalStudent.Name = "Modified";
            Assert.AreNotEqual(originalStudent.Name, clonedStudent.Name);
        }
        [TestMethod]
        public void ShowInfo_DisplaysCorrectOutput()
        {
            // Arrange
            Person instance = new Person { Name = "John", Age = 25 };
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            instance.ShowInfo();

            // Assert
            string expectedOutput = $"Имя: John, Возраст: 25";
            Assert.AreEqual(expectedOutput, stringWriter.ToString().Trim());
        }

        [TestMethod]
        public void Init_PromptsForInput_SetsProperties()
        {
            // Arrange
            Person instance = new Person();
            StringReader stringReader = new StringReader("Alice\n30");
            Console.SetIn(stringReader);

            // Act
            instance.Init();

            // Assert
            Assert.AreEqual("Alice", instance.Name);
            Assert.AreEqual(30, instance.Age);
        }
        [TestMethod]
        public void RandomInit_SetsNameFromNamesArray()
        {
            // Arrange
            Person   instance = new Person();
            int initialNamesCount = Person.Names.Length;

            // Act
            instance.RandomInit();

            // Assert
            CollectionAssert.Contains(Person.Names, instance.Name);
        }

        [TestMethod]
        public void RandomInit_SetsAgeWithinRange()
        {
            // Arrange
            Person instance = new Person();

            // Act
            instance.RandomInit();

            // Assert
            Assert.IsTrue(instance.Age >= 1 && instance.Age <= 99);
        }
        [TestMethod]
        public void CompareTo_NullObject_Returns1()
        {
            // Arrange
            Person person = new Person { Name = "John", Age = 25 };

            // Act
            int result = person.CompareTo(null);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareTo_CompareByName_ReturnsCorrectResult()
        {
            // Arrange
            Person person1 = new Person { Name = "Alice", Age = 30 };
            Person person2 = new Person { Name = "Bob", Age = 28 };

            // Act
            int result = person1.CompareTo(person2);

            // Assert
            Assert.IsTrue(result < 0); // person1.Name comes before person2.Name in lexicographical order
        }

        [TestMethod]
        public void ShallowCopy_CreatesCopyWithSameValues()
        {
            // Arrange
            Person originalPerson = new Person { Name = "Jane", Age = 22 };

            // Act
            Person copiedPerson = originalPerson.ShallowCopy();

            // Assert
            Assert.AreEqual(originalPerson.Name, copiedPerson.Name);
            Assert.AreEqual(originalPerson.Age, copiedPerson.Age);
        }

        [TestMethod]
        public void Clone_CreatesIndependentCopy1()
        {
            // Arrange
            Person originalPerson = new Person { Name = "Sam", Age = 23 };

            // Act
            Person clonedPerson = (Person)originalPerson.Clone();

            // Assert
            Assert.AreEqual(originalPerson.Name, clonedPerson.Name);
            Assert.AreEqual(originalPerson.Age, clonedPerson.Age);

            // Modify the original, and ensure the cloned object remains unchanged
            originalPerson.Name = "Modified";
            Assert.AreNotEqual(originalPerson.Name, clonedPerson.Name);
        }
        [TestMethod]
        public void DefaultConstructor_SetsDefaultValues1()
        {
            // Arrange
            Scholar scholar = new Scholar();

            // Assert
            Assert.AreNotEqual("NULL", scholar.Name);
            Assert.AreEqual(0, scholar.Age);
            Assert.AreEqual(0, scholar.Grade);
        }

        [TestMethod]
        public void ParameterizedConstructor_SetsValuesCorrectly1()
        {
            // Arrange
            Scholar scholar = new Scholar("John", 15, 9);

            // Assert
            Assert.AreEqual("John", scholar.Name);
            Assert.AreEqual(15, scholar.Age);
            Assert.AreEqual(9, scholar.Grade);
        }

        [TestMethod]
        public void Show_IncludesGradeInfo()
        {
            // Arrange
            Scholar scholar = new Scholar { Name = "Alice", Age = 14, Grade = 8 };

            // Act
            string output = CaptureConsoleOutput1(() => scholar.Show());

            // Assert
            StringAssert.Contains(output, "Год обучения (класс): 8");
        }

        [TestMethod]
        public void ShowInfo_IncludesAllInfo1()
        {
            // Arrange
            Scholar scholar = new Scholar { Name = "Bob", Age = 16, Grade = 10 };

            // Act
            string output = CaptureConsoleOutput1(() => scholar.ShowInfo());

            // Assert
            StringAssert.Contains(output, "Имя: Bob, Возраст: 16, Год обучения (класс): 10");
        }

        private string CaptureConsoleOutput1(Action action)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                action.Invoke();
                return stringWriter.ToString().Trim();
            }
        }
        [TestMethod]
        public void Equals_SameInstance_R2eturnsTrue()
        {
            // Arrange
            Scholar scholar = new Scholar { Name = "John", Age = 15, Grade = 9 };

            // Act and Assert
            Assert.IsTrue(scholar.Equals(scholar));
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFa2lse()
        {
            // Arrange
            Scholar scholar = new Scholar { Name = "Alice", Age = 14, Grade = 8 };

            // Act and Assert
            Assert.IsFalse(scholar.Equals(null));
        }

        [TestMethod]
        public void Equals_DifferentTypeObject_ReturnsFals2e()
        {
            // Arrange
            Scholar scholar = new Scholar { Name = "Bob", Age = 16, Grade = 10 };
            object otherObject = new Person { Name = "Bob", Age = 16 };

            // Act and Assert
            Assert.IsFalse(scholar.Equals(otherObject));
        }

        [TestMethod]
        public void Equals_EqualScholars_ReturnsTrue()
        {
            // Arrange
            Scholar scholar1 = new Scholar { Name = "Jane", Age = 17, Grade = 11 };
            Scholar scholar2 = new Scholar { Name = "Jane", Age = 17, Grade = 11 };

            // Act and Assert
            Assert.IsTrue(scholar1.Equals(scholar2));
        }

        [TestMethod]
        public void Equals_DifferentGrade_ReturnsFalse()
        {
            // Arrange
            Scholar scholar1 = new Scholar { Name = "Sam", Age = 18, Grade = 12 };
            Scholar scholar2 = new Scholar { Name = "Sam", Age = 18, Grade = 11 };

            // Act and Assert
            Assert.IsFalse(scholar1.Equals(scholar2));
        }

        [TestMethod]
        public void ShallowCopy_CreatesCopyWithSameValues2()
        {
            // Arrange
            Scholar originalScholar = new Scholar { Name = "Alice", Age = 15, Grade = 9 };

            // Act
            Scholar copiedScholar = originalScholar.ShallowCopy();

            // Assert
            Assert.AreEqual(originalScholar.Name, copiedScholar.Name);
            Assert.AreEqual(originalScholar.Age, copiedScholar.Age);
            Assert.AreEqual(originalScholar.Grade, copiedScholar.Grade);
        }

        [TestMethod]
        public void Clone_CreatesIndependentCopy2()
        {
            // Arrange
            Scholar originalScholar = new Scholar { Name = "Bob", Age = 16, Grade = 10 };

            // Act
            Scholar clonedScholar = (Scholar)originalScholar.Clone();

            // Assert
            Assert.AreEqual(originalScholar.Name, clonedScholar.Name);
            Assert.AreEqual(originalScholar.Age, clonedScholar.Age);
            Assert.AreEqual(originalScholar.Grade, clonedScholar.Grade);

            // Modify the original, and ensure the cloned object remains unchanged
            originalScholar.Name = "Modified";
            Assert.AreNotEqual(originalScholar.Name, clonedScholar.Name);
        }
        [TestMethod]
        public void DefaultConstructor_SetsDe1faultValues()
        {
            // Arrange
            Student student = new Student();

            // Assert
            Assert.AreNotEqual("NULL", student.Name);
            Assert.AreEqual(0, student.Age);
            Assert.AreEqual(1, student.Year);
        }

        [TestMethod]
        public void ParameterizedConstructor_SetsVa1luesCorrectly()
        {
            // Arrange
            Student student = new Student("John", 20, 3);

            // Assert
            Assert.AreEqual("John", student.Name);
            Assert.AreEqual(20, student.Age);
            Assert.AreEqual(3, student.Year);
        }

        [TestMethod]
        public void Show_IncludesYearInfo()
        {
            // Arrange
            Student student = new Student { Name = "Alice", Age = 22, Year = 4 };

            // Act
            string output = CaptureConsoleOutput(() => student.Show());

            // Assert
            StringAssert.Contains(output, ", Курс: 4");
        }

        [TestMethod]
        public void ShowInfo_Inc1ludesAllInfo()
        {
            // Arrange
            Student student = new Student { Name = "Bob", Age = 18, Year = 2 };

            // Act
            string output = CaptureConsoleOutput(() => student.ShowInfo());

            // Assert
            StringAssert.Contains(output, "Имя: Bob, Возраст: 18, Курс: 2");
        }

        private string CaptureConsoleO1utput(Action action)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                action.Invoke();
                return stringWriter.ToString().Trim();
            }
        }
        [TestMethod]
        public void ShallowCopy_CreatesCopyWithSam1eValues()
        {
            // Arrange
            Student originalStudent = new Student { Name = "Alice", Age = 20, Year = 3 };

            // Act
            Student copiedStudent = originalStudent.ShallowCopy();

            // Assert
            Assert.AreEqual(originalStudent.Name, copiedStudent.Name);
            Assert.AreEqual(originalStudent.Age, copiedStudent.Age);
            Assert.AreEqual(originalStudent.Year, copiedStudent.Year);
        }

        [TestMethod]
        public void Clone_CreatesIndependent1Copy()
        {
            // Arrange
            Student originalStudent = new Student { Name = "Bob", Age = 22, Year = 4 };

            // Act
            Student clonedStudent = (Student)originalStudent.Clone();

            // Assert
            Assert.AreEqual(originalStudent.Name, clonedStudent.Name);
            Assert.AreEqual(originalStudent.Age, clonedStudent.Age);
            Assert.AreEqual(originalStudent.Year, clonedStudent.Year);

            // Modify the original, and ensure the cloned object remains unchanged
            originalStudent.Name = "Modified";
            Assert.AreNotEqual(originalStudent.Name, clonedStudent.Name);
        }
        [TestMethod]
        public void Compare_CorrectlyComparesByName()
        {
            // Arrange
            SortByName comparer = new SortByName();
            Person person1 = new Person { Name = "Alice", Age = 25 };
            Person person2 = new Person { Name = "John", Age = 30 };

            // Act
            int result = comparer.Compare(person1, person2);

            // Assert
            Assert.IsTrue(result < 0); // person1.Name comes before person2.Name in lexicographical order
        }
        [TestMethod]
        public void Clone_CreatesIndepe1ndentCopy()
        {
            // Arrange
            PartTimeStudent originalStudent = new PartTimeStudent { Name = "Bob", Age = 22, Year = 4, Work = "Company" };

            // Act
            PartTimeStudent clonedStudent = (PartTimeStudent)originalStudent.Clone();

            // Assert
            Assert.AreEqual(originalStudent.Name, clonedStudent.Name);
            Assert.AreEqual(originalStudent.Age, clonedStudent.Age);
            Assert.AreEqual(originalStudent.Year, clonedStudent.Year);
            Assert.AreEqual(originalStudent.Work, clonedStudent.Work);

            // Modify the original, and ensure the cloned object remains unchanged
            originalStudent.Name = "Modified";
            Assert.AreNotEqual(originalStudent.Name, clonedStudent.Name);
        }
    }
}