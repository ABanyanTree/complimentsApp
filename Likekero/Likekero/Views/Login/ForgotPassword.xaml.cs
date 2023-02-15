using Likekero.Navigation;
using Likekero.ViewModels.Login;
using Likekero.Views.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ViewBase
    {
        private ForgotPasswordViewModel viewModel;
        public ForgotPassword()
        {
            InitializeComponent();
            var navigationService = DependencyService.Get<INavigationService>();
            BindingContext = viewModel = new ForgotPasswordViewModel(navigationService);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Email.Validate();
        }
    }
}