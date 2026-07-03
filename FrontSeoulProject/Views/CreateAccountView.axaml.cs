using System;
using System.Net.Http.Json;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SeoulProject.Views;

public partial class CreateAccountView : UserControl
{
     HttpService http;

    public CreateAccountView( HttpService httpService)
    {
        InitializeComponent();

        http = httpService;
    }

    private async void Register_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
      
        Registration registration = new Registration
        {
            name = tbUserName.Text, password = tbPassword.Text, 
            fullname = tbFullName.Text, familycount = (int)(familyCount.Value ?? 0), 
            birthday = DateBirtn.SelectedDate?.DateTime ?? DateTime.MinValue, gender = (rbMale.IsChecked ?? false) ? "male" : "female"
        };
         try
        {
            var response = await http.client.PostAsJsonAsync("/seoul/v1/register/", registration);
            string Content = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode)
            {
                MainWindow.instance.ErrBox("Статус код: " + response.StatusCode);

            }
            else
            {
                var result = JsonSerializer.Deserialize<LoginClass>(Content);
                if((result != null) && (!string.IsNullOrEmpty(result.token)))
                {
                    http.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.token);

                    MainWindow.instance.mainControl.Content = new ManagmentView();
                }
            }
        }
        catch(Exception ex)
        {
            MainWindow.instance.ErrBox(ex.ToString());
        }
        
        //MainWindow.instance.mainControl.Content = new ManagmentView();
    }
}