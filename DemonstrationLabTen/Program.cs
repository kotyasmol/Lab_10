using PersonLibrary;
namespace DemonstrationLabTen;
class Program
{
    static void Main()
    {
        Person userperson = new Person();
        userperson.Show();
        userperson = userperson.Init();
        userperson.Show();
        
    }
}
