using SuperToolkit.Core.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SuperForms.Core.Navigation
{
    public interface IViewNavigationService
    {
        void Initialize(INavigation navigation, SuperMapper navigationMapper);
        Task NavigateToAsync(object navigationSource, object parameter = null);
        Task GoBackAsync();
    }
}
