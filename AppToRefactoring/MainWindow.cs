using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
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

            var assets = new List<Asset>();

            // Read all assets from every file
            foreach (var file in listOfFiles)
                switch (fileFormat)
                {
                    case "xml":
                    {
                        var parser = new XmlParser(file);
                        parser.StartParse();

                        Asset? parsedAsset;
                        while ((parsedAsset = parser.GetNextAsset()) != null) assets.Add(parsedAsset);

                        parser.EndParse();
                        break;
                    }

                    case "txt":
                    {
                        var parser = new TextParser();
                        parser.Open(file);

                        while (!parser.HasReachedEnd)
                        {
                            assets.Add(parser.GetAsset()!);
                        }

                        parser.Close();
                        break;
                    }

                    case "csv":
                        throw new NotSupportedException("Format is not supported.");
                }

            // Update list box
            ListBoxAssets.ItemsSource = assets;
        }
        catch(Exception exception)
        {
            MessageBox.Show(exception.Message, "Error");
        }
    }
}