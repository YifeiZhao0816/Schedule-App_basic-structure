using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSchedule_1.Class
{

    // A custom class that save the data on local machine so that the data will not lose after restarting the app
    // For this part, refer to description of localSettings on Microsoft document:
    // https://docs.microsoft.com/en-us/windows/uwp/design/app-settings/store-and-retrieve-app-data

    static class StoreData
    {
        // save the current date to the localSettings
        public static void SaveDate()
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            CultureInfo culture = new CultureInfo("en-US");
            localSettings.Values["Date"] = DateTime.Now.Date.ToString(culture);
        }

        // Save a boolean with the saving name 
        public static void SaveData(bool value, string name)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values[name] = value;
        }

        // load the date last time the program saved, if there's not any, return today's date.
        public static DateTime LoadDate()
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            CultureInfo culture = new CultureInfo("en-US");
            if (localSettings.Values["Date"] != null)
            {
                String temp = (String)localSettings.Values["Date"];
                DateTime value = DateTime.Parse(temp, culture);
                return value;
            }
            else
                return DateTime.Today;
        }

        // load specific data from localSettings called name.
        public static bool LoadData(string name)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values[name] != null)
            {
                bool value = (bool)localSettings.Values[name];
                return value;
            }
            else
                return false;
        }
    }
}
