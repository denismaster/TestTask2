using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestTask.Models;
namespace TestTask.DataAccess
{
    /// <summary>
    /// Контекст EF для Code-First базы.
    /// </summary>
    public class AuthorChangeContext:DbContext
    { 
        public DbSet<AuthorChange> AuthorChanges
        {
            get;
            set;
        }

        public AuthorChangeContext():base("AuthorChangeContext")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        #region ModelCreation
        /// <summary>
        /// Зде
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthorChange>().HasKey(t => new { t.Author, t.Date });
        }
        #endregion
    }
}
