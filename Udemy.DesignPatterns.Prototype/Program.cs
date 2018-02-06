using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Udemy.DesignPatterns.Prototype
{

    public static class ExtensionMethos
    {
        public static T BinaryDeepCopy<T>(this T self)
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms,self);
                ms.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(ms);
            }
        }
    }

    [Serializable]
    public class Point
    {
        public int X, Y;
    }

    [Serializable]
    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return new Line
            {
                End = new Point
                {
                    X = this.End.X,
                    Y = this.End.Y
                },
                Start = new Point
                {
                    X = this.Start.X,
                    Y = this.Start.Y
                }
            };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Start Point = {{X}}:{Start.X}");
            sb.AppendLine($"Start Point = {{Y}}:{Start.Y}");
            sb.AppendLine();
            sb.AppendLine($"End Point = {{X}}:{End.X}");
            sb.AppendLine($"End Point = {{Y}}:{End.Y}");
            return sb.ToString();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = new Line
            {
                End = new Point
                {
                    X = 1,
                    Y = 2
                },
                Start = new Point
                {
                    X = 3,
                    Y = 4
                }
            };
            Console.WriteLine(line1);
            var line2 = line1.DeepCopy();
            line2.Start.X = 99;
            var line3 = line2.BinaryDeepCopy();
            Console.WriteLine(line2);
            Console.WriteLine(line3);
            Console.ReadKey();
        }
    }
}