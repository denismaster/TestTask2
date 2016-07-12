using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask2.Models
{
    ///
    /// <summary>
    /// Атрибут, которым помечаются изменения исходного кода.
    /// </summary>
    ///
    //Возможность использования нескольких атрибутов сразу
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct,
                       AllowMultiple = true) ]
    public class AuthorChangeAttribute
    {
        private String authorName;
        private DateTime date;
        private String description;

        public AuthorChangeAttribute(String authorName, DateTime date, String description=null)
        {
            if(String.IsNullOrEmpty(authorName))
                throw new ArgumentException("Author name is invalid or null");

            this.authorName = authorName;
            this.date = date;
            this.description = description;
        }

        public String AuthorName
        {
            get 
            { 
                return authorName;
            }
        }

        public String Description
        {
            get
            { 
                return description;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
        }
    }
}
