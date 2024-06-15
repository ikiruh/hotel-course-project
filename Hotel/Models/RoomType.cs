using Hotel.ViewModel;

namespace Hotel.Models;

public class RoomType : ViewModelBase
{
    private string _name;

    public int Id { get; set; }
    public string Name 
    { 
        get { return _name; } 
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public List<Room> RoomList { get; set; } = new();
}
