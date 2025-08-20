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
        if (GetSelectedTab() == 0)
        {
            UpdateFontSize();
        }

        if (GetSelectedTab() == 1)
        {
            UpdateFontSize();
        }
    }

    private void UpdateFontSize()
    {
        FontSize.Header = GetTabFontSize();
    }
    
    public double GetTabFontSize()
    {
        if (GetSelectedTab() == 0)
        {
            return MainTextBox.FontSize;
        }

        if (GetSelectedTab() == 1)
        {
            return SecondaryTextbox.FontSize;
        }

        return -1;
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
            if (GetSelectedTab() == 0)
            {
                var fileUtils = new FileUtils();
                currentFilePath = dialog.FileName;
                MainTextBox.Text = fileUtils.OpenFile(currentFilePath);
            }

            if (GetSelectedTab() == 1)
            { 
                var fileUtils = new FileUtils();
                currentFilePath = dialog.FileName;
                SecondaryTextbox.Text = fileUtils.OpenFile(currentFilePath);
            }
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
            if (GetSelectedTab() == 0)
            {
                currentFilePath = dialog.FileName;
                var fileUtils = new FileUtils();
                fileUtils.SaveFile(currentFilePath, MainTextBox.Text);
            }

            if (GetSelectedTab() == 1)
            {
                currentFilePath = dialog.FileName;
                var fileUtils = new FileUtils();
                fileUtils.SaveFile(currentFilePath, SecondaryTextbox.Text);
            }
        }
    }

    public void OnClickSaveFile(object sender, RoutedEventArgs e)
    {
        if (currentFilePath == null)
        {
            OnClickSaveAsFile(sender, e);
            return;
        }
        if (GetSelectedTab() == 0)
        {
            var fileUtils = new FileUtils();
            fileUtils.SaveFile(currentFilePath, MainTextBox.Text);
        }

        if (GetSelectedTab() == 1)
        {
            var fileUtils = new FileUtils();
            fileUtils.SaveFile(currentFilePath, SecondaryTextbox.Text);
        }
    }
    private void Bold_Checked(object sender, RoutedEventArgs e)
    {
        if (GetSelectedTab() == 0)
        {
            MainTextBox.FontWeight = FontWeights.Bold;
        }
        if (GetSelectedTab() == 1)
        {
            SecondaryTextbox.FontWeight = FontWeights.Bold;
        }
    }

    private void Bold_Unchecked(object sender, RoutedEventArgs e)
    {
        if (GetSelectedTab() == 0)
        {
            MainTextBox.FontWeight = FontWeights.Normal;
        }

        if (GetSelectedTab() == 1)
        {
            SecondaryTextbox.FontWeight = FontWeights.Normal;
        }
    }

    private void Italic_Checked(object sender, RoutedEventArgs e)
    {
        if (GetSelectedTab() == 0)
        {
            MainTextBox.FontStyle = FontStyles.Italic;
        }

        if (GetSelectedTab() == 1)
        {
            SecondaryTextbox.FontStyle = FontStyles.Italic;
        }
    }

    private void Italic_Unchecked(object sender, RoutedEventArgs e)
    {
        if (GetSelectedTab() == 0)
        {
            MainTextBox.FontStyle = FontStyles.Normal;
        }

        if (GetSelectedTab() == 1)
        {
            SecondaryTextbox.FontWeight = FontWeights.Normal;
        }
    }

    private void IncreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (GetSelectedTab() == 0)
        {
            if (MainTextBox.FontSize < 18)
            {
                MainTextBox.FontSize += 1;
            }
            UpdateFontSize();
        }

        if (GetSelectedTab() == 1)
        {
            if (SecondaryTextbox.FontSize < 18)
            {
                SecondaryTextbox.FontSize += 1;
            }
            UpdateFontSize();
        }
    }

    private void DecreaseFont_Click(object sender, RoutedEventArgs e)
    {
        if (GetSelectedTab() == 0)
        {
            if (MainTextBox.FontSize > 10)
            {
                MainTextBox.FontSize -= 1;
            }
            UpdateFontSize();
        }

        if (GetSelectedTab() == 1)
        {
            if (MainTextBox.FontSize > 10)
            {
                MainTextBox.FontSize -= 1;
            }
            UpdateFontSize();
        }
    }

    private int GetSelectedTab()
    {
        var selectedTab = Tabs.SelectedIndex;
        return selectedTab;
    }
    //Tabs.items.add/ remove
}