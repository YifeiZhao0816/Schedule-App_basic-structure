using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSchedule_1.Class
{
    class Subject
    {
        public int block { get; set; }                               // Block number
        public bool isA { get; set; }                                // indicates whether the subject is on A day
        public string subjectName { get; set; }                      // the name of the subject, ex. APUSH
        public TimeSpan beginTime { get; set; }                      // normal begin time
        public TimeSpan endTime { get; set; }                        // normal end time
        public TimeSpan period { get; set; }                         // normal period length

        // overload constructor method
        public Subject(int block, bool isA, string subjectName, TimeSpan beginTime, TimeSpan endTime, TimeSpan period)
        {
            this.block = block;
            this.isA = isA;
            this.subjectName = subjectName;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.period = period;
        }
    }
}
