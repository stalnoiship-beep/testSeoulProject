using System;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SeoulProject.Views;

public partial class LoginView : UserControl
{
    bool userValid = false;
    bool employeeValid = false;
    bool passwordValid = false;
    HttpService http;

    public LoginView(HttpService httpService)
    {
        InitializeComponent();

        http = httpService;
    }

    private void Create_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow.instance.mainControl.Content = new CreateAccountView(http);
    }

    private void User_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string userText = tbUser.Text ?? "";

        if (string.IsNullOrEmpty(userText))
        {
            tbEmployee.IsEnabled = true;
            userValid = false;
            if(passwordValid && (userValid || employeeValid))
            {
                bLogin.IsEnabled = true;
            }
            else bLogin.IsEnabled = false;
            return;
        }

        tbEmployee.IsEnabled = false;
        userValid = true;

        if(passwordValid && (userValid || employeeValid))
            {
                bLogin.IsEnabled = true;
            }
            else bLogin.IsEnabled = false;

    }

    private void Employee_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string Employee = tbEmployee.Text ?? "";

        if (string.IsNullOrEmpty(Employee))
        {
            tbUser.IsEnabled = true;
            employeeValid = false;

            if(passwordValid && (userValid || employeeValid))
            {
                bLogin.IsEnabled = true;
            }
            else bLogin.IsEnabled = false;
            return;
        }

        tbUser.IsEnabled = false;
        employeeValid = true;

        if(passwordValid && (userValid || employeeValid))
            {
                bLogin.IsEnabled = true;
            }
            else bLogin.IsEnabled = false;

    }

    private async void bLogin_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            var response = await http.client.GetAsync("/api/login/");
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
    }

    private void Password_TextChanged(object? sender, TextChangedEventArgs e)
    {
         string pass = tbPass.Text ?? "";

        if (string.IsNullOrEmpty(pass))
        {            
            passwordValid = false;

            bLogin.IsEnabled = false;
            return;
        }
        passwordValid = true;

        if(passwordValid && (userValid || employeeValid))
        {
            bLogin.IsEnabled = true;
        }
        else bLogin.IsEnabled = false;
    }
}