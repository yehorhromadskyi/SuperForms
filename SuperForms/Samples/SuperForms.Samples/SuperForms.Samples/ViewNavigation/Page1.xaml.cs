using SuperForms.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SuperForms.Samples.ViewNavigation
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        public async void NavigateToPage2(object sender, EventArgs args)
        {
            var navigationService = DependencyService.Get<IViewNavigationService>();
            await navigationService.NavigateToAsync(NavigationPageSource.Page2, "hello from Page1");
        }
    }
}
