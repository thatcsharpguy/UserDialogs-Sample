using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Dialogs
{
    public class DialogsPage : ContentPage
    {
		Button ShowTraditionalAlertButton;
		Button ShowAlertButton;
        Button ShowToastButton;
        Button ShowErrorButton;
        Button ShowSuccessButton;
        Button ShowProgressButton;
        Entry MillisecondsEntry;

        public DialogsPage()
        {
			ShowTraditionalAlertButton = new Button { Text = "Show traditional alert" };
			ShowTraditionalAlertButton.Clicked += ShowTraditionalAlertClicked;

            MillisecondsEntry = new Entry { Placeholder = "Millseconds" };

            ShowAlertButton = new Button { Text = "Show alert" };
            ShowAlertButton.Clicked += ShowAlertButtonClicked;

            ShowToastButton = new Button { Text = "Show toast" };
            ShowToastButton.Clicked += ShowToastButtonClicked;

            ShowErrorButton = new Button { Text = "Show error" };
            ShowErrorButton.Clicked += ShowErrorButtonClicked;

            ShowSuccessButton = new Button { Text = "Show success" };
            ShowSuccessButton.Clicked += ShowSuccessButtonClicked;

            //ShowProgressButton = new Button { Text = "Show progress" };
            //ShowProgressButton.Clicked += ShowProgressButtonClicked;

            Content = new StackLayout
            {
                Children = {
					ShowTraditionalAlertButton,
                    MillisecondsEntry,
                    ShowToastButton,
                    ShowAlertButton,
                    ShowErrorButton,
                    ShowSuccessButton,
                    //ShowProgressButton
                }
            };

        }

		async void ShowTraditionalAlertClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Traditional alert", "Traditional message", "It's not so cool");
		}

		private void ShowToastButtonClicked(object sender, EventArgs e)
        {
            int millis ;
            if (!Int32.TryParse(MillisecondsEntry.Text, out millis))
            {
                millis = 1000;
            }
            UserDialogs.Instance.Toast("Toast message: <3", TimeSpan.FromMilliseconds(millis));
        }

        private async void ShowAlertButtonClicked(object sender, EventArgs e)
        {
            await UserDialogs.Instance.AlertAsync(
               "This is the body of an alert message",
               "Alert title",
               "It's cool");
        }

        private void ShowErrorButtonClicked(object sender, EventArgs e)
        {
            int millis;
            if (!Int32.TryParse(MillisecondsEntry.Text, out millis))
            {
                millis = 1000;
            }
            UserDialogs.Instance.ShowError("¡Error!", millis);
        }

        private void ShowSuccessButtonClicked(object sender, EventArgs e)
        {
            int millis;
            if (!Int32.TryParse(MillisecondsEntry.Text, out millis))
            {
                millis = 1000;
            }
            UserDialogs.Instance.ShowSuccess("¡Éxito!", millis);
        }

        //private void ShowProgressButtonClicked(object sender, EventArgs e)
        //{
        //    var progressDialog = UserDialogs.Instance.Progress("¡Éxito!",() => 
        //    {
        //        UserDialogs.Instance.ShowError(":(");
        //    });
            
        //    progressDialog.Show();
        //}
    }
}
