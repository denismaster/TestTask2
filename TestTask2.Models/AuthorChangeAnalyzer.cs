using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace TestTask.Models
{
    /// <summary>
    /// Класс, предназначенный для получения изменений с разных частей кода.
    /// </summary>
    public class AuthorChangeAnalyzer
    {
        /// <summary>
        /// Анализ атрибутов типа(класса, структуры, интерфейса, перечисления)
        /// </summary>
        /// <param name="type">Тип для анализа</param>
        /// <returns></returns>
        public IEnumerable<AuthorChange> AnalyzeType(Type type, string assemblyName)
        {
            var changes = new List<AuthorChange>();

            try
            {
                var typeName = type.Name;
                var typeAttributes = Attribute.GetCustomAttributes(type, typeof(AuthorChangeAttribute));

                foreach (var attribute in typeAttributes.OfType<AuthorChangeAttribute>())
                {
                    changes.Add(new AuthorChange(attribute.AuthorName, attribute.Date, attribute.Description, assemblyName, typeName));
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Ошибка при заполнении атрибутов в сборке {0}", assemblyName);
            }
            return changes;
        }
        /// <summary>
        /// Анализ атрибутов методов типа. 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public IEnumerable<AuthorChange> AnalyzeTypeMethods(Type type, string assemblyName)
        {
            var changes = new List<AuthorChange>();
            try
            {
                var typeName = type.Name;

                var methods = type.GetMethods(BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Static |
                        BindingFlags.DeclaredOnly |
                        BindingFlags.Instance);

                foreach (var method in methods)
                {
                    changes.AddRange(AnalyzeMethod(method, typeName, assemblyName));
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Ошибка при заполнении атрибутов в сборке {0}", assemblyName);
            }
            return changes;
        }
        /// <summary>
        /// Анализ атрибутов метода
        /// </summary>
        /// <param name="method">Метод для анализа</param>
        /// <returns></returns>
        private IEnumerable<AuthorChange> AnalyzeMethod(MethodInfo method, string typeName, string assemblyName)
        {
            var changes = new List<AuthorChange>();
            var methodAttributes = Attribute.GetCustomAttributes(method, typeof(AuthorChangeAttribute));
            var methodName = method.Name;
            foreach (var attribute in methodAttributes.OfType<AuthorChangeAttribute>())
            {
                changes.Add(new AuthorChange(attribute.AuthorName, attribute.Date, attribute.Description, assemblyName, typeName + "/" + methodName));
            }
            return changes;
        }
    }
}
