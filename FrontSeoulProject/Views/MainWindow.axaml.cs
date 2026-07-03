using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
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

    // Кнопка выбор файла
    public async Task SelectFileMethod()
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if(topLevel == null ) return;

        var options = new FilePickerOpenOptions
        {
            Title= "Выберите файл",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("Название"){Patterns = new[]{"*.*"}}  
            }
        };

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(options);

    }
}