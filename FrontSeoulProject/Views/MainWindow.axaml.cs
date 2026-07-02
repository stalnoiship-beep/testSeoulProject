using Avalonia.Controls;

namespace SeoulProject.Views;

public partial class MainWindow : Window
{
    public static MainWindow instance;
    public MainWindow()
    {
        InitializeComponent();

        mainControl.Content = new LoginView();

        instance = this;
    }
}