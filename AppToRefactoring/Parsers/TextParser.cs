using System.IO;
using AppToRefactoring.Model;

namespace AppToRefactoring.Parsers;

public class TextParser
{
    private FileStream? _fileStream;
    private StreamReader? _streamReader;

    public void Open(string path)
    {
        _fileStream = File.OpenRead(path);
        _streamReader = new StreamReader(_fileStream);
    }

    public void Close()
    {
        _streamReader?.Close();
        _fileStream?.Close();
    }

    public bool HasReachedEnd
    {
        get
        {
            if (_streamReader is null)
                return true;

            return _streamReader.Peek() < 0;
        }
    }

    public Asset? GetAsset()
    {
        if (_streamReader is null)
            return null;

        return new Asset
        {
            Currency1 = _streamReader.ReadLine(),
            Currency2 = _streamReader.ReadLine(),
            Ratio = decimal.Parse(_streamReader.ReadLine() ?? "0")
        };
    }
}