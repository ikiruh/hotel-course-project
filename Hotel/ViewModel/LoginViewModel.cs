using Hotel.Commands;
using Hotel.DbContexts;
using Hotel.Services;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModel;

public class LoginViewModel : ViewModelBase
{
    private HotelDbContext _dbContext = new();
    private INavigationService _navigationService;
    private BaseCommand _loginCommand;

    public INavigationService NavigationService
    {

        get { return _navigationService; }
        set
        {
            _navigationService = value;
            OnPropertyChanged();
        }
    }

    public string Login { get; set; }
    public string Password { get; set; }

    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public ICommand LoginCommand
    {
        get
        {
            return _loginCommand ?? (_loginCommand = new BaseCommand(l =>
            {
                var admin = _dbContext.Admins.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();
                if (admin != null)
                {
                    Admin = admin;
                    NavigationService.NavigateTo<ListingReservationViewModel>();
                }
                else MessageBox.Show("Неправильный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }));
        }
    }
}
