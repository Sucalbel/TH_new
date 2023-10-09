using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2
{
    internal class Program
    {
        static void AddStudent(List<Student> studentList) {
            Console.WriteLine("===Nhap thong tin sinh vien===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine(":>>>>>>>>>");
        }
        static void DisplayStudentList(List<Student> studentList) {
            Console.WriteLine("===Danh sach sinh vien===");
            foreach(Student student in studentList) {
                student.Output();
            }



        }
        static void DisPlayItStudentList(List<Student> studentList, string faculty) {
            Console.WriteLine("===Danh sach sinh vien khoa {0}",faculty);
            var Students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(Students);

        }
        static void DisPlayStudentsWithHighAvgScore(List<Student> studentsList, float minDTB) {
            Console.WriteLine("===Danh sach sinh vien co dien TB >= {0}", minDTB);
            var students = studentsList.Where(s => s.AvgScore >= minDTB).ToList();
            DisplayStudentList(students);


        }
        static void SortStudentByAvgScore(List<Student> studentList)
        {
            Console.WriteLine("===Danh sach sinh vien duoc sap xep theo diem trung binh tang dan ===");
                var sortedStudents = studentList.OrderBy(s => s.AvgScore).ToList();
                DisplayStudentList(sortedStudents);
        }
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB) {
            Console.WriteLine("===Danh sach sinh vien khoa TB >= {0} va khoa {1} ");
            var students = studentList.Where(s => s.AvgScore >= minDTB && s.Faculty.Equals(faculty,StringComparison.OrdinalIgnoreCase)).ToList() ;
            DisplayStudentList(students);
        }
        static void DisplayStudentsByFacultyAndMAXScore(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sach sinh vien co diem TB cao nhat va thuoc khoa {0} ", faculty);
            float highestScore = 0;
            foreach (Student student in studentList)
            {
                if (student.AvgScore >= highestScore)
                    highestScore = student.AvgScore;
            }
            var students = studentList.Where(s => s.AvgScore == highestScore && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }
        static void DisplayStudentsRank(List<Student> studentList)
        {
            Dictionary<string, int> soLuongXepLoai = new Dictionary<string, int>()
            {
                { "Xuat sac", 0 },
                { "Gioi", 0 },
                { "Kha", 0 },
                { "Trung binh", 0 },
                { "Yeu", 0 },
                { "Kem", 0 }
            };

            foreach (Student s in studentList)
            {
                if (s.AvgScore >= 9.0)
                    soLuongXepLoai["Xuat sac"]++;
                else if (s.AvgScore >= 8.0)
                    soLuongXepLoai["Gioi"]++;
                else if (s.AvgScore >= 7.0)
                    soLuongXepLoai["Kha"]++;
                else if (s.AvgScore >= 5.0)
                    soLuongXepLoai["Trung binh"]++;
                else if (s.AvgScore >= 4.0)
                    soLuongXepLoai["Yeu"]++;
                else
                    soLuongXepLoai["Kem"]++;
            }

            foreach (KeyValuePair<string, int> xepLoai in soLuongXepLoai)
            {
                Console.WriteLine(xepLoai.Key + ": " + xepLoai.Value);
            }
        }
        static void Main(string[] args)
        {
            List<Student> studentlist = new List<Student>();
            bool exit = false;
            while (!exit) {
                Console.WriteLine("===Menu===");
                Console.WriteLine("1: Them sinh vien");
                Console.WriteLine("2: Hien thi danh sach sinh vien");
                Console.WriteLine("3: Hien thi danh sach sinh vien CNTT");
                Console.WriteLine("4: Hien thi danh sach sinh vien tren 5");
                Console.WriteLine("5: Hien thi danh sach sinh vien sap xep theo diem trung binh");
                Console.WriteLine("6: Hien thi danh sach sinh vien DTB >= 5 va thuoc khoa CNTT");
                Console.WriteLine("7: Hien thi danh sach sinh vien co diem cao nhat va thuoc khoa CNTT");
                Console.WriteLine("0: Thoat");
                Console.Write("Chon chuc nang(0-3): ");
                string choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        AddStudent(studentlist);
                        break;
                    case "2":
                        DisplayStudentList(studentlist);
                        break;
                    case "3":
                        DisPlayItStudentList(studentlist,"CNTT");
                        break;
                    case "4":
                        DisPlayStudentsWithHighAvgScore(studentlist, 5);
                        break;
                    case "5":
                        SortStudentByAvgScore(studentlist); 
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentlist, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsByFacultyAndMAXScore(studentlist, "CNTT");
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Ket thuc chuong trinh");
                        break;  
                    default:
                        Console.WriteLine("Tuy chonn khong hop le. Vui long chon lai");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
