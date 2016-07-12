using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.DataLayer
{
    public class Change
    {
        public String AssemblyName
        {
            get;
            set;
        }
        public String ChangePath
        {
            get;
            set;
        }
        public String AuthorName
        {
            get;
            set;
        }
        public DateTime ChangeDate
        {
            get;
            set;
        }
        public String ChangeDescription
        {
            get;
            set;
        }
    }
}
