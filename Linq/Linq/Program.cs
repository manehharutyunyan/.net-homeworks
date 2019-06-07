using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
                 new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                 new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                 new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                 new Student() { StudentID = 4, StudentName = "Ron" , Age = 20, StandardID = 2 } ,
                 new Student() { StudentID = 5, StudentName = "Ron" , Age = 21}
                };

            var querySelect = studentList.SelectExt(m => new { StudentName = m.StudentName });
            var queryWhere = studentList.WhereExt(m => m.Age == 18);
            var queryGroup = studentList.GroupByExt(s => s.Age);
            var queryDict = studentList.ToDictionary(s => s.StudentID, m => m.StudentName);
            var queryDict2 = studentList.ToDictionary(s => s.StudentID, m => m.StudentName);
        }
    }
}
