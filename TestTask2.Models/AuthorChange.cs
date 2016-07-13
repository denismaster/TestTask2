using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Models
{
    /// <summary>
    /// Модель, представляющая наше изменение исходного кода
    /// </summary>
    public class AuthorChange
    {
        /// <summary>
        /// Автор, совершивший изменение
        /// </summary>
        public string Author
        {
            get;
            set;
        }
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }
        /// <summary>
        /// Описание изменения
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Имя сборки,в  которой произошло изменение
        /// </summary>
        public string AssemblyName
        {
            get;
            set;
        }
        /// <summary>
        /// Местоположение изменения(имя типа или имя метода в типе)
        /// </summary>
        public string Location
        {
            get;
            set;
        }
        
        public AuthorChange()
        {

        }

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
