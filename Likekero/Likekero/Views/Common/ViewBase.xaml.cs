using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewBase : ContentPage
    {
        public ViewBase()
        {
            InitializeComponent();
        }
    }
}