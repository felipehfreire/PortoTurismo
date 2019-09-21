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
	public partial class NewPassengerScreen : ContentPage
	{
		public NewPassengerScreen ()
		{
			InitializeComponent ();

            this.BackgroundImage = "darkBg";
           
        }

        private void Format_RG(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;
            string val = entry.Text;
            if (string.IsNullOrEmpty(val))
                return;
            val = val.Replace(".", String.Empty).Replace("-", String.Empty);
            if (val.Length > 9)
            {
                val = val.Remove(val.Length - 1);
            }
            if (val.Length == 3)
            {
                val = val.Replace("-", String.Empty).Replace(".", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"00\.0");
            }
            else if (val.Length == 4)
            {
                val = val.Replace("-", String.Empty).Replace(".", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"00\.00");
            }
            else if (val.Length == 5)
            {
                val = val.Replace("-", String.Empty).Replace(".", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"00\.000");
            }
            else if (val.Length == 6)
            {
                val = val.Replace("-", String.Empty).Replace(".", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"00\.000\.0");
            }
            else if (val.Length == 7)
            {
                val = val.Replace("-", String.Empty).Replace(".", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"00\.000\.00");
            }
            else if (val.Length == 8)
            {
                val = val.Replace("-", String.Empty).Replace(".", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"00\.000\.000");
            }
            else if (val.Length == 9)
            {
                val = val.Replace("-", String.Empty).Replace(".", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"00\.000\.000\-0");
            }
           
            entry.Text = val;

        }

        private void Format_Telephone(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;
            string val = entry.Text;
            if (string.IsNullOrEmpty(val))
                return;
            val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
            if (val.Length > 11)
            {
                val = val.Remove(val.Length - 1);
            }

            if (val.Length == 1)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(0");
            }
            else if (val.Length == 2)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00");
            }
            else if (val.Length == 3)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0");
            }
            else if (val.Length == 4)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0\ 0");
            }
            else if (val.Length == 5)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0\ 00");
            }
            else if (val.Length == 6)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0\ 000");
            }
            else if (val.Length == 7)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0\ 0000");
            }

            else if (val.Length == 8)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0\ 0000\-0");
            }

            else if (val.Length == 9)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0\ 0000\-00");
            }
            else if (val.Length == 10)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0\ 0000\-000");
            }
            else if (val.Length == 11)
            {
                val = val.Replace("(", String.Empty).Replace(")", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);
                val = Convert.ToUInt64(val).ToString(@"\(00\)\ 0\ 0000\-0000");
            }
            entry.Text = val;

        }

        private async void Save_Passenger(object sender, EventArgs e)
        {
            List<Passenger> pss = await App.Database.GetPassengersAsync();
            if (pss != null)
            {
                foreach (var passenger in pss)
                {
                    //await App.Database.DeletePassengerAsync(passenger);
                }
            }
            if (await CanSavePassenger()) {
                var passenger = new Passenger(this.PassengerName.Text, this.PassengerRG.Text, this.PassengerTelephone.Text);
               var isSave= await App.Database.SavePassengerAsync(passenger);
                if (isSave >0)
                {
                    await DisplayAlert("Sucesso", "Registro inserido", "OK");
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
            }
        }

        private async Task<bool> CanSavePassenger()
        {
            var canExecute = true;
            var msg = string.Empty;
            if (string.IsNullOrWhiteSpace(this.PassengerName.Text))
            {
                msg += "O nome do passageiro deve ser informado" + "\n"; ;
                canExecute = false;
            }
            else if (this.PassengerName.Text != null)
            {
                var psg = await App.Database.GetPassengersByNameAsync(this.PassengerName.Text);
                if (psg != null)
                {
                    msg += "Já existe um passageiro com o nome: "+ this.PassengerName.Text +"\n";
                    canExecute = false;
                }
               
            }

             if (string.IsNullOrWhiteSpace(this.PassengerTelephone.Text))
            {
                msg += "O telefone do passageiro deve ser informado" + "\n"; ;
                canExecute = false;
            }
            else if (this.PassengerTelephone.Text != null)
            {
                var psg = await App.Database.GetPassengersByPassengerTelephoneAsync(this.PassengerTelephone.Text);
                if (psg != null)
                {
                    msg += "Já existe um passageiro com o telefone: " + this.PassengerTelephone.Text + "\n"; ;
                    canExecute = false;
                }

            }

            if (string.IsNullOrWhiteSpace(this.PassengerRG.Text))
            {
                msg += "O RG do passageiro deve ser informado" + "\n"; ;
                canExecute = false;
            }

            else if (this.PassengerRG.Text != null)
            {
                var psg = await App.Database.GetPassengersByPassengerDocumentAsync(this.PassengerRG.Text);
                if (psg != null)
                {
                    msg += "Já existe um passageiro com o RG: " + this.PassengerRG.Text + "\n"; ;
                    canExecute = false;
                }

            }
            if (!canExecute)
            {
               await  DisplayAlert("Alerta", msg, "OK");
            }
            return await Task<bool>.Factory.StartNew(() =>
                     canExecute);
            
        }
        private async void Close_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}