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



namespace ClassSchedule_1
{
    
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
            switch (Schedule.SchoolStatus)                      // UI operation.
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
            if (Schedule.IsAday)                                // UI operation
            {
                ComboBox2.SelectedIndex = 0;
            }
            else
                ComboBox2.SelectedIndex = 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox1.SelectedIndex)                    // when one of the ComboBoxItem is selected, (TWo Hour Dissmisal, etc.) reload schedule
            {
                case 0:
                    Schedule.SchoolStatus = SchoolStatus.THED;
                    break;
                case 1:
                    Schedule.SchoolStatus = SchoolStatus.TED;
                    break;
                case 2:
                    Schedule.SchoolStatus = SchoolStatus.normal;
                    break;
                default:
                    break;
            }
            
            Schedule.LoadTodayClass();
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox2.SelectedIndex == 0)                   // let user set the day type of current day. 
            {
                StoreData.SaveDate();
                StoreData.SaveData(true, "DayType");
                Schedule.IsAday = true;
            }
            else
            {
                StoreData.SaveDate();
                StoreData.SaveData(false, "DayType");
                Schedule.IsAday = false;
            }
                

            
        }
    }
}
