using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Dialogs
{
    public class App : Application
    {
        public App()
        {
            var page = new TabbedPage();
            page.Children.Add(new DialogsPage() { Title = "Dialogs" });
            page.Children.Add(new PromptsPage() { Title = "Prompts" });
			page.Title = page.CurrentPage.Title;
			page.CurrentPageChanged += (sender, e) => { page.Title = page.CurrentPage.Title; };

			MainPage = new NavigationPage(page);
            
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
