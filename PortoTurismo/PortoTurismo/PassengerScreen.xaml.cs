using PortoTurismo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PortoTurismo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PassengerScreen : ContentPage
	{
		public PassengerScreen (int numberSeat)
		{
            
            InitializeComponent ();
            this.BackgroundImage = "darkBg";

        }

        private async void NewPassenger(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPassengerScreen()) { BarTextColor = Color.FromHex("#99ff02"), BarBackgroundColor = Color.FromHex("#999999") });
        }

        private async void FilterPassengerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.FilterPassengerSearch.Text != null && this.FilterPassengerSearch.Text.Length > 2)
            {
                this.ListViewPassengersFilter.IsVisible = true;
                this.ListViewPassengersFilter.IsRefreshing = true;
                await this.SVPassenger.ScrollToAsync(ListViewPassengersFilter, Xamarin.Forms.ScrollToPosition.End, true);

                this.ListViewPassengersFilter.ItemsSource = await App.Database.FilterPassengerNameOrRG(this.FilterPassengerSearch.Text);
                this.ListViewPassengersFilter.IsRefreshing = false;
            }
        }

        private void FilterPassengerSearch_Focused(object sender, FocusEventArgs e)
        {
            var searchBar = ((SearchBar)sender);
            if (searchBar.Text == string.Empty)
            {
                ListViewPassengersFilter.ItemsSource = null;
                //this._bind.PkProcedureOne = string.Empty;
                //this._bind.ProcedureOne = string.Empty;

            }
        }

        private void ListViewPassengersFilter_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = ((Passenger)this.ListViewPassengersFilter.SelectedItem);
            if (itemSelected != null)
            {

                this.FilterPassengerSearch.Text = itemSelected.Name;
                //this._bind.PkProcedureOne = itemSelected.PkProcedure;
                //this._bind.ProcedureOne = itemSelected.ProcedureName;
                ListViewPassengersFilter.IsVisible = false;
                //ChargeControlsScreen();
            }
        }

        private async void Close_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}