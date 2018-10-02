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
    public sealed partial class ClassSchedule : Page
    {
        ObservableCollection<Subject> Aschedule= new ObservableCollection<Subject>();
        ObservableCollection<Subject> Bschedule= new ObservableCollection<Subject>();

        public ClassSchedule()
        {
             
            this.InitializeComponent();
            foreach (Subject item in Schedule.subjects)
            {
                if (item.isA)
                    Aschedule.Add(item);
                else
                    Bschedule.Add(item);
            }
        }


    }
}
