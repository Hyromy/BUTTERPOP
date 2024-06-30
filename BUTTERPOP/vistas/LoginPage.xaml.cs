using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Diagnostics;

namespace BUTTERPOP.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        private bool IsTurnX;
        private bool IsTurnY;
        private double valueX;
        private double valueY;
        private bool selection1Active;
        private bool selection2Active;

        public LoginPage()
        {
            InitializeComponent();

            IsTurnX = false;
            IsTurnY = false;
            valueX = 0;
            valueY = 0;
            selection1Active = true;
            selection2Active = false;


            UpdateButtonColors();
        }

        private void UpdateButtonColors()
        {
            if (selection1Active)
            {
                txt1.TextColor = Color.White;
                txt2.TextColor = Color.Black;
                runningFrame.TranslateTo(runningFrame.X, 0, 120);
                loginForm.IsVisible = true;
                registerForm.IsVisible = false;

            }
            else if (selection2Active)
            {
                txt1.TextColor = Color.Black;
                txt2.TextColor = Color.White;
                runningFrame.TranslateTo(runningFrame.X + 86, 0, 120);
                loginForm.IsVisible = false;
                registerForm.IsVisible = true;
            }
        }

        public void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var x = e.TotalX;
            var y = e.TotalY;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    Debug.WriteLine("Started");
                    break;
                case GestureStatus.Running:
                    Debug.WriteLine("Running");

                    if ((x >= 5 || x <= -5) && !IsTurnX && !IsTurnY)
                    {
                        IsTurnX = true;
                    }

                    if ((y >= 5 || y <= -5) && !IsTurnY && !IsTurnX)
                    {
                        IsTurnY = true;
                    }


                    if (IsTurnX && !IsTurnY)
                    {
                        if (x <= valueX)
                        {

                            if (selection2Active)
                            {
                                selection1Active = true;
                                selection2Active = false;
                                UpdateButtonColors();
                            }
                        }

                        if (x >= valueX)
                        {

                            if (selection1Active)
                            {
                                selection1Active = false;
                                selection2Active = true;
                                UpdateButtonColors();
                            }
                        }




                    }
                    break;
                case GestureStatus.Completed:
                    Debug.WriteLine("Completed");

                    valueX = x;
                    valueY = y;

                    IsTurnX = false;
                    IsTurnY = false;
                    break;
                case GestureStatus.Canceled:
                    Debug.WriteLine("Canceled");
                    break;
            }
        }

        private void OnText1Tapped(object sender, EventArgs e)
        {
            if (!selection1Active)
            {
                selection1Active = true;
                selection2Active = false;
                UpdateButtonColors();
            }
        }

        private void OnText2Tapped(object sender, EventArgs e)
        {
            if (!selection2Active)
            {
                selection1Active = false;
                selection2Active = true;
                UpdateButtonColors();
            }
        }
    }
}