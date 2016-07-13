using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TestTask.Models
{
    /// <summary>
    /// Сервис для работы с изменениями.
    /// </summary>
    public class AuthorChangeService
    {
        /// <summary>
        /// Репозиторий для работы с изменениями
        /// </summary>
        private readonly IAuthorChangeRepository authorChangeRepository;
        /// <summary>
        /// Анализатор атрибутов
        /// </summary>
        private readonly AuthorChangeAnalyzer analyzer;

        public AuthorChangeService(IAuthorChangeRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            this.authorChangeRepository = repository;

            //TODO:если способ анализа атрибутов будет меняться, то добавить DI для анализатора
            analyzer = new AuthorChangeAnalyzer();
        }
        /// <summary>
        /// Получение изменений путем анализа файла сборки
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <returns></returns>
        public IEnumerable<AuthorChange> LoadChanges(string assemblyPath)
        {
            var changes = new List<AuthorChange>();

            var assembly = Assembly.LoadFrom(assemblyPath);
            var assemblyName = assembly.GetName().Name;

            var types = assembly.GetTypes();

            foreach (var type in types)
            {

                changes.AddRange(analyzer.AnalyzeType(type, assemblyName));

                changes.AddRange(analyzer.AnalyzeTypeMethods(type, assemblyName));

                
            }
            
            return changes;
        }
        /// <summary>
        /// Получение изменений из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AuthorChange> LoadChanges()
        {
            return authorChangeRepository.GetChanges();
        }
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        /// <param name="changes"></param>
        public void AddChanges(IEnumerable<AuthorChange> changes)
        {
            authorChangeRepository.AddChanges(changes);
            authorChangeRepository.SaveChanges();
        }
    }
}
