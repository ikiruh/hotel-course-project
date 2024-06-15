using Hotel.DbContexts;
using Hotel.Services;
using Hotel.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Hotel;
public partial class App : Application
{
    private ServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<MainWindow>(_serviceProvider => new MainWindow
        {
            DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>()
        });
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<ListingReservationViewModel>();
        services.AddSingleton<CreateReservationViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<HotelDbContext>();
        services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _serviceProvider.GetRequiredService<MainWindow>().Show();
        base.OnStartup(e);
    }
}
