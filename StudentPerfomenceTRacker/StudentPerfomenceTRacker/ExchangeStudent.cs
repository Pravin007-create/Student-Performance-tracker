using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerfomenceTRacker
{
   public class ExchangeStudent:Students,IStudents
    {
        public double AverageForExchangeStudent;
        public string Result;
        public void CalculateAverage()
        {
            this.AverageForExchangeStudent = this.SubjectMarks.Average(x=>x.Value);

        }
        public void CalculateGrade()
        {
           double avg = this.AverageForExchangeStudent;
            if (avg > 60) {
                this.Result = "Pass";
            }
            else {
                this.Result = "False";
            }
        }

    }
}
