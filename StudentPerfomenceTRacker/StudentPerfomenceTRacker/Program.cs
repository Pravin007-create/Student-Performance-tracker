using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerfomenceTRacker
{
    internal class Program
    {
        static void Main(string[] args)
        {
        MainMenu:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n========== Student Management Menu ==========\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("      1. Add Student");
            Console.WriteLine("      2. Update Student");
            Console.WriteLine("      3. Delete Student");
            Console.WriteLine("      4. Search Student");
            Console.WriteLine("      5. Result for All Students");
            Console.WriteLine("      6. Display All Students");
            Console.WriteLine("      7. Exit");
            Console.ResetColor();
            Console.WriteLine();
            if(int .TryParse(Console.ReadLine(),out int option))
            {
                switch (option) {
                    case 1:
                    AddMenu:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("    1. Regular Student ");
                        Console.WriteLine("    2. Exchange Student ");
                        Console.ResetColor();
                        if (int .TryParse(Console.ReadLine(),out int choice)){
                            switch (choice) {
                                case 1:
                                    RegularStudent regular_student = new RegularStudent();
                                    regular_student.GetStudentId();
                                    regular_student.GetStudentName();
                                    regular_student.GetStudentMarks();
                                    regular_student.CalculateAverage();
                                    regular_student.CalculateGrade();
                                    
                                    StudentDetails.StudentList.Add(regular_student);
                                    StudentDetails.DisplayStutentList();
                                    break;
                                case 2:
                                    ExchangeStudent exchangeStudent = new ExchangeStudent();
                                    exchangeStudent.GetStudentId();
                                    exchangeStudent.GetStudentName();
                                    exchangeStudent.GetStudentMarks();
                                    exchangeStudent.CalculateAverage();
                                    exchangeStudent.CalculateGrade();
                                    StudentDetails.StudentList.Add(exchangeStudent);
                                    StudentDetails.DisplayStutentList();
                                    break;

                                default:
                                    Console.WriteLine("\nInvalid Option");
                                    goto AddMenu;
                                    
                            
                            
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input");
                            goto case 1;
                        }
                        goto MainMenu;

                    case 2:
                        if (StudentDetails.StudentList.Count() <= 0)
                        {
                            Console.WriteLine("\nThe List is Empty");
                        }
                        else
                        {
                            StudentDetails.UpdateStudent();
                        }
                           
                        goto MainMenu;
                    case 3:
                        if (StudentDetails.StudentList.Count() <= 0)
                        {
                            Console.WriteLine("\nThe List is Empty");
                        }
                        else
                        {
                            StudentDetails.DeleteStudent();
                        }

                           
                        goto MainMenu;
                    case 4:
                        if (StudentDetails.StudentList.Count() <= 0)
                        {
                            Console.WriteLine("\nThe List is Empty");
                        }
                        else
                        {
                            StudentDetails.SearchStudent();
                        }
                           
                        goto MainMenu;
                    case 5:
                        
                        StudentDetails.DisplayStudentsResult();
                        goto MainMenu;
                    case 6:
                        if (StudentDetails.StudentList.Count() <= 0)
                        {
                            Console.WriteLine("\nThe List is Empty");
                        }
                        else
                        {
                            StudentDetails.DisplayStutentList();
                        }
                            
                        goto MainMenu;
                    case 7:
                        break;

                    default:
                        Console.WriteLine("\nInvalid Option");
                        goto MainMenu;




















                }




            }
            else {
                Console.WriteLine("Invalid Input");
                goto MainMenu;
            }

        }
    }
}
