using System.Windows;
using TetrisGame.BusinessLayer.Services.Interfaces;

namespace TetrisGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IGameService gameService;

    public MainWindow(IGameService gameService)
    {
        this.gameService = gameService;
        InitializeComponent();
    }
}