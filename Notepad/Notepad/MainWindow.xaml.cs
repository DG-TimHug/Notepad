//hi :)
using System.Windows;
using System.Windows.Controls;

namespace Notepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow 
{
    private string? currentFilePath;
    
    public MainWindow()
    {
        InitializeComponent();
        Tabs.SelectionChanged += TabsChanged;
        UpdateFontSize();
    }

    private void TabsChanged(object sender, RoutedEventArgs e)
    {
        GetCurrentTextBox();
        UpdateFontSize();
    }

    private void UpdateFontSize()
    {
        FontSize.Header = GetTabFontSize();
    }

    private double GetTabFontSize()
    {
        return GetCurrentTextBox().FontSize;
    }

    private TextBox GetCurrentTextBox()
    {
        if (GetSelectedTab() == 0)
        {
            return MainTextBox;
        }

        else //(GetSelectedTab() == 1)
        {
            return SecondaryTextbox;
        }
    }

    private void OnClickOpenFile(object sender, RoutedEventArgs e)
    {
        var dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.FileName = "Document";
        dialog.DefaultExt = ".txt";
        dialog.Filter = "Text documents (.txt)|*.txt";
        var result = dialog.ShowDialog();
        
        if (result == true)
        {
            var fileUtils = new FileUtils();
            currentFilePath = dialog.FileName;
            GetCurrentTextBox().Text = fileUtils.OpenFile(currentFilePath);
        }
    }

    private void OnClickSaveAsFile(object sender, RoutedEventArgs e)
    {
        var dialog = new Microsoft.Win32.SaveFileDialog
        {
            FileName = "Document",
            DefaultExt = ".txt",
            Filter = "Text documents (.txt)|*.txt"
        };
        var result = dialog.ShowDialog();
        if (result == true)
        {
            
            currentFilePath = dialog.FileName;
            var fileUtils = new FileUtils();
            fileUtils.SaveFile(currentFilePath, GetCurrentTextBox().Text);
        }
    }

    private void OnClickSaveFile(object sender, RoutedEventArgs e)
    {
        if (currentFilePath == null)
        {
            OnClickSaveAsFile(sender, e);
            return;
        }
        var fileUtils = new FileUtils();
        fileUtils.SaveFile(currentFilePath, GetCurrentTextBox().Text);
    }
    private void Bold_Checked(object sender, RoutedEventArgs e)
    {
        GetCurrentTextBox().FontWeight = FontWeights.Bold;
    }

    private void Bold_Unchecked(object sender, RoutedEventArgs e)
    {
        GetCurrentTextBox().FontWeight = FontWeights.Normal;
    }

    private void Italic_Checked(object sender, RoutedEventArgs e)
    {
        GetCurrentTextBox().FontStyle = FontStyles.Italic;
    }

    private void Italic_Unchecked(object sender, RoutedEventArgs e)
    {
        GetCurrentTextBox().FontWeight = FontWeights.Normal;
    }

    private void IncreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (GetCurrentTextBox().FontSize < 18)
        { 
            GetCurrentTextBox().FontSize += 1;
        }
        UpdateFontSize();
    }

    private void DecreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (GetCurrentTextBox().FontSize> 10)
        { 
            GetCurrentTextBox().FontSize-= 1;
        }
        UpdateFontSize();
    }

    private int GetSelectedTab()
    {
        var selectedTab = Tabs.SelectedIndex;
        Console.WriteLine(selectedTab);
        return selectedTab;
    }
    //Tabs.items.add/ remove
}