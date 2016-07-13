using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly2
{
    [TestTask.Models.AuthorChange("Foo Barr","2018/06/14")]
    public class Class1
    {
        [TestTask.Models.AuthorChange("Quiz Quiz", "2013/06/14")]
        [TestTask.Models.AuthorChange("Quiz Quiz", "2013/06/11")]
        public void MyMethod()
        {

        }
       [TestTask.Models.AuthorChange("", "20150708")]
        public void MyMethod2()
        {

        }
    }
}
