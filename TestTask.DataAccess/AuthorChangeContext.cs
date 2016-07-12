using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestTask.Models;
namespace TestTask.DataAccess
{
    public class AuthorChangeContext:DbContext
    {
        public DbSet<AuthorChange> AuthorChanges
        {
            get;
            set;
        }

        public AuthorChangeContext():base("AuthorChangeDatabase")
        {

        }

        #region ModelCreation
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthorChange>().HasKey(t => new { t.Author, t.Date });
        }
        #endregion
    }
}
