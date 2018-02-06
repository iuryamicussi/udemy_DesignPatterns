using System;

namespace Udemy.DesignPatterns.Singleton
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var instance1 = func.Invoke();
            var instance2 = func.Invoke();

            return instance1.Equals(instance2);
        }
    }
    
    public class Singleton
    {
        private  static  Lazy<Singleton> _s = new Lazy<Singleton>(()=> new Singleton());

        public static Singleton ReturnSingleton() => _s.Value;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Is {SingletonTester.IsSingleton(Singleton.ReturnSingleton)} that Singleton is a singleton!");
            Console.ReadKey();
        }
    }
}