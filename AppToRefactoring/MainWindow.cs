using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using AppToRefactoring.Interface;
using AppToRefactoring.Model;
using AppToRefactoring.Parsers;

namespace AppToRefactoring;

public partial class MainWindow
{
    private IEnumerable<string> GetListOfFiles(string format)
    {
        return Directory.EnumerateFiles(
            GetDirPath(),
            "*." + format,
            SearchOption.TopDirectoryOnly);
    }

    private void OnLoadButtonClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var fileFormat = GetFileFormat();
            var listOfFiles = GetListOfFiles(fileFormat);
            var dataParser = GetParser(fileFormat);

            var assets = new List<Asset>();

            foreach (var file in listOfFiles)
            {               
                dataParser.Open(file);
                assets.AddRange(dataParser.ReadData());
                dataParser.Close();
            }

            // Update list box
            ListBoxAssets.ItemsSource = assets;
        }
        catch(Exception exception)
        {
            MessageBox.Show(exception.Message, "Error");
        }
    }

    private IParser GetParser(string fileFormat)
    {
        return fileFormat switch
        {
            "xml" => new XmlParser(),
            "txt" => new TextParser(),
            "csv" => new CsvParser(),
            _ => throw new ArgumentException("Unsupported file format"),
        };
    }
}