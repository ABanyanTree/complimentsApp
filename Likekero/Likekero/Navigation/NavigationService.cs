using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Likekero.ViewModels;
using Xamarin.Forms;

namespace Likekero.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _viewModelRouting = new Dictionary<Type, Type>();
        private INavigation _navigation;
        

        public void Configure(Type viewModelType, Type viewType)
        {
            _viewModelRouting[viewModelType] = viewType;
        }

        public void Initialize()
        {
            //_navigation = Application.Current.MainPage.Navigation;
        }

        public async Task NavigateToAsync(Type viewModelType)
        {
            Type viewType;
            if (!_viewModelRouting.TryGetValue(viewModelType, out viewType))
            {
                throw new ArgumentException($"No view found for ${viewModelType}");
            }

            Page page = Activator.CreateInstance(viewType) as Page;
            if (page == null)
            {
                throw new ArgumentException($"Invalid view type ${viewType}");
            }
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task NavigateBackAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
