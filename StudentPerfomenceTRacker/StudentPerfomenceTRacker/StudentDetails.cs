using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentPerfomenceTRacker
{
    public class StudentDetails
    {
        public static List<Students> StudentList = new List<Students>();
       

        
        
  
    

// Add to base class list



        public static void DisplayStudentsResult()
        {
            int TotalStudent;
            int TotalRegularStudent;
            int TotalExchangeStudent;
            int ExchangeStudentPassCount;
            int ExchangeStudentFailCount;
            int RegularStudentGradeAp;
            int RegularStudentGradeA;
            int RegularStudentGradeB;
            int RegularStudentGradeC;
            int RegularStudentGradeD;
            int RegularStudentGradeF;

            TotalStudent = StudentList.Count();
            //total regular students
            var regular_student = StudentList.OfType<RegularStudent>();
            //total exchange student
            var exchange_student = StudentList.OfType<ExchangeStudent>();
            TotalRegularStudent = regular_student.Count();
            TotalExchangeStudent = exchange_student.Count();
            ExchangeStudentPassCount = exchange_student.Count(x=>x.Result=="Pass");
            ExchangeStudentFailCount = exchange_student.Count(x=> x.Result == "Fail");
            RegularStudentGradeAp = regular_student.Count(x => x.GradeForRegularStudent == "A+");
            RegularStudentGradeA = regular_student.Count(x => x.GradeForRegularStudent == "A");
            RegularStudentGradeB = regular_student.Count(x => x.GradeForRegularStudent == "B");
            RegularStudentGradeC = regular_student.Count(x => x.GradeForRegularStudent == "C");
            RegularStudentGradeD = regular_student.Count(x => x.GradeForRegularStudent == "D");
            RegularStudentGradeF = regular_student.Count(x => x.GradeForRegularStudent == "F");
            Console.WriteLine("______________________________________Student__________________________________________");

            Console.WriteLine(string.Format("{0,-20}{1,-30}{2,-30}","Total Students","Total Regular STudents","Total Exchange Students"));
            Console.WriteLine(string.Format("{0,-20}{1,-30}{2,-30}",TotalStudent,TotalRegularStudent,TotalExchangeStudent));
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine("______________________________________Exchange Students__________________________________________");
            
            Console.WriteLine(string.Format("{0,-33}{1,-33}", "Total Exchange students Pass","Total Exchange Student Fail"));
            Console.WriteLine(string.Format("{0,-33}{1,-33}", ExchangeStudentPassCount,ExchangeStudentFailCount));
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine("______________________________________Regular Student Grade__________________________________________");
            Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "Grade A+","Grade A","Grade B","Grade C","Grade D","Grade F"));
            Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", RegularStudentGradeAp,RegularStudentGradeA,RegularStudentGradeB,RegularStudentGradeC,RegularStudentGradeD,RegularStudentGradeF));
            Console.WriteLine("________________________________________________________________________________________________");





        }
        public static void DisplayStutentList()
        {
            var total_regular_students = StudentList.OfType<RegularStudent>();
            var total_exchange_students = StudentList.OfType<ExchangeStudent>();

            Console.WriteLine("\n*****Regular Students List*******");
            foreach(RegularStudent student in total_regular_students)
            {
                Console.WriteLine($"Name         : {student.StudentName}");
                Console.WriteLine($"Student Id   : {student.StudentId}");
                Console.WriteLine($"Average Mark : {student.AverageForRegularStudent}");
                Console.WriteLine($"Grade        : {student.GradeForRegularStudent}");
                Console.WriteLine(string.Format("{0,-10}{1,-10}","Subjects","Marks"));
                Console.WriteLine();
                foreach(string subject in student.SubjectMarks.Keys)
                {
                    Console.WriteLine(string.Format("{0,-10}{1,-5}", subject, student.SubjectMarks[subject]));


                }
                Console.WriteLine("---------------------------------------------------");
            }
            Console.WriteLine("\n*********Exchange Student List**************");
            foreach(ExchangeStudent student in total_exchange_students)
            {
                Console.WriteLine($"Name         : {student.StudentName}");
                Console.WriteLine($"Student Id   : {student.StudentId}");
                Console.WriteLine($"Average Mark : {student.AverageForExchangeStudent}");
                Console.WriteLine($"Grade        : {student.Result}");
                Console.WriteLine(string.Format("{0,-10}{1,-5}", "Subjects", "Marks"));
                Console.WriteLine();
                foreach(string subject in student.SubjectMarks.Keys)
                {
                    Console.WriteLine(string.Format("{0,-10}{1,-5}", subject, student.SubjectMarks[subject]));

                }
                Console.WriteLine("---------------------------------------------------");

            }


        }
        public static void DeleteStudent()
        {
            Console.WriteLine("\nEnter the Student ID For Delete");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                if (StudentList.Any(x => x.StudentId == id))
                {
                    var delete_student = StudentList.First(x => x.StudentId == id);
                    Choice:
                    Console.WriteLine($"\nYou want to Delete the Student {delete_student.StudentName}(y/n):");
                    if(char.TryParse(Console.ReadLine(),out char delete))
                    {
                        if(delete == 'y' || delete == 'n')
                        {
                            if(delete == 'y')
                            {
                                StudentList.Remove(delete_student);
                                Console.WriteLine($"\nStudent {delete_student.StudentName} is Deleted Successfully");
                                DisplayStutentList();

                            }

                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input");
                            goto Choice;
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nInvalis input");
                        goto Choice;
                        
                    }
                        


                }
                else
                {
                    Console.WriteLine("\nStudent Id Not Exists");
                    DeleteStudent();
                }

            }
            else
            {
                Console.WriteLine("\nInvalid Input");
                DeleteStudent();
            }
        }
        public static void UpdateStudent()
        {
            DisplayStutentList();
            Console.WriteLine("\nEntere the Student ID to Update");
            if(int.TryParse(Console.ReadLine(),out int id))
            {
                if(!StudentList.Any(x=>x.StudentId == id))
                {
                    Console.WriteLine("\nStudent ID Not Exist");
                    UpdateStudent();
                }
                else
                {
                    var update_student = StudentList.First(x => x.StudentId == id);
                    Console.WriteLine("**********Student Details*************");
                    Console.WriteLine($"\nName : {update_student.StudentName} | Id : {update_student.StudentId}");
                   
                OptionToUpdate:
                    Console.WriteLine("\n1.Name");
                    Console.WriteLine("\n2.Id");
                    Console.WriteLine("\n3.Marks");
                    Console.WriteLine("\n4.Exit");
                    if(int.TryParse(Console.ReadLine(),out int option)){
                        switch (option) {
                            case 1:
                                update_student.GetStudentName();
                                goto OptionToUpdate;
                            case 2:
                                update_student.GetStudentId();
                                goto OptionToUpdate;
                            case 3:
                                update_student.GetStudentMarks();
                                goto OptionToUpdate;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("\nInvalid option");
                                goto OptionToUpdate;


                        
                        
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input");
                        goto OptionToUpdate;
                    }
                    Console.WriteLine("\nUpdated Successfully");
                    Console.WriteLine($"\nStudent Name : {update_student.StudentName} | Student Id :{update_student.StudentId}");
                    DisplayStutentList();

                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }


        }
        public static void SearchStudent()
        {
            Console.WriteLine("\nEnter the Student Id or Student Name to Search");
            string name_or_id = Console.ReadLine();
            if(int.TryParse(name_or_id,out int id))
            {
                if(StudentList.Any(x=>x.StudentId == id))
                {
                    var students = StudentList.Where(x=>x.StudentId== id).ToList();
                    var regular_student  =students.OfType<RegularStudent>();
                    var exchange_student =students.OfType<ExchangeStudent>();
                    Console.WriteLine("\n*****Regular Students*****");
                    foreach (RegularStudent student in regular_student)
                    {
                        Console.WriteLine($"Name         : {student.StudentName}");
                        Console.WriteLine($"Student Id   : {student.StudentId}");
                        Console.WriteLine($"Average Mark : {student.AverageForRegularStudent}");
                        Console.WriteLine($"Grade        : {student.GradeForRegularStudent}");
                        Console.WriteLine(string.Format("{0,-10}{1,-5}", "Subjects", "Marks"));
                        Console.WriteLine();
                        foreach (string subject in student.SubjectMarks.Keys)
                        {
                            Console.WriteLine(string.Format("{0,-10}{1,-5}", subject, student.SubjectMarks[subject]));


                        }
                        Console.WriteLine("---------------------------------------------------");
                    }

                    Console.WriteLine("\n*****Exchange Students*****");

                    foreach (ExchangeStudent student in exchange_student)
                    {
                        Console.WriteLine($"Name         : {student.StudentName}");
                        Console.WriteLine($"Student Id   : {student.StudentId}");
                        Console.WriteLine($"Average Mark : {student.AverageForExchangeStudent}");
                        Console.WriteLine($"Grade        : {student.Result}");
                        Console.WriteLine(string.Format("{0,-10}{1,-5}", "Subjects", "Marks"));
                        Console.WriteLine();
                        foreach (string subject in student.SubjectMarks.Keys)
                        {
                            Console.WriteLine(string.Format("{0,-10}{1,-5}", subject, student.SubjectMarks[subject]));

                        }
                        Console.WriteLine("---------------------------------------------------");

                    }




                }
                else
                {
                    Console.WriteLine("\nID Not exits");
                    SearchStudent();
                }




            }
            else
            {
                if(Regex.IsMatch(name_or_id,@"^[a-zA-Z ]+$") && StudentList.Any(x=>x.StudentName.ToLower()==name_or_id.ToLower()))
                {

                    var total_student = StudentList.Where(x=>x.StudentName.ToLower()==name_or_id.ToLower()).ToList();
                    var regular_student = total_student.OfType<RegularStudent>();
                    var exchange_student = total_student.OfType<ExchangeStudent>();

                    Console.WriteLine("\n*****Regular Students*****");
                    foreach (RegularStudent student in regular_student)
                    {
                        Console.WriteLine($"Name         : {student.StudentName}");
                        Console.WriteLine($"Student Id   : {student.StudentId}");
                        Console.WriteLine($"Average Mark : {student.AverageForRegularStudent}");
                        Console.WriteLine($"Grade        : {student.GradeForRegularStudent}");
                        Console.WriteLine(string.Format("{0,-10}{1,-5}", "Subjects", "Marks"));
                        Console.WriteLine();
                        foreach (string subject in student.SubjectMarks.Keys)
                        {
                            Console.WriteLine(string.Format("{0,-10}{1,-5}", subject, student.SubjectMarks[subject]));


                        }
                        Console.WriteLine("---------------------------------------------------");
                    }

                    Console.WriteLine("\n*****Exchange Students*****");

                    foreach (ExchangeStudent student in exchange_student)
                    {
                        Console.WriteLine($"Name         : {student.StudentName}");
                        Console.WriteLine($"Student Id   : {student.StudentId}");
                        Console.WriteLine($"Average Mark : {student.AverageForExchangeStudent}");
                        Console.WriteLine($"Grade        : {student.Result}");
                        Console.WriteLine(string.Format("{0,-10}{1,-5}", "Subjects", "Marks"));
                        Console.WriteLine();
                        foreach (string subject in student.SubjectMarks.Keys)
                        {
                            Console.WriteLine(string.Format("{0,-10}{1,-5}", subject, student.SubjectMarks[subject]));

                        }
                        Console.WriteLine("---------------------------------------------------");

                    }




                }
                else
                {
                    Console.WriteLine("\nName is not Exist");
                    SearchStudent();
                }
            }
        }
    }
}