using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ObservableWrapperGenerator;

namespace WrapperGenerator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists("System"))
                Directory.Delete("System", true);
            System.IO.Directory.CreateDirectory("System");
            var assm = Assembly.GetAssembly(typeof (int));
            var types = assm.GetTypes().Where(t => t.IsPublic && !t.IsSpecialName);
            foreach (var type in types)
            {
                var wrapper = NewGenerator.GenerateClassWrapper(type);
                File.WriteAllText(string.Format(@"System\_{0}Extenstions.cs", type.Name), wrapper);
                System.Console.WriteLine("Wrapped: {0}", type.Name);
            }
            System.Console.WriteLine("Done!");
            System.Console.ReadLine();
        }
    }
}
