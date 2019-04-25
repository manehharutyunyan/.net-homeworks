using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise4
{
    class StudentCatalog
    {
        public Dictionary<int, Student> Catalog { get; set; }

        public StudentCatalog()
        {
            Catalog = new Dictionary<int, Student>();
        }

        /// <summary>
        /// Add a single student to the catalog. 
        /// </summary>
        /// <param name="aStudent"></param>
        public void AddStudent(Student aStudent)
        {
            Catalog.Add(aStudent.ID, aStudent);
        }

        /// <summary>
        ///  Given an id, return the student with that id.
        ///  If no student exists with the given id, return null. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudent(int id)
        {
            foreach (var student in Catalog)
            {
                if (student.Key == id)
                    return student.Value;
            }
            return null;
        }

        /// <summary>
        /// Given an id, return the score average for the student with that id.         
        /// If no student exists with the given id, return -1.   
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetAverageForStudent(int id)
        {
            foreach (var student in Catalog)
            {
                if (student.Key == id)
                {
                    int average = 0;
                    int countOfTestScores = Catalog.Count;
                    Dictionary<string, int> testScores = student.Value.TestScores;
                    foreach (KeyValuePair<string, int> mark in testScores)
                    {
                        average += mark.Value;
                    }
                    return average / countOfTestScores;
                }
            }
            return -1;
        }

        /// <summary>
        ///  Returns the total test score average for ALL students in the catalog.
        ///  Note that only students with a "real" score average (i.e. NOT -1) should
        ///  be included in the calculation of the average
        /// </summary>
        /// <returns></returns>
        public int GetTotalAverage()
        {
            int totalAverage = 0;
            foreach (KeyValuePair<int, Student> student in Catalog)
            {
                totalAverage += GetAverageForStudent(student.Key);
            }
            return totalAverage/Catalog.Count();
        }

        /// <summary>
        ///  Get top three students who have the highest average score.
        ///  If no student returns empty list.
        /// </summary>
        /// <returns></returns>
        public List<Student> GetTopThreeStudents()
        {
            List<Student> topThreeStudents = new List<Student>();
            Dictionary<int, int> allStudentsScores = new Dictionary<int, int>();

            if (allStudentsScores.Count < 0)
            {
                Console.WriteLine("You haven;'t 3 students in catalog");
                return null;
            }

            foreach (KeyValuePair<int, Student> student in Catalog)
            {
                allStudentsScores.Add(student.Key, GetAverageForStudent(student.Key));
            }
            allStudentsScores.OrderBy(key => key.Value);

            int i = 0;
            foreach (KeyValuePair<int, int> student in allStudentsScores)
            {
                if (i == 3)
                    return topThreeStudents;
                topThreeStudents.Add(GetStudent(student.Key));
                ++i;
            }
            return topThreeStudents;
        }

    }
}
