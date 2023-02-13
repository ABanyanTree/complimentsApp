using System;
using Likekero.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginOtp : ContentPage
    {
        private SignupViewModel viewModel;
        public LoginOtp()
        {
            InitializeComponent();
            BindingContext = viewModel = new SignupViewModel();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            //if (entry.Text.Length == 1)
            if (int.TryParse(e.NewTextValue, out _))
            {
                switch (entry.AutomationId)
                {
                    case "entry1":
                        entry2.Focus();
                        break;
                    case "entry2":
                        entry3.Focus();
                        break;
                    case "entry3":
                        entry4.Focus();
                        break;
                    case "entry4":
                        break;
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPassword());
        }
    }
}