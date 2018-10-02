using ClassSchedule_1.Class;
using System;
using System.Collections.Generic;
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
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
            switch (Schedule.schoolStatus)
            {
                case SchoolStatus.THED:
                    ComboBox1.SelectedIndex = 0;
                    break;
                case SchoolStatus.TED:
                    ComboBox1.SelectedIndex = 1;
                    break;
                case SchoolStatus.normal:
                    ComboBox1.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
            if (Schedule.aDay)
            {
                ComboBox2.SelectedIndex = 0;
            }
            else
                ComboBox2.SelectedIndex = 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox1.SelectedIndex)
            {
                case 0:
                    Schedule.schoolStatus = SchoolStatus.THED;
                    break;
                case 1:
                    Schedule.schoolStatus = SchoolStatus.TED;
                    break;
                case 2:
                    Schedule.schoolStatus = SchoolStatus.normal;
                    break;
                default:
                    break;
            }
            
            Schedule.LoadTodayClass();
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox2.SelectedIndex == 0)
            {
                StoreData.SaveDate();
                StoreData.SaveData(true, "DayType");
                Schedule.aDay = true;
            }
            else
            {
                StoreData.SaveDate();
                StoreData.SaveData(false, "DayType");
                Schedule.aDay = false;
            }
                

            
        }
    }
}
