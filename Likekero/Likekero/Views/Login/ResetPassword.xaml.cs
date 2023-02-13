using Likekero.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword : ContentPage
    {
        private SignupViewModel viewModel;
        public ResetPassword()
        {
            InitializeComponent();
            BindingContext = viewModel = new SignupViewModel();
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Email.Validate();
            viewModel.Password.Validate();
        }
    }
}