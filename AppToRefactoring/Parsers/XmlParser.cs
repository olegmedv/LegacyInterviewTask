using System;
using System.Collections.Generic;
using System.Xml;
using AppToRefactoring.Interface;
using AppToRefactoring.Model;

namespace AppToRefactoring.Parsers;
public class XmlParser : IParser
{
    private XmlReader reader;

    public void Open(string path)
    {
        reader = XmlReader.Create(path);
    }

    public void Close()
    {
        reader.Close();
    }

    public List<Asset> ReadData()
    {
        List<Asset> assets = new List<Asset>();

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Asset")
            {
                reader.ReadToFollowing("Currency1");
                string currency1 = reader.ReadElementContentAsString();

                reader.ReadToFollowing("Currency2");
                string currency2 = reader.ReadElementContentAsString();

                reader.ReadToFollowing("Ratio");
                decimal ratio = Convert.ToDecimal(reader.ReadElementContentAsString());

                assets.Add(new Asset { Currency1 = currency1, Currency2 = currency2, Ratio = ratio });
            }
        }

        return assets;
    }
}