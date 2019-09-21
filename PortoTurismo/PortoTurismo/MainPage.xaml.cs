using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PortoTurismo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.BackgroundImage = "darkBg";
            this.Title = "Porto Turismo";
            this.BackgroundColor = Color.WhiteSmoke;
            
            var stackL = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var darkGry = Color.FromHex("#323232");
            var textColor = Color.FromHex("#ffff00");
            var imgSeat = "seateWhite48.png";


            for (int i = 1; i <= 46; i++)
            {
                
                 
                var btn = new Button();
                btn.BackgroundColor = darkGry;
                btn.TextColor = textColor;
                btn.Text = i.ToString();
                btn.HeightRequest = 82;
                btn.WidthRequest = 82;
                btn.Image = imgSeat;
                btn.CornerRadius = 41;
                btn.Clicked += SeatButton_Clicked;
                // <StackLayout Orientation="Vertical"  HorizontalOptions="FillAndExpand">
                var container = new StackLayout() { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand};
                container.Children.Add(btn);
                stackL.Children.Add(container);
                MainSL.Children.Add(stackL);
                if (i % 4 == 0 )
                {
                    stackL = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                }
            }
            

            
        }

        private async  void SeatButton_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var x = btn.Id;
            var y =btn.Text;

            
            await Navigation.PushModalAsync(new NavigationPage(new PassengerScreen(int.Parse(y))) { BarTextColor = Color.FromHex("#99ff02"), BarBackgroundColor = Color.FromHex("#999999") });
        }
    }
}
