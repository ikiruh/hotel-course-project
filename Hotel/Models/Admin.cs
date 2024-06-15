using Hotel.ViewModel;

namespace Hotel.Models;

public class Admin : ViewModelBase
{
    private string _login;
    private string _password;
    private string _fullName;
    
    public int Id { get; set; }
    public string Login
    {
        get { return _login; }
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }

    public string Password
    {
        get { return _password; }
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public string FullName
    {
        get { return _fullName; }
        set
        {
            _fullName = value;
            OnPropertyChanged(nameof(FullName));
        }
    }
}
