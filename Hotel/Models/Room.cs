using Hotel.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models;

public class Room : ViewModelBase
{
    private int _number;
    private int _roomFloorId;
    private int _roomTypeId;
    private decimal _costPerNight;

    public int Id { get; set; }

    public int Number
    {
        get { return _number; }
        set
        {
            _number = value;
            OnPropertyChanged(nameof(Number));
        }
    }

    public int RoomFloorId
    {
        get { return _roomFloorId; }
        set
        {
            _roomFloorId = value;
            OnPropertyChanged(nameof(RoomFloorId));
        }
    }
    [ForeignKey(nameof(RoomFloorId))]
    public RoomFloor RoomFloor { get; set; }

    public int RoomTypeId
    {
        get { return _roomTypeId; }
        set
        {
            _roomTypeId = value;
            OnPropertyChanged(nameof(RoomTypeId));
        }
    }
    [ForeignKey(nameof(RoomTypeId))]
    public RoomType RoomType { get; set; }

    public decimal CostPerNight
    {
        get { return _costPerNight; }
        set
        {
            _costPerNight = value;
            OnPropertyChanged(nameof(CostPerNight));
        }
    }
}
