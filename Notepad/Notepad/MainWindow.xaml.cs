using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string? currentFilePath;
    public MainWindow()
    {
        InitializeComponent();
        
    }

    private void OpenFile()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.FileName = "Document";
        dialog.DefaultExt = ".txt";
        dialog.Filter = "Text documents (.txt)|*.txt";
        var result = dialog.ShowDialog();
        if (result == true)
        {
            currentFilePath = dialog.FileName;
            TbContents.Text = File.ReadAllText(currentFilePath);
        }
    }

    private void SaveFile()
    {
        var dialog = new Microsoft.Win32.SaveFileDialog();
        dialog.FileName = "Document";
        dialog.DefaultExt = ".txt";
        dialog.Filter = "Text documents (.txt)|*.txt";
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
    private void Bold_Checked(object sender, RoutedEventArgs e)
    {
        TbContents.FontWeight = FontWeights.Bold;
    }

    private void Bold_Unchecked(object sender, RoutedEventArgs e)
    {
        TbContents.FontWeight = FontWeights.Normal;
    }

    private void Italic_Checked(object sender, RoutedEventArgs e)
    {
        TbContents.FontStyle = FontStyles.Italic;
    }

    private void Italic_Unchecked(object sender, RoutedEventArgs e)
    {
        TbContents.FontStyle = FontStyles.Normal;
    }

    private void IncreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (TbContents.FontSize < 18)
        {
            TbContents.FontSize += 2;
        }
    }

    private void DecreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (TbContents.FontSize > 10)
        {
            TbContents.FontSize -= 2;
        }
    }
}