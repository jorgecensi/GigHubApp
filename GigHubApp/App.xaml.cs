﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GigHubApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GigHubApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new RegisterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
