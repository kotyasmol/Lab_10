using PersonLibrary;
namespace DemonstrationLabTen;
class Program
{
    static void Main()
    {
        Console.WriteLine("СОЗДАНИЕ ВРУЧНУЮ");
        Person userPerson = new Person();
        userPerson = userPerson.Init();
        userPerson.Show();
        Console.WriteLine("СОЗДАНИЕ РАНДОМНО");
        Person randomPerson = new Person();
        randomPerson = randomPerson.RandomInit();
        randomPerson.Show();
        Console.WriteLine("ДЕМОНСТРАЦИЯ EQUALS");
        Person person1 = new Person { Name = "John", Age = 30 };
        person1.Show();
        Person person2 = new Person { Name = "John", Age = 30 };
        person2.Show();
        Person person3 = new Person { Name = "Alice", Age = 25 };
        person3.Show();
        bool areEqual1 = person1.Equals(person2);
        bool areEqual2 = person1.Equals(person3);
        Console.WriteLine($"Are persons 1 and 2 equal? {areEqual1}"); // Выведет true
        Console.WriteLine($"Are persons 1 and 3 equal? {areEqual2}"); // Выведет false

        Console.WriteLine("РАНДОМНОЕ СОЗДАНИЕ ШКОЛЬНИКА");
        Scholar randomScholar = new Scholar();
        randomScholar = (Scholar)randomScholar.RandomInit();
        randomScholar.Show();
        Console.WriteLine("СОЗДАНИЕ ШКОЛЬНИКА ВРУЧНУЮ");
        Scholar userScholar = new Scholar();
        userScholar = (Scholar)userScholar.Init();
        userScholar.Show();
        Console.WriteLine("СРАВНЕНИЕ ШКОЛЬНИКОВ");
        bool areEqualScholar = randomScholar.Equals(userScholar);
        Console.WriteLine(areEqualScholar);

        Console.WriteLine("РАНДОМНОЕ СОЗДАНИЕ СТУДЕНТА");
        Student randomStudent = new Student();
        randomStudent = (Student)randomStudent.RandomInit();
        randomStudent.Show();
        Console.WriteLine("СОЗДАНИЕ СТУДЕНТА ВРУЧНУЮ");
        Student userStudent = new Student();
        userStudent = (Student)userStudent.Init();
        userStudent.Show();
        Console.WriteLine("СРАВНЕНИЕ СТУДЕНТОВ");
        bool areEqualStudent = randomStudent.Equals(userStudent);
        Console.WriteLine(areEqualStudent);
    }
}
