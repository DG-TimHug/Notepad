using System.IO;
using System.Windows;
namespace Notepad;

public partial class MainWindow : Window
{
    private string? filename;
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
            filename = dialog.FileName;
            TbContents.Text = File.ReadAllText(filename);
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
            filename = dialog.FileName;
            File.WriteAllText(filename, TbContents.Text );
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
        
        if (filename != null)
        {
            File.WriteAllText(filename, TbContents.Text );
        }
        else
        {
            SaveAsFile();
        }
        
    }
}