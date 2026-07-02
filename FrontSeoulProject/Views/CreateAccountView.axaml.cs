using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SeoulProject.Views;

public partial class CreateAccountView : UserControl
{
    public CreateAccountView()
    {
        InitializeComponent();
    }

    private void Register_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow.instance.mainControl.Content = new ManagmentView();
    }
}