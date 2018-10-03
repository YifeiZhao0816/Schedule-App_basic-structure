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
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {                                                                                       // auto-generated code. refer to: 
            this.InitializeComponent();                                                         // https://stackoverflow.com/questions/245825/what-does-initializecomponent-do-and-how-does-it-work-in-wpf
                                                                                                
            Schedule.LoadScehdule();
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

            Title.Text = "Current";
            myFrame.Navigate(typeof(Current));                                                   // set the content of the windows to the page"current"
            
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)                     // When the button is clicked, open the side menu(UI operation)
        {
            HamburgerMenu.IsPaneOpen = !HamburgerMenu.IsPaneOpen;
        }

        private void HamburgerSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (HamburgerSelection.SelectedIndex)                                            // when the tab in the side menu is selected, open the correponding page
            {
                case 0:                                                                          // page Current
                    myFrame.Navigate(typeof(Current));
                    Title.Text = "Current";
                    break;
                case 1:
                    myFrame.Navigate(typeof(ClassSchedule));                                     // page Class Schedule
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
