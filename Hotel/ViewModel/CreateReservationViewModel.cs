using Hotel.Commands;
using Hotel.DbContexts;
using Hotel.Models;
using Hotel.Services;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModel;

public class CreateReservationViewModel : ViewModelBase
{
    private HotelDbContext _dbContext = new();
    private INavigationService _navigationService;
    private BaseCommand _createReservationCommand;
    private BaseCommand _cancelCommand;

    public INavigationService NavigationService
    {

        get { return _navigationService; }
        set
        {
            _navigationService = value;
            OnPropertyChanged();
        }
    }

    private string _fullName;
    public string FullName
    {
        get => _fullName;
        set
        {
            _fullName = value;
            OnPropertyChanged();
        }
    }

    private string _email;
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    private string _phone;
    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged();
        }
    }

    private int _selectedRoom;
    public int SelectedRoom
    {
        get => _selectedRoom;
        set
        {
            _selectedRoom = value;
            var room = GetRoom();
            SelectedFloor = _dbContext.RoomsFloors.Where(r => r.Id == room.RoomFloorId).First();
            SelectedRoomType = _dbContext.RoomTypes.Where(t => t.Id == room.RoomTypeId).First();
            CostPerNight = room.CostPerNight;
            OnPropertyChanged();
        }
    }

    private RoomFloor _selectedFloor;
    public RoomFloor SelectedFloor
    {
        get => _selectedFloor;
        set
        {
            _selectedFloor = value;
            OnPropertyChanged();
        }
    }

    private RoomType _selectedRoomType;
    public RoomType SelectedRoomType
    {
        get => _selectedRoomType;
        set
        {
            _selectedRoomType = value;
            OnPropertyChanged();
        }
    }

    private decimal _costPerNight;
    public decimal CostPerNight
    {
        get => _costPerNight;
        set
        {
            _costPerNight = value;
            OnPropertyChanged();
        }
    }

    private DateTime _arrivalDate = new(2024,7,1);
    public DateTime ArrivalDate
    {
        get => _arrivalDate;
        set
        {
            _arrivalDate = value;
            OnPropertyChanged();
        }
    }

    private DateTime _departureDate = new(2024,7,9);
    public DateTime DepartureDate
    {
        get => _departureDate;
        set
        {
            _departureDate = value;
            OnPropertyChanged();
        }
    }

    private decimal GetTotalPrice()
    {
        var countDays = DepartureDate.Subtract(ArrivalDate).Days;
        var room = GetRoom();
        return countDays * room.CostPerNight;
    }


    public List<Room> Rooms {  get; set; }
    public List<int> Numbers { get; set; }

    public CreateReservationViewModel(INavigationService navigationService)
    {
        _dbContext.Rooms.Load();
        Rooms = _dbContext.Rooms.Local.ToList();
        Numbers = GetNumbers();
        NavigationService = navigationService;
    }

    private List<int> GetNumbers()
    {
        List<int> numbers = new();
        foreach (var room in Rooms)
        {
            numbers.Add(room.Number);
        }
        return numbers;
    }

    private Client GetClient()
    {
        var client = new Client();
        client.FullName = FullName;
        client.PhoneNumber = Phone;
        client.Email = Email;
        _dbContext.Clients.Add(client);
        _dbContext.SaveChanges();
        return client;
    }

    private Room GetRoom()
    {
        var room = _dbContext.Rooms.Where(r => r.Number == SelectedRoom).First();
        return room;
    }

    public ICommand CreateReservationCommand
    {
        get
        {
            return _createReservationCommand ?? (_createReservationCommand = new BaseCommand(c =>
            {
                var reservation = new Reservation();
                var client = GetClient();
                var room = GetRoom();
                reservation.ClientId = client.Id;
                reservation.RoomId = room.Id;
                reservation.ArrivalDate = ArrivalDate;
                reservation.DepartureDate = DepartureDate;
                reservation.TotalPrice = GetTotalPrice();
                reservation.AdmiId = Admin.Id;
                _dbContext.Reservations.Add(reservation);
                _dbContext.SaveChanges();
                MessageBox.Show("Номер успешно зарезервирован", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.NavigateTo<ListingReservationViewModel>();
            }));
        }
    }

    public ICommand CancelCommand
    {
        get
        {
            return _cancelCommand ??
                (_cancelCommand = new BaseCommand(c =>
                {
                    NavigationService.NavigateTo<ListingReservationViewModel>();
                }));
        }
    }
}
