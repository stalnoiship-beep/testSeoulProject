using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SeoulProject.Views;

public partial class ManagmentView : UserControl
{
    public List<myTable> myTables;
    public ManagmentView()
    {
        InitializeComponent();

        myTables = new List<myTable>()
        {
            new myTable{title="White Swan", capacity=4, area="Seocho-gu", type="Private room"},
             new myTable{title="White Swan", capacity=4, area="Seocho-gu", type="Private room"},
              new myTable{title="White Swan", capacity=4, area="Seocho-gu", type="Private room"}
        };

        DGtrav.ItemsSource = myTables;
        DGman.ItemsSource = myTables;
    }
}

public class myTable
{
    public string title{get;set;}
    public int capacity{get;set;}
    public string area{get;set;}
    public string type{get;set;}

}