using System.Globalization;
using System.IO;
using System.Windows;

namespace Notepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow 
{
    public string? CurrentFilePath;
    
    public MainWindow()
    {
        InitializeComponent();

        FontSize.Header = GetFontSize();
    }

    public double GetFontSize()
    {
        return (double) MainTextBox.FontSize;
    }
    
    public void OnClickOpenFile(object sender, RoutedEventArgs e)
    {        
        var dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.FileName = "Document";
        dialog.DefaultExt = ".txt";
        dialog.Filter = "Text documents (.txt)|*.txt";
        var result = dialog.ShowDialog();
        
        if (result == true)
        {
            var fileUtils = new FileUtils();
            CurrentFilePath = dialog.FileName;
            MainTextBox.Text = fileUtils.OpenFile(CurrentFilePath);
        }
    }

    public void OnClickSaveAsFile(object sender, RoutedEventArgs e)
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
            CurrentFilePath = dialog.FileName;
            var fileUtils = new FileUtils();
            fileUtils.SaveFile(CurrentFilePath, MainTextBox.Text);
        }
    }

    public void OnClickSaveFile(object sender, RoutedEventArgs e)
    {
        if (CurrentFilePath == null)
        {
            OnClickSaveAsFile(sender, e);
            return;
        }
        
        var fileUtils = new FileUtils();
        fileUtils.SaveFile(CurrentFilePath, MainTextBox.Text);
    }
    private void Bold_Checked(object sender, RoutedEventArgs e)
    {
        MainTextBox.FontWeight = FontWeights.Bold;
    }

    private void Bold_Unchecked(object sender, RoutedEventArgs e)
    {
        MainTextBox.FontWeight = FontWeights.Normal;
    }

    private void Italic_Checked(object sender, RoutedEventArgs e)
    {
        MainTextBox.FontStyle = FontStyles.Italic;
    }

    private void Italic_Unchecked(object sender, RoutedEventArgs e)
    {
        MainTextBox.FontStyle = FontStyles.Normal;
    }

    private void IncreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (MainTextBox.FontSize < 18)
        {
            MainTextBox.FontSize += 1;
        }
        FontSize.Header = GetFontSize();
    }

    private void DecreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (MainTextBox.FontSize > 10)
        {
            MainTextBox.FontSize -= 1;
        }
        FontSize.Header = GetFontSize();
    }
}