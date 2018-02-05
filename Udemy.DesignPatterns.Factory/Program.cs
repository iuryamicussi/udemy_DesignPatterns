using System;

namespace Udemy.DesignPatterns.Factory {

    public class PersonFactory
    {
        private static int _id = 0;
        public Person CreatePerson(string name)
        {
            return new Person{
                Id = _id++,
                Name = name
            };
        }
    }

    public class Person 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} Name:{Name}";
        }

    }

    class Program
    {
        public static void Main(string []args)
        {
            var personFactory = new PersonFactory();
            var john = personFactory.CreatePerson("John");
            var maria = personFactory.CreatePerson("Maria");
            System.Console.WriteLine(john);
            System.Console.WriteLine(maria);
        }
    }
}