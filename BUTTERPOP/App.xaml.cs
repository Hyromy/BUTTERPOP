using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BUTTERPOP.db;

namespace BUTTERPOP
{
    public partial class App : Application
    {
        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "MediaElement_Experimental", "Brush_Experimental" });
            MainPage = new NavigationPage(new vistas.LoginPage());
        }

        public static SQLiteHelper SQLiteDB
        {
            get 
            {
                if (db==null)
                {
                    db = new SQLiteHelper();
                }
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
