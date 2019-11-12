using System;
using System.Text;

namespace Udemy.DesignPatterns.Builder
{
    public class CodeBuilder
    {
        private StringBuilder sb = new StringBuilder();
        private int indentation = 0;
        
        public CodeBuilder(string className)
        {
            WriteCode($"public class {className}",indentation);
            WriteCode("{",indentation);
        }
        
        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            WriteCode($"public {fieldType} {fieldName};",indentation+1);
            return this;
        }
        
        public override string ToString()
        {
            return WriteCode("}",indentation).ToString();
        }

        private StringBuilder WriteCode(string content, int indentation)
        {
            return sb.AppendLine(new string(' ',indentation*2) + content);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);

            //Console.ReadKey();
        }
    }
}
