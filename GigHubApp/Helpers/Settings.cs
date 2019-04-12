using System;
using Xamarin.Essentials;

namespace GigHubApp.Helpers
{
    public class Settings
    {
        public Settings()
        {
        }
        public static string Username
        {
            get
            {
                return Preferences.Get("username", "");
            }
            set
            {
                Preferences.Set("username", value);
            }
        }
        public static string Password
        {
            get
            {
                return Preferences.Get("password", "");
            }
            set
            {
                Preferences.Set("password", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return Preferences.Get("accessToken", "");
            }
            set
            {
                Preferences.Set("accessToken", value);
            }
        }

        public static void Clear()
        {
            AccessToken = "";
            Username = "";
            Password = "";
        }
    }
}
