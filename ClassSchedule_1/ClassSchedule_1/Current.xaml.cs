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
        ObservableCollection<Subject> ts = new ObservableCollection<Subject>();
        public Current()
        {
            DateTime dateTime = DateTime.Now;
            this.InitializeComponent();
            Schedule.LoadTodayClass();
            
            foreach (Subject item in Schedule.todayClass)
            {
                ts.Add(item);
            }
            if (Schedule.aDay)
                DayBlock.Text += "A Day: ";
            else
                DayBlock.Text += "B Day: ";
            DayBlock.Text += dateTime.Date.Month+"/"+dateTime.Day+"/"+dateTime.Year;

            foreach (Subject item in Schedule.todayClass)
            {
                if (item.beginTime.CompareTo(dateTime.TimeOfDay)<0 && item.endTime.CompareTo(dateTime.TimeOfDay) > 0)
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
            if (ClassBlock.Text == null)
            {
                ClassBlock.Text = "Break";
                EndTimeBlock.Text = "NA";
                RemainTimeBlock.Text = "NA";
            }
        }
    }
}
