using Hotel.Services;

namespace Hotel.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    private INavigationService _navigationService;

    public INavigationService NavigationService
    {
        get { return _navigationService; }
        set
        {
            _navigationService = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.NavigateTo<LoginViewModel>();
    }
}
