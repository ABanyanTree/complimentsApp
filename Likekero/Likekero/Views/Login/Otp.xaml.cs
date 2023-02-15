using Likekero.Navigation;
using Likekero.ViewModels.Login;
using Likekero.Views.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Otp : ViewBase
    {
        private OTPViewModel viewModel;
        public Otp()
        {
            InitializeComponent();
            var navigationService = DependencyService.Get<INavigationService>();
            BindingContext = viewModel = new OTPViewModel(navigationService);
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
    }
}