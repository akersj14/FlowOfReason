using Avalonia.Controls;
using FlowOfReason.UI.ViewModels;

namespace FlowOfReason.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}