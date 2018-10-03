using ClassSchedule_1.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ClassSchedule_1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Current : Page
    {
        ObservableCollection<Subject> ts = new ObservableCollection<Subject>();                 // for data binding(bind the data to the UI)
        public Current()
        {
            this.InitializeComponent();

            DateTime storedDate = StoreData.LoadDate();                                         // get the date that the app last time opened
            DateTime dateTime = DateTime.Now;                                                   // get the current date
            // set today's day type(A/B) depending on when is the last time the app opened. if even days passed, current day type is the same as
            // the recorded day type. else, opposite
            if (dateTime.Date.Subtract(storedDate.Date).Days % 2 == 0)
                Schedule.IsAday = StoreData.LoadData("DayType");
            else
                Schedule.IsAday = !StoreData.LoadData("DayType");
            StoreData.SaveDate();                                                                // Save the current day
            StoreData.SaveData(Schedule.IsAday, "DayType");                                      // Save the current day type

            Schedule.LoadTodayClass();            
            if (Schedule.IsAday)
                DayBlock.Text += "A Day: ";
            else
                DayBlock.Text += "B Day: ";
            DayBlock.Text += dateTime.Date.Month+"/"+dateTime.Day+"/"+dateTime.Year;             // Display today's Date

            // compare the begin and end time of all subjects today with the current time to find the current subject,
            // and display the subject name/ remain time/ end time
            foreach (Subject item in Schedule.TodayClass)
            {
                if ((item.beginTime.CompareTo(dateTime.TimeOfDay) < 0) && (item.endTime.CompareTo(dateTime.TimeOfDay) > 0))
                {
                    ClassBlock.Text = item.subjectName;
                    EndTimeBlock.Text = item.endTime.Hours + ":" + item.endTime.Minutes;
                    TimeSpan timeSpan = item.endTime.Subtract(dateTime.TimeOfDay);
                    RemainTimeBlock.Text = timeSpan.Hours + "hour" + timeSpan.Minutes + "minutes";
                    if (item.block==0)
                    {
                        break;
                    }
                }
            }
            if (ClassBlock.Text == "")
            {
                ClassBlock.Text = "Break";
                EndTimeBlock.Text = "NA";
                RemainTimeBlock.Text = "NA";
            }

            foreach (Subject item in Schedule.TodayClass)
            {                                                                                    // put all subjects in the current day schedule in collection.
                ts.Add(item);                                                                    // So the subjects will display in the program window automatically. 
            }
        }
    }
}
