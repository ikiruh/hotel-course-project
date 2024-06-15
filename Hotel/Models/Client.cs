using Hotel.ViewModel;

namespace Hotel.Models;

public class Client : ViewModelBase
{
    private string _fullName;
    private string _phoneNumber;
    private string _email;

    public int Id { get; set; }

    public string FullName
    {
        get { return _fullName; }
        set
        {
            _fullName = value; 
            OnPropertyChanged(nameof(FullName));
        }
    }

    public string PhoneNumber
    {
        get { return _phoneNumber; }
        set
        {
            _phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }

    public string Email
    {
        get { return _email; }
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }
}
