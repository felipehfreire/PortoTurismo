using PortoTurismo.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PortoTurismo
{
	public partial class App : Application
	{
        static PortoTurismoDataBase database;

        public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new PortoTurismo.MainPage()) { BarTextColor = Color.FromHex("#99ff02") , BarBackgroundColor = Color.FromHex("#999999") }; 
            //MainPage = new Page1() { BackgroundImage = "dark.png", Title="teste"};
        }
        public static PortoTurismoDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PortoTurismoDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PORTO_TURISMO_DB.db3"));
                }
                return database;
            }
        }
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
