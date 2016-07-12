using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Models
{
    public class AuthorChange
    {
        public string Author
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string AssemblyName
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }
        
       // public AuthorChange()
     //   {

      //  }

        public AuthorChange(string author, DateTime date, string description, 
            string assembly, string location )
        {
            this.Author = author;
            this.Date = date;
            this.Description = description;
            this.AssemblyName = assembly;
            this.Location = location;
        }
    }
}
