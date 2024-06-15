using Hotel.Core;
using Hotel.ViewModel;

namespace Hotel.Services;

public class NavigationService : ObservableObject, INavigationService
{
    private ViewModelBase _currentView;
    private readonly Func<Type, ViewModelBase> _viewModelFactory;

    public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public ViewModelBase CurrentView
    {
        get { return _currentView; }
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public void NavigateTo<TViewModelBase>() where TViewModelBase : ViewModelBase
    {
        ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(TViewModelBase));
        CurrentView = viewModel;
    }
}
