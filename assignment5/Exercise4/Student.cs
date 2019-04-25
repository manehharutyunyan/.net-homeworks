using System.Collections.Generic;

namespace Exercise4
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Dictionary<string, int> TestScores { get; set; }

        public Student(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            TestScores = new Dictionary<string, int>();
        }

        /// <summary>
        /// add new item in TestScore
        /// </summary>
        /// <param name="course"></param>
        /// <param name="mark"></param>
        public void AddTestResult(string course, int mark)
        {
            TestScores.Add(course, mark);
        }
    }
}
