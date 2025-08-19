using System.IO;
using System.Windows;
namespace Notepad;

public partial class MainWindow : Window
{
    private string? currentFilePath;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenFile()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog
        {
            FileName = "Document",
            DefaultExt = ".txt",
            Filter = "Text documents (.txt)|*.txt"
        };
        var result = dialog.ShowDialog();
        if (result == true)
        {
            currentFilePath = dialog.FileName;
            TbContents.Text = File.ReadAllText(currentFilePath);
        }
    }

    private void SaveAsFile()
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
            File.WriteAllText(currentFilePath, TbContents.Text );
        }
    }
    private void OnClickOpenFile(object sender, RoutedEventArgs e)
    {
        OpenFile();
    }

    private void OnClickSaveAsFile(object sender, RoutedEventArgs e)
    {
        SaveAsFile();
    }

    private void OnClickSaveFile(object sender, RoutedEventArgs e)
    {
        if (currentFilePath != null)
        {
            File.WriteAllText(currentFilePath, TbContents.Text );
        }
        else
        {
            SaveAsFile();
        }
    }
}