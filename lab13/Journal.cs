using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public class Journal
    {
        //public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args); // определение делегата
        public List<JournalEntry> Log { get; } // предоставляет список объектов JE, хранит записи журнала
        public Journal() // Инициализирует список log
        {
            Log = new List<JournalEntry>();
        }
        public void Show()
        {
            foreach (var v in Log)
            {
                Console.WriteLine(v.ToString());
            }
        }
        public void CollectionCountChanged(object source, CollectionHandlerEventArgs e) // вызов при изменении количества объектов
        {
            JournalEntry je = new JournalEntry(Log.Count.ToString(), source, e.Name, "Количество объектов изменено", e.Object.ToString());
            Log.Add(je);

        }
        public void CollectionTriedToFind(object source, CollectionHandlerEventArgs e) // поиск
        {
            JournalEntry je = new JournalEntry(Log.Count.ToString(), source, e.Name, "Попытка поиска", e.Object.ToString());
            Log.Add(je);
        }
        public class JournalEntry
        {
            public object Collection { get; set; }
            public string Name { get; set; }
            public string Number { get; set; }
            public string TypeOfChange { get; set; }
            public string ObjectData { get; set; }
            public JournalEntry(string number, object collection, string name, string typeOfChange, string objectData)
            {
                Number = number;
                Collection = collection;
                Name = name;
                TypeOfChange = typeOfChange;
                ObjectData = objectData;
            }
            public override string ToString()
            {
                return "Запись №" + Number + "\n"
                    + "Коллекция: " + Collection + "\n"
                    + "Имя: " + Name + "\n"
                    + "Тип изменения: " + TypeOfChange + "\n"
                    + "Объект: " + ObjectData + "\n";
            }
        }
    }
}
