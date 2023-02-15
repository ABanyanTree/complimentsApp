using Likekero.Navigation;
using Likekero.Services;
using Likekero.ViewModels.Login;
using Likekero.Views;
using Likekero.Views.Login;
using Xamarin.Forms;

namespace Likekero
{
    public partial class App : Application
    {
        public static INavigationService NavigationService { get; private set; }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<INavigationService, NavigationService>();

            var isLogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            if (isLogged == "1")
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new NavigationPage(new SignIn());
            }

            //ConfigureNavigation();
            //MainPage = new NavigationPage(new SignIn());
        }

        private static void ConfigureNavigation()
        {
            var navigationService = DependencyService.Get<INavigationService>();

            //navigationService.Initialize();
            navigationService.Configure(typeof(SigninViewModel), typeof(SignIn));
            navigationService.Configure(typeof(SignupViewModel), typeof(Signup));
            navigationService.Configure(typeof(OTPViewModel), typeof(Otp));
            navigationService.Configure(typeof(ResetPasswordViewModel), typeof(ResetPassword));
            navigationService.Configure(typeof(ForgotPasswordViewModel), typeof(ForgotPassword));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
