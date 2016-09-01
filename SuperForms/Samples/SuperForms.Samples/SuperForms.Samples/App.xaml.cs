using SuperForms.Core.Navigation;
using SuperForms.Samples.ViewNavigation;
using SuperToolkit.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SuperForms.Samples
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MultiComponentLabelPage

            //MainPage = new NavigationPage(new CustomToolbarPage());

            //MainPage = new SuperListViewPage();

            //ViewNavigation sample
            //var startPage = new Page1();
            //InitializeNavigation(startPage);
            //MainPage = new NavigationPage(startPage);

            MainPage = new BorderPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #region Sample of navigation initialization
        private void InitializeNavigation(Page startPage)
        {
            var mapper = new SuperMapper();
            mapper.AddMapping(typeof(Page1), NavigationPageSource.Page1);
            mapper.AddMapping(typeof(Page2), NavigationPageSource.Page2);

            var navigationService = DependencyService.Get<IViewNavigationService>();
            navigationService.Initialize(startPage.Navigation, mapper);
        }
        #endregion
    }
}
