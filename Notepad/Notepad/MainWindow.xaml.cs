using System.Globalization;
using System.IO;
using System.Windows;

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
        UpdateFontSize();
    }

    private void UpdateFontSize()
    {
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
            currentFilePath = dialog.FileName;
            MainTextBox.Text = fileUtils.OpenFile(currentFilePath);
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
            currentFilePath = dialog.FileName;
            var fileUtils = new FileUtils();
            fileUtils.SaveFile(currentFilePath, MainTextBox.Text);
        }
    }

    public void OnClickSaveFile(object sender, RoutedEventArgs e)
    {
        if (currentFilePath == null)
        {
            OnClickSaveAsFile(sender, e);
            return;
        }
        
        var fileUtils = new FileUtils();
        fileUtils.SaveFile(currentFilePath, MainTextBox.Text);
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
        UpdateFontSize();
    }

    private void DecreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (MainTextBox.FontSize > 10)
        {
            MainTextBox.FontSize -= 1;
        }
        UpdateFontSize();
    }
}