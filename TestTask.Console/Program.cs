using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using TestTask.Models;

namespace TestTask.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                    throw new ArgumentException("Assembly name is not provided");

                var assembly = Assembly.LoadFrom(args[0]);
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    var methods = type.GetMethods(BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Static |
                        BindingFlags.DeclaredOnly|
                        BindingFlags.Instance);

                    var typeAttributes = Attribute.GetCustomAttributes(type, typeof(AuthorChangeAttribute));
                    
                    foreach (var attribute in typeAttributes.OfType<AuthorChangeAttribute>())
                    {
                        Console.WriteLine("Attribute:{0},{1}", attribute.AuthorName,
                            attribute.Date);
                    }
                    foreach(var method in methods)
                    {
                        var methodAttributes = Attribute.GetCustomAttributes(method, typeof(AuthorChangeAttribute));
                        foreach (var qattribute in methodAttributes.OfType<AuthorChangeAttribute>())
                        {
                            Console.WriteLine("Method Attribute:{0},{1}", qattribute.AuthorName,
                                qattribute.Date);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }

        }
    }
}
