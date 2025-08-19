using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Notepad;

public class FileUtils
{
    public void SaveFile(string filePath, string text)
    {
        File.WriteAllText(filePath, text);
    }

    public string OpenFile(string currentFilePath)
    {
        return File.ReadAllText(currentFilePath);
    }
}    