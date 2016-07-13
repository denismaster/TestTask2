using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;
namespace TestTask.DataAccess
{
    /// <summary>
    /// Репозиторий для работы с БД через EntityFramework.
    /// </summary>
    public class AuthorChangeRepository:IAuthorChangeRepository
    {
        public AuthorChangeContext context;

        public AuthorChangeRepository()
        {
            context = new AuthorChangeContext();
        }
        /// <summary>
        /// Получение изменений из базы данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AuthorChange> GetChanges()
        {
            return context.AuthorChanges.OrderBy(x=>x.Date).ToList();
        }
        /// <summary>
        /// Сохранение изменений или обновление старых
        /// </summary>
        /// <param name="changes"></param>
        public void AddChanges(IEnumerable<AuthorChange> changes)
        {
            foreach (var change in changes)
            {
                var existingChange = context.AuthorChanges.Find(change.Author, 
                    change.Date, change.AssemblyName, change.Location);
                if (existingChange != null)
                {
                    //Если изменения с нашим ключем уже есть в БД, то обновляем.
                    var attachedEntry = context.Entry(existingChange);
                    attachedEntry.CurrentValues.SetValues(change);
                }
                else
                {
                   //Иначе просто добавляем.
                   context.AuthorChanges.Add(change);
                }
            }
        }

        /// <summary>
        /// Сохранение изменений.
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
           catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
