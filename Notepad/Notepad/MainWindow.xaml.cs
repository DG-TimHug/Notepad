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
            var filename = dialog.FileName;
            TbContents.Text = File.ReadAllText(filename);
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
            var filename = dialog.FileName;
            File.WriteAllText(filename, TbContents.Text );
        }
    }
    private void OnClickOpenFile(object sender, RoutedEventArgs e)
    {
        OpenFile();
    }

    private void OnClickSaveFile(object sender, RoutedEventArgs e)
    {
        SaveFile();
    }
}