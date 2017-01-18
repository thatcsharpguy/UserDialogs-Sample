using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Dialogs
{
    public class PromptsPage : ContentPage
    {
		Button ShowTraditionalPromptButton;
        Button PromptDateButton;
        Button PromptTimeButton;
        Button PromptLoginButton;
        Button PromptButton;
		Label TraditionalPromptLabel;
		Label SelectedDateLabel;
        Label SelectedTimeLabel;
		Label PromptedTextLabel;
		Label PromptedLoginLabel;

        public PromptsPage()
        {
			ShowTraditionalPromptButton = new Button { Text = "Show traditional prompt" };
			ShowTraditionalPromptButton.Clicked += ShowTraditionalPromptClicked;

            PromptDateButton = new Button { Text = "Select date" };
            PromptDateButton.Clicked += PromptDateButtonClicked; 

            PromptTimeButton = new Button { Text = "Select time" };
            PromptTimeButton.Clicked += PromptTimeButtonClicked; 

            PromptButton = new Button { Text = "Prompt" };
            PromptButton.Clicked += PromptButtonClicked; ;

			PromptLoginButton = new Button { Text = "Show login prompt" };
			PromptLoginButton.Clicked += PromptLoginButtonClicked;

            SelectedDateLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center
            };
            SelectedDateLabel.Text = "No date";

            SelectedTimeLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center
            };
            SelectedTimeLabel.Text = "No time";

            PromptedTextLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center
            };
            PromptedTextLabel.Text = "--";

			PromptedLoginLabel = new Label
			{
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalTextAlignment = TextAlignment.Center
			};
			PromptedLoginLabel.Text = "--";

			TraditionalPromptLabel= new Label
			{
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalTextAlignment = TextAlignment.Center
			};
			TraditionalPromptLabel.Text = "--";

            Content = new StackLayout
            {
                Children = {
					ShowTraditionalPromptButton,
					TraditionalPromptLabel,
                    PromptButton,
                    PromptedTextLabel,
                    PromptDateButton,
                    SelectedDateLabel,
                    PromptTimeButton,
                    SelectedTimeLabel,
					PromptLoginButton, 
					PromptedLoginLabel
                }
            };

        }

		async void ShowTraditionalPromptClicked(object sender, EventArgs e)
		{
			var result = await DisplayAlert("Traditional alert", "Traditional message?", "OK", "Cancel");
			TraditionalPromptLabel.Text = string.Format("Result {0}", result);
		}

        private async void PromptButtonClicked(object sender, EventArgs e)
        {
            var promptConfig = new PromptConfig();
			promptConfig.InputType = InputType.Name;
            promptConfig.IsCancellable = true;
            promptConfig.Message = "Write your name";
            var result = await UserDialogs.Instance.PromptAsync(promptConfig);
            if (result.Ok)
            {
                PromptedTextLabel.Text = result.Text;
            }
            else
            {
                PromptedTextLabel.Text = ":(";
            }
        }

        private async void PromptDateButtonClicked(object sender, EventArgs e)
        {
            var result = await UserDialogs.Instance.DatePromptAsync(
                "Select date",
                DateTime.Now);
            if (result.Ok)
                SelectedDateLabel.Text = String.Format("{0:dd MMMM yyyy}", result.SelectedDate);
            else
                SelectedDateLabel.Text = "No date";
        }

        private async void PromptTimeButtonClicked(object sender, EventArgs e)
        {
            var result = await UserDialogs.Instance.TimePromptAsync(
                "Select time",
                DateTime.Now.TimeOfDay);
            if (result.Ok)
                SelectedTimeLabel.Text = String.Format("{0:hh-mm}", new DateTime(result.SelectedTime.Ticks));
            else
                SelectedTimeLabel.Text = "No date";
        }

		async void PromptLoginButtonClicked(object sender, EventArgs e)
		{
			var loginResult = await UserDialogs.Instance.LoginAsync("Login", "Please sign in");
			if (loginResult.Ok)
			{
				PromptedLoginLabel.Text = String.Format("{0}:{1}", loginResult.Value.UserName, loginResult.Value.Password);
			}
			else 
			{
				PromptedLoginLabel.Text = "No login";
			}
		}
	}
}
