using Hotel.ViewModel;

namespace Hotel.Services;

public interface INavigationService
{
    public ViewModelBase CurrentView { get; }
    void NavigateTo<TViewModelBase>() where TViewModelBase : ViewModelBase;
}
