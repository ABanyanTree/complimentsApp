using Likekero.Navigation;
using Likekero.ViewModels.Login;
using Likekero.Views.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword : ViewBase
    {
        private ResetPasswordViewModel viewModel;
        public ResetPassword()
        {
            InitializeComponent();
            var navigationService = DependencyService.Get<INavigationService>();
            BindingContext = viewModel = new ResetPasswordViewModel(navigationService);
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.NewPassword.ValidatePassword();
            viewModel.ConfirmPassword.ValidatePassword();
        }
    }
}