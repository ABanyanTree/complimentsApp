using Likekero.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Likekero.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}