using System.Threading.Tasks;

namespace SuperForms.Core.Navigation
{
    public interface IViewModelNavigationService
    {
        Task PopAsync();
        Task PopModalAsync();
        Task PushAsync(BaseViewModel viewModel);
        Task PushModalAsync(BaseViewModel viewModel);
        Task PopToRootAsync();
    }
}
