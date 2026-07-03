using System.Threading.Tasks;
using Avalonia.Controls;
using MsBox.Avalonia;

namespace SeoulProject.Views;

public partial class MainWindow : Window
{
    public static MainWindow instance;

    public HttpService http;
    public MainWindow()
    {
        InitializeComponent();

        instance = this;

        string baseUrl = JsonConfigure.ReadJsonConfig().BaseAddress;

        http = new HttpService(baseUrl);
        
        mainControl.Content = new LoginView(http);

    }


    public async Task ErrBox(string text)
    {
        var errBox = MessageBoxManager.GetMessageBoxStandard("Ошибка!", text, MsBox.Avalonia.Enums.ButtonEnum.Ok);
        await errBox.ShowWindowDialogAsync(this);
    }
}