using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsHelloWorld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string ccText = entryCC.Text;
            if(ccText.Length < 5)
            {
                await DisplayAlert("Validate CC Result", "Wrong", "OK");
            }
            else
            {
                await DisplayAlert("Validate CC Result", "Correct", "OK");
            }
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var scrollViewHeight = mainSv.Height;
            var contentHeight = mainSvContent.Height;
            var maxScrollY = contentHeight - scrollViewHeight;

            double scrollPercentage = e.ScrollY / maxScrollY * 100.00;

            System.Diagnostics.Debug.WriteLine($"SV: {scrollViewHeight}, SVC: {contentHeight}, ScrollY: {e.ScrollY}");
            mainSvScrollStatus.Text = $"{scrollPercentage.ToString("0")}% scrolled";
        }
    }
}
