using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentPerfomenceTRacker
{
  public class Students
    {
        public int StudentId;
        public string StudentName;
        public Dictionary<string, int> SubjectMarks = new Dictionary<string, int>();
        public void GetStudentName()
        {
            Console.WriteLine("\nEnter the Student Name :");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("\nName must not be Empty");
                GetStudentName();
            }
            else if (!Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
            {
                Console.WriteLine("\nInvalid Format");
                GetStudentName();
            }
            else
            {
                this.StudentName = name;
            }
        }
        public void GetStudentId()
        {
            Console.WriteLine("\nEnter the Student Id:");
            bool id_condition = int.TryParse(Console.ReadLine(), out int id);
            if (id_condition)
            {
                if (id < 100)
                {
                    Console.WriteLine("\nID Must Contain 3 Digits");
                    GetStudentId();
                }
                else if (StudentDetails.StudentList.Any(x => x.StudentId == id))
                {
                    Console.WriteLine("\nID Already Exist");
                    GetStudentId();
                }
                else
                {
                    this.StudentId = id;
                }


            }
            else
            {
                Console.WriteLine("\nInvalid Input");
                GetStudentId();
            }
        }
        public void GetStudentMarks()
        {
            while (true)
            {
            GetStudentsubject:
                Console.WriteLine("\nEnter the Subject Name :");
                String subject_name = Console.ReadLine();
                if (string.IsNullOrEmpty(subject_name))
                {
                    Console.WriteLine("\nSubject name must not be Empty");
                    goto GetStudentsubject;
                }
                else if (!Regex.IsMatch(subject_name, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("\nInvalid Format");
                    goto GetStudentsubject;
                }
                else if(subject_name.Length >50)
                {
                    Console.WriteLine("\nInvalid Input");
                    goto GetStudentsubject;

                }
            GetMark:
                int subject_mark;
                Console.WriteLine($"\nEnter the {subject_name} Mark: ");
                if(int.TryParse(Console.ReadLine(),out int mark))
                {
                    if(mark<0 || mark > 100)
                    {
                        Console.WriteLine("\nInvalid Mark");
                        goto GetMark;
                    }
                    else
                    {
                        subject_mark = mark;

                    }

                }
                else
                {
                    Console.WriteLine("\nInvalid Input");
                    goto GetMark;
                }

                SubjectMarks.Add(subject_name, subject_mark);
            GetOption:
                Console.WriteLine("\nNeed to Add another Subject(Y/N)");
                if(char.TryParse(Console.ReadLine(),out char subadd)){
                    if(subadd == 'y'|| subadd == 'Y' ||subadd == 'n' || subadd =='N')
                    {
                        if(subadd=='n'||subadd == 'N')
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Option");
                        goto GetOption;
                    }


                }
                else
                {
                    Console.WriteLine("\nInvalid Input");
                    goto GetOption;
                }



              

            }

        }
    }
}
