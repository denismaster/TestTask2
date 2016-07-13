using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask.Models;
namespace TestAssembly
{
    [AuthorChange("Ivan Ivanov","2016/01/01","Изменение заголовка класса")]
    [AuthorChange("Petr Petrov", "2016/02/01")]
    public class A
    {
        [AuthorChange("Quml Quml", "2016/04/06")]
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
        [AuthorChange("Foo bar", "2016/04/06")]
        private void privateHello()
        {
            Console.WriteLine("Hello");
        }
    }

    [AuthorChange("Denis Denisov", "2016/01/03")]
    [Serializable]
    public class B:A
    {

    }
    [AuthorChange("Denis Denisov", "2016/01/12")]
    public class C:A
    {

    }
}
