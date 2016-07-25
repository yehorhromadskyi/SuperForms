using SuperForms.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SuperForms.Samples.ViewNavigation
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        public async void NavigateToPage1(object sender, EventArgs args)
        {
            var navigationService = DependencyService.Get<IViewNavigationService>();
            await navigationService.GoBackAsync();
        }
    }
}
