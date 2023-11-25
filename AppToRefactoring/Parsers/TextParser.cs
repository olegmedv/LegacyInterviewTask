using System.Collections.Generic;
using System;
using System.IO;
using AppToRefactoring.Model;
using AppToRefactoring.Interface;
using System.Globalization;

namespace AppToRefactoring.Parsers;
public class TextParser : IParser
{
    private StreamReader reader;

    public void Open(string path)
    {
        reader = new StreamReader(path);
    }

    public void Close()
    {
        reader.Close();
    }

    public List<Asset> ReadData()
    {
        List<Asset> assets = new List<Asset>();

        while (!reader.EndOfStream)
        {
            string currency1 = reader.ReadLine();
            string currency2 = reader.ReadLine();
            decimal ratio = Convert.ToDecimal(reader.ReadLine(), CultureInfo.InvariantCulture);

            assets.Add(new Asset { Currency1 = currency1, Currency2 = currency2, Ratio = ratio });
        }

        return assets;
    }
}