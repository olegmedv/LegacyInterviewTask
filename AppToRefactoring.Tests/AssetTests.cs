using AppToRefactoring.Model;
using Xunit;

namespace AppToRefactoring.Tests;

public class AssetTests
{
    [Fact]
    public void ProvidesCorrectDefaultValues()
    {
        var asset = new Asset();
        
        Assert.Null(asset.Currency1);
        Assert.Null(asset.Currency2);
        Assert.Equal(0m, asset.Ratio);
    }
}