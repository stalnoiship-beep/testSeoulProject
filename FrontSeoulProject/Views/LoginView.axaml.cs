using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SeoulProject.Views;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void Create_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow.instance.mainControl.Content = new CreateAccountView();
    }
}