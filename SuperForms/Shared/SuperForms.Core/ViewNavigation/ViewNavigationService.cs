using SuperForms.Core.Navigation;
using SuperForms.Core.ViewNavigation;
using SuperToolkit.Core.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ViewNavigationService))]
namespace SuperForms.Core.ViewNavigation
{
    public class ViewNavigationService : IViewNavigationService
    {
        private INavigation _navigation;
        private SuperMapper _navigationMapper;

        public void Initialize(INavigation navigation, SuperMapper navigationMapper)
        {
            _navigation = navigation;
            _navigationMapper = navigationMapper;
        }

        public async Task NavigateToAsync(object navigationSource)
        {
            CheckIsInitialized();

            var pageType = _navigationMapper.GetTypeSource(navigationSource);
            var pageInstance = (Page)Activator.CreateInstance(pageType);

            await _navigation.PushAsync(pageInstance);
        }

        public async Task GoBackAsync()
        {
            CheckIsInitialized();

            await _navigation.PopAsync();
        }

        private void CheckIsInitialized()
        {
            if (_navigation == null || _navigationMapper == null)
                throw new NullReferenceException("Call Initialize method first.");
        }
    }
}
