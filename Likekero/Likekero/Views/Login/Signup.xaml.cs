using Likekero.Navigation;
using Likekero.ViewModels.Login;
using Likekero.Views.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ViewBase
    {
        private SignupViewModel viewModel;

        public Signup()
        {
            InitializeComponent();
            var navigationService = DependencyService.Get<INavigationService>();
            BindingContext = viewModel = new SignupViewModel(navigationService);
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FirstName.Validate();
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.LastName.Validate();
        }
        private void EmailName_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Email.Validate();
        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Password.ValidatePassword();
        }
    }
}