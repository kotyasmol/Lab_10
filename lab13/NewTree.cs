using lab12;
using System;

namespace LaboratoryWork_13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public object Collection { get; set; }
        public string Name { get; set; }
        public string TypeCollection { get; set; }
        public object Object { get; set; }
        public CollectionHandlerEventArgs(object collection, string name, object obj)
        {
            Collection = collection;
            Name = name;
            TypeCollection = collection.GetType().Name;
            Object = obj;
        }
        public override string ToString()
        {
            return "Коллекция: " + Collection.ToString() + "\n"
                + "Имя: " + Name + "\n"
                + "Тип коллекции: " + TypeCollection;
        }
    }



    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class NewTree<T> : Tree<T> where T : ICloneable
    {
        Tree<T> tree;
        string treeName;
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionTriedToFind;
        public Tree<T> Tree { get; set; }
        public string TreeName { get; set; }
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            //Console.WriteLine($"OnCollectionCountChanged in tree {treeName}");
            //Console.WriteLine(args);
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }
        public virtual void OnCollectionTriedToFind(object source, CollectionHandlerEventArgs args)
        {
            Console.WriteLine($"OnCollectionTriedToFind in tree {treeName}");
            CollectionTriedToFind?.Invoke(source, args);
        }
        public override void Add(T p)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(tree, treeName, p));
            base.Add(p);
        }
        public override bool Remove(T p)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(tree, treeName, p));
            return base.Remove(p);
        }
        public override bool Contains(T data)
        {
            OnCollectionTriedToFind(this, new CollectionHandlerEventArgs(tree, treeName, data));
            return base.Contains(data);
        }

        public override void Print()
        {
            Console.WriteLine("Имя коллекции: " + treeName + "\n");
            base.Print();
        }
        public NewTree(Tree<T> t, string s)
        {
            this.Tree = t;
            this.TreeName = s;
        }
    }
}