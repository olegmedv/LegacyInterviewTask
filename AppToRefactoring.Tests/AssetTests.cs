using AppToRefactoring.Model;
using AppToRefactoring.Parsers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace AppToRefactoring.Tests;

public class AssetTests
{
    private readonly string TestFilesDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data");

    [Fact]
    public void ProvidesCorrectDefaultValues()
    {
        var asset = new Asset();
        
        Assert.Null(asset.Currency1);
        Assert.Null(asset.Currency2);
        Assert.Equal(0m, asset.Ratio);
    }

    [Fact]
    public void TestXmlDataReader()
    {
        string xmlFilePath = Path.Combine(TestFilesDirectory, "Assets.xml");
        var dataReader = new XmlParser();
        dataReader.Open(xmlFilePath);
        List<Asset> assets = dataReader.ReadData();
        dataReader.Close();

        Assert.Equal(3, assets.Count);
        Assert.Equal("EUR", assets[0].Currency1);
        Assert.Equal("USD", assets[0].Currency2);
        Assert.Equal(1.08m, assets[0].Ratio);
    }

    [Fact]
    public void TestTxtDataReader()
    {
        string txtFilePath = Path.Combine(TestFilesDirectory, "Assets.txt");
        var dataReader = new TextParser();
        dataReader.Open(txtFilePath);
        List<Asset> assets = dataReader.ReadData();
        dataReader.Close();

        Assert.Equal(3, assets.Count);
        Assert.Equal("EUR", assets[0].Currency1);
        Assert.Equal("USD", assets[0].Currency2);
        Assert.Equal(1.13m, assets[0].Ratio);
    }

    [Fact]
    public void TestCsvDataReader()
    {
        string csvFilePath = Path.Combine(TestFilesDirectory, "Assets.csv");
        var dataReader = new CsvParser();
        dataReader.Open(csvFilePath);
        List<Asset> assets = dataReader.ReadData();
        dataReader.Close();

        Assert.Equal(3, assets.Count);
        Assert.Equal("EUR", assets[0].Currency1);
        Assert.Equal("USD", assets[0].Currency2);
        Assert.Equal(1.08m, assets[0].Ratio);
    }

}