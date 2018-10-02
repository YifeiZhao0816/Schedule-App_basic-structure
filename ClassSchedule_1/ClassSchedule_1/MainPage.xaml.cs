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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ClassSchedule_1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Schedule.LoadScehdule();
            DateTime storedDate = StoreData.LoadDate();
            DateTime dateTime = DateTime.Now;

            if (dateTime.Date.Subtract(storedDate.Date).Days % 2 == 0)
                Schedule.aDay = StoreData.LoadData("DayType");
            else
                Schedule.aDay = !StoreData.LoadData("DayType");

            StoreData.SaveDate();
            StoreData.SaveData(Schedule.aDay, "DayType");

            myFrame.Navigate(typeof(Current));
            Title.Text = "Current" + StoreData.LoadData("DayType").ToString();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            HamburgerMenu.IsPaneOpen = !HamburgerMenu.IsPaneOpen;
        }

        private void HamburgerSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (HamburgerSelection.SelectedIndex)
            {
                case 0:
                    myFrame.Navigate(typeof(Current));
                    Title.Text = "Current";
                    break;
                case 1:
                    myFrame.Navigate(typeof(ClassSchedule));
                    Title.Text = "Class Schedule";
                    break;
                case 2:
                    myFrame.Navigate(typeof(Settings));
                    Title.Text = "Settings";
                    break;

                default:
                    break;
            }
        }
    }
}
