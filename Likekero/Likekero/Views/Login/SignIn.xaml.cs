using System;
using Likekero.Navigation;
using Likekero.ViewModels.Login;
using Likekero.Views.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ViewBase
    {
        private SigninViewModel viewModel;
        public SignIn()
        {
            InitializeComponent();
            var navigationService = DependencyService.Get<INavigationService>();
            BindingContext = viewModel = new SigninViewModel(navigationService);
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Email.Validate();
            viewModel.Password.ValidatePassword();
        }
    }
}