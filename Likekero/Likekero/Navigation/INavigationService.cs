using System;
using System.Threading.Tasks;

namespace Likekero.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync(Type viewModelType);
        Task NavigateBackAsync();
        void Configure(Type type1, Type type2);
        void Initialize();
    }
}
