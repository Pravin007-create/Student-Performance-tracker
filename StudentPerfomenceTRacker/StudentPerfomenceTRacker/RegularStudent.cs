using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerfomenceTRacker
{
    public class RegularStudent:Students,IStudents
    {
        public double AverageForRegularStudent;
        public string GradeForRegularStudent;
        public void CalculateAverage()
        {
           this. AverageForRegularStudent = this.SubjectMarks.Average(x => x.Value);

        }
      public void CalculateGrade()
        {
            double avg = this.AverageForRegularStudent;
            this.GradeForRegularStudent = avg > 90 ? "A+" : avg > 80 ? "A" : avg > 70 ? "B+" : avg > 60 ? "B" : avg > 50 ? "D" : "F";
                

        }

    }
}
