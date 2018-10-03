using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSchedule_1.Class
{

    public enum SchoolStatus {THED, TED, normal }                                   // Enumeration of school Status

    static class Schedule
    {
        public static bool IsAday { get; set; }                                       // indicates whether the current date is a A day
        public static List<Subject> Subjects { get; set; }                          // A list that contains all classes
        public static List<Subject> TodayClass { get; set; }                        // A list that contains all current day classes
        public static SchoolStatus SchoolStatus { get; set; }                       // current day school status
        public static TimeSpan Cache { get => cache; set => cache = value; }

        private static TimeSpan cache;                                               // medium variable

        public static void LoadScehdule()
        {
            // load hardcoded schedule
            SchoolStatus = SchoolStatus.normal;
            Subjects = new List<Subject>();
            Subjects.Add(new Subject(1, true, "Calculus AB", new TimeSpan(8, 20, 0), new TimeSpan(9, 55, 0), new TimeSpan(1, 35, 0)));
            Subjects.Add(new Subject(3, true, "Study Hall", new TimeSpan(10, 00, 0), new TimeSpan(11, 35, 0), new TimeSpan(1, 35, 0)));
            Subjects.Add(new Subject(5, true, "APCS", new TimeSpan(11, 40, 0), new TimeSpan(13, 15, 0), new TimeSpan(1, 35, 0)));
            Subjects.Add(new Subject(0, true, "3nd Lunch", new TimeSpan(13, 15, 0), new TimeSpan(13, 45, 0), new TimeSpan(0, 30, 0)));
            Subjects.Add(new Subject(7, true, "CAD Drawing", new TimeSpan(13, 50, 0), new TimeSpan(15, 25, 0), new TimeSpan(1, 35, 0)));
            Subjects.Add(new Subject(2, false, "Pre-AP Chemistry", new TimeSpan(8, 20, 0), new TimeSpan(9, 55, 0), new TimeSpan(1, 35, 0)));
            Subjects.Add(new Subject(4, false, "French II", new TimeSpan(10, 00, 0), new TimeSpan(11, 35, 0), new TimeSpan(1, 35, 0)));
            Subjects.Add(new Subject(6, false, "AP US History", new TimeSpan(11, 40, 0), new TimeSpan(13, 45, 0), new TimeSpan(2, 05, 0)));
            Subjects.Add(new Subject(0, false, "2nd Lunch", new TimeSpan(12, 25, 0), new TimeSpan(12, 55, 0), new TimeSpan(0, 30, 0)));
            Subjects.Add(new Subject(8, false, "English", new TimeSpan(13, 50, 0), new TimeSpan(15, 25, 0), new TimeSpan(1, 35, 0)));
        }

        public static void LoadTodayClass()
        {
            TodayClass = new List<Subject>();                            // instantiation 
            foreach (Subject subject in Subjects)                        // pick out all current day classes depending on the daytype
            {
                if (subject.isA == IsAday)
                {
                    TodayClass.Add(subject);
                }
            }
            switch (SchoolStatus)                                        // edit the Schedule depending on the schoolstatus             
            {
                case SchoolStatus.THED:                                  // Two Hour Early Dismissal
                    Cache = new TimeSpan(8, 20, 0);                      // School Begin time
                    foreach (Subject item in TodayClass)                 // for every block in the list todayClass
                    {
                        if (item.block != 0)                             // for every block that is not a lunch block, reduce the block length by half hour
                        {
                            item.beginTime = Cache;
                            item.endTime = item.beginTime.Add(item.period.Subtract(new TimeSpan(0, 30, 0)));
                            Cache = item.endTime.Add(new TimeSpan(0, 5, 0));
                        }
                        else                                             // edit lunch block depending on the lunch type
                        {
                            if (item.subjectName.Equals("1nd Lunch"))
                            {
                                item.beginTime = new TimeSpan(10, 35, 0);
                                item.endTime = item.beginTime.Add(item.period);
                                Cache = item.endTime.Add(new TimeSpan(0, 35, 0));
                            }
                            else if (item.subjectName.Equals("2nd Lunch"))
                            {
                                item.beginTime = new TimeSpan(11, 15, 0);
                                item.endTime = item.beginTime.Add(item.period);
                            }
                            else
                            {
                                item.beginTime = new TimeSpan(11, 45, 0);
                                item.endTime = item.beginTime.Add(item.period);
                                Cache = item.endTime.Add(new TimeSpan(0, 5, 0));
                            }
                        }
                        
                    }
                    break;
                case SchoolStatus.TED:                                     // Same thing for Two hour delay
                    Cache = new TimeSpan(10, 20, 0);
                    foreach (Subject item in TodayClass)
                    {
                        item.beginTime = Cache;
                        if (item.block != 0)
                        {
                            item.beginTime = Cache;
                            item.endTime = item.beginTime.Add(item.period.Subtract(new TimeSpan(0, 30, 0)));
                            Cache = item.endTime.Add(new TimeSpan(0, 5, 0));
                        }
                        else
                        {
                            if (item.subjectName.Equals("1nd Lunch"))
                            {
                                item.beginTime = new TimeSpan(10, 35, 0);
                                item.endTime = item.beginTime.Add(item.period);
                                Cache = item.endTime.Add(new TimeSpan(0, 35, 0));
                            }
                            else if (item.subjectName.Equals("2nd Lunch"))
                            {
                                item.beginTime = new TimeSpan(11, 15, 0);
                                item.endTime = item.beginTime.Add(item.period);
                            }
                            else
                            {
                                item.beginTime = new TimeSpan(11, 45, 0);
                                item.endTime = item.beginTime.Add(item.period);
                                Cache = item.endTime.Add(new TimeSpan(0, 5, 0));
                            }
                        }
                    }
                    break;
                case SchoolStatus.normal:
                    break;
                default:
                    break;
            }
        }


    }
}
