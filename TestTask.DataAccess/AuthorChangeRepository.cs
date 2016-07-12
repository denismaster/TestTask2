using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;
namespace TestTask.DataAccess
{
    public class AuthorChangeRepository:IAuthorChangeRepository
    {
        public AuthorChangeContext context;

        public AuthorChangeRepository()
        {
            context = new AuthorChangeContext();
        }

        public IEnumerable<AuthorChange> GetChanges()
        {
            return context.AuthorChanges.OrderBy(x=>x.Date).ToList();
        }

        public void AddChanges(IEnumerable<AuthorChange> changes)
        {
            foreach (var change in changes)
            {
                var existingChange = context.AuthorChanges.Find(change.Author, change.Date);
                if (existingChange != null)
                {
                    //entity is already in the context
                    var attachedEntry = context.Entry(existingChange);
                    attachedEntry.CurrentValues.SetValues(change);
                }
                else
                {
                    //Since we don't have it in db, this is a simple add.
                   context.AuthorChanges.Add(change);
                }
            }
        }


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
