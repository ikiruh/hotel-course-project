using Hotel.Commands;
using Hotel.DbContexts;
using Hotel.Models;
using Hotel.Services;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace Hotel.ViewModel;

public class ListingReservationViewModel : ViewModelBase
{
    private HotelDbContext _dbContext = new();
    private INavigationService _navigationService;
    private BaseCommand _createReservationCommand;

    public Admin Admin { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Client> Clients { get; set; }
    public List<Admin> Admins { get; set; }
    public List<Room> Rooms { get; set; }


    public INavigationService NavigationService
    {

        get { return _navigationService; }
        set
        {
            _navigationService = value;
            OnPropertyChanged();
        }
    }

    public ICommand CreateReservationCommand
    {
        get
        {
            return _createReservationCommand ?? (_createReservationCommand = new BaseCommand(c =>
            {
                NavigationService.NavigateTo<CreateReservationViewModel>();
            }
            ));
        }
    }

    public ListingReservationViewModel(INavigationService navigationService)
    {
        this.Admin = ViewModelBase.Admin;
        _dbContext.Reservations.Load();
        _dbContext.Clients.Load();
        _dbContext.Admins.Load();
        _dbContext.Rooms.Load();
        Reservations = _dbContext.Reservations.Local.ToList();
        Clients = _dbContext.Clients.Local.ToList();
        Admins = _dbContext.Admins.Local.ToList();
        Rooms = _dbContext.Rooms.Local.ToList();
        _navigationService = navigationService;
    }
}
