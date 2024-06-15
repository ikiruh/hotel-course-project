using Hotel.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models;

public class Reservation : ViewModelBase
{
    private int _clientId;
    private int _roomId;
    private DateTime _arrivalDate;
    private DateTime _departureDate;
    private decimal _totalPrice;
    private int _adminId;

    public int Id { get; set; }

    public int ClientId
    {
        get { return _clientId; }
        set
        {
            _clientId = value;
            OnPropertyChanged(nameof(ClientId));
        }
    }
    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }

    public int RoomId
    {
        get { return _roomId; }
        set
        {
            _roomId = value;
            OnPropertyChanged(nameof(RoomId));
        }
    }
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }

    public DateTime ArrivalDate
    {
        get { return _arrivalDate; }
        set
        {
            _arrivalDate = value;
            OnPropertyChanged(nameof(ArrivalDate));
        }
    }

    public DateTime DepartureDate
    {
        get { return _departureDate; }
        set
        {
            _departureDate = value;
            OnPropertyChanged(nameof(DepartureDate));
        }
    }

    public decimal TotalPrice
    {
        get { return _totalPrice; }
        set
        {
            _totalPrice = value;
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    public int AdmiId
    {
        get { return _adminId; }
        set
        {
            _adminId = value;
            OnPropertyChanged(nameof(AdmiId));
        }
    }
    [ForeignKey(nameof(AdmiId))]
    public Admin Admin { get; set; }
}
