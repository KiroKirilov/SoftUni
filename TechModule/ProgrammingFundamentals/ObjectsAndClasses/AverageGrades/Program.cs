using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace average_grades
{
    class Program
    {
        static void Main(string[] args)
        {

            var amountOfStudents = int.Parse(Console.ReadLine());
            var students = new Student[amountOfStudents];

            for (int i = 0; i < amountOfStudents; i++)
            {
                var studentInput = Console.ReadLine().Split().ToList();
                var currentStudent = new Student();
                currentStudent.Name = studentInput[0];
                studentInput.RemoveAt(0);
                var currentStudentGrades = studentInput.Select(double.Parse);

                currentStudent.Grades = currentStudentGrades.ToList();
                students[i] = currentStudent;
            }

            foreach (Student student in students.Where(x => x.AverageGrade >= 5).OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade))
            {
                Console.WriteLine("{0} -> {1:F2}", student.Name, student.AverageGrade);
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public List<Double> Grades { get; set; }
        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
    }
}