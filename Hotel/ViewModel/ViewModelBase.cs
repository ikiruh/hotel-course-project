using Hotel.Core;
using Hotel.Models;

namespace Hotel.ViewModel;

public class ViewModelBase : ObservableObject
{
    public static Admin Admin { get; set; }
    public static Reservation Reservation { get; set; }
    public static Room Room { get; set; }
    public static Client Client { get; set; }
}
