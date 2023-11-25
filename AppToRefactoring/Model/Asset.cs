namespace AppToRefactoring.Model;

public class Asset
{
    public string? Currency1 { get; set; }
    public string? Currency2 { get; set; }
    public decimal Ratio { get; set; }

    public override string ToString()
    {
        return $"{Currency1}/{Currency2}: {Ratio}";
    }
}