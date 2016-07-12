using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Models
{
    public interface IAuthorChangeRepository
    {
        IEnumerable<AuthorChange> GetChanges();

        void AddChanges(IEnumerable<AuthorChange> changes);

        void SaveChanges();
    }
}
