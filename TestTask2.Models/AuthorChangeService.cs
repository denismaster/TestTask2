using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TestTask.Models
{
    public class AuthorChangeService
    {
        private readonly IAuthorChangeRepository authorChangeRepository;

        public AuthorChangeService(IAuthorChangeRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.authorChangeRepository = repository;
        }
        public IEnumerable<AuthorChange> LoadChanges(string assemblyPath)
        {
            var changes = new List<AuthorChange>();

            var assembly = Assembly.LoadFrom(assemblyPath);
            var assemblyName = assembly.GetName().Name;

            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var typeName = type.Name;

                var methods = type.GetMethods(BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Static |
                    BindingFlags.DeclaredOnly |
                    BindingFlags.Instance);

                var typeAttributes = Attribute.GetCustomAttributes(type, typeof(AuthorChangeAttribute));

                foreach (var attribute in typeAttributes.OfType<AuthorChangeAttribute>())
                {
                    changes.Add(new AuthorChange(attribute.AuthorName, attribute.Date, attribute.Description, assemblyName, typeName));
                }

                foreach (var method in methods)
                {
                    var methodAttributes = Attribute.GetCustomAttributes(method, typeof(AuthorChangeAttribute));
                    var methodName = method.Name;
                    foreach (var attribute in methodAttributes.OfType<AuthorChangeAttribute>())
                    {
                        changes.Add(new AuthorChange(attribute.AuthorName, attribute.Date, attribute.Description, assemblyName, typeName + "/" + methodName));
                    }
                }
            }
            
            return changes;
        }

        public IEnumerable<AuthorChange> LoadChanges()
        {
            return authorChangeRepository.GetChanges();
        }

        public void AddChanges(IEnumerable<AuthorChange> changes)
        {
            authorChangeRepository.AddChanges(changes);
            authorChangeRepository.SaveChanges();
        }
    }
}
