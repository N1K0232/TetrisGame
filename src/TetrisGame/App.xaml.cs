using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TetrisGame.BusinessLayer.Services;
using TetrisGame.BusinessLayer.Services.Interfaces;

namespace TetrisGame;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost host;

    public App()
    {
        host = Host.CreateDefaultBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<MainWindow>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var window = host.Services.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }
}