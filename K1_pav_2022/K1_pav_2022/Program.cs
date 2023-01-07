using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace K1_pav_2022
{
    class Student
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        private List<int> Credits { get; set; }
        public Student(string lastName, string name, string group, List<int> credits)
        {
            LastName = lastName;
            Name = name;
            Group = group;
            foreach (var item in credits)
                Credits.Add(item);
        }
        int Sum(int ii)
        {
            if (ii <= 0)
                return 0;
            return (Sum(ii - 1) + Credits[ii - 1]);
        }
        public Student()
        {
            Credits = new List<int>();
        }
    }
    class Faculty
    {
        List<Student> Students;
        public string Title { get; set; }  
        public int Credits { get; set; }
        public Faculty(string title, int crdits)
        {
            Students = new List<Student>();
            Title = title;
            Credits = crdits;
        }
        public void AddStudents(Student student)
        {
            Students.Add(student);
        }
        void Sort()
        {

        }
    }
    class TaskUtils
    {
        Faculty Select(Faculty faculty)
        {

        }
    }
    class InOutUtil
    {
        public static Faculty ReadFaculty(string FileName)
        {
            string[] lines = File.ReadAllLines(FileName);
            string title = lines[0];
            int credits = int.Parse(lines[1]);
            Faculty faculty = new Faculty(title, credits);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] Parts = lines[i].Split(' ');
                string lastName = Parts[0];
                string name = Parts[1];
                string group = Parts[2];
                List<int> Credits = new List<int>();
                for (int j = 3; j < Parts.Length; j++)
                    Credits.Add(int.Parse(Parts[j]));
                Student student = new Student(lastName, name, group, Credits);
                faculty.AddStudents(student);
            }
            return faculty;
        }
        void PrintFaculty(Faculty faculty, string fileName, string header)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Faculty faculty = InOutUtil.ReadFaculty("data.txt");
        }
    }
}
