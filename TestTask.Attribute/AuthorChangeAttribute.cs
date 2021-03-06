﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Models
{
    ///
    /// <summary>
    /// Атрибут, которым помечаются изменения исходного кода.
    /// </summary>
    ///
    //Возможность использования нескольких атрибутов сразу, но без наследования производными классами.
    [AttributeUsage(AttributeTargets.Class |
                       AttributeTargets.Enum |
                       AttributeTargets.Struct |
                       AttributeTargets.Method |
                       AttributeTargets.Interface,
                       AllowMultiple = true, Inherited = false)]
    public class AuthorChangeAttribute : System.Attribute
    {
        private String authorName;
        private DateTime date;
        private String description;

        public AuthorChangeAttribute(String authorName, String date, String description = null)
        {
            if (String.IsNullOrEmpty(authorName))
            {
                throw new ArgumentException("Author name is invalid or null");
            }
            DateTime changeDate;
            if (!(DateTime.TryParse(date, out changeDate)))
            {
                throw new ArgumentException("Change date is in invalid format");
            }
            this.authorName = authorName;
            this.date = changeDate;
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
