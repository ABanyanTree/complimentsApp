using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Likekero.Views.Login;

namespace Likekero.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        bool isAuthenticated;
        public LoadingViewModel()
        {
            //var isAuthenticated = await this.identityService.VerifyRegistration();
            isAuthenticated = true;
        }

        private async Task Validate()
        {
            //if (isAuthenticated)
            //{
            //    await AppShell.Current.GoToAsync($"//{nameof(SignIn)}") 
            //}
            //else
            //{
            //    //await this.routingService.NavigateTo("///login");
            //}
        }
    }
}
