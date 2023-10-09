using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2
{
    class Student
    {
        private string studentID;
        private string fullName;
        private float  avgScore;
        private string faculty;

        public Student()
        {
               
        }

        public Student(string studentID, string fullName, float avgScore, string faculty)
        {
            this.StudentID = studentID;
            this.FullName = fullName;
            this.AvgScore = avgScore;
            this.Faculty = faculty;
        }

        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public float AvgScore { get => avgScore; set => avgScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public void Input() {
            Console.WriteLine("Nhap MSSV: ");
            studentID = Console.ReadLine();
            Console.WriteLine("Nhap ho ten sinh vien: ");
            FullName = Console.ReadLine();
            Console.WriteLine("Nhap dien trung binh: ");
            avgScore = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhap khoa: ");
            Faculty = Console.ReadLine();
        }
        public void Output() {
            Console.WriteLine("MSSV: {0} Ho Ten: {1} Khoa: {2} DiemTB: {3}", this.StudentID, this.FullName, this.Faculty, this.avgScore);
        }
    }

}
