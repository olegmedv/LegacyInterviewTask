using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using AppToRefactoring.Model;

namespace AppToRefactoring.Parsers;

public class XmlParser
{
    private readonly string _path;
    private XmlReader? _xmlReader;
    private XmlSerializer? _xmlSerializer;

    public XmlParser(string path)
    {
        _path = path;
    }

    public void StartParse()
    {
        _xmlReader = XmlReader.Create(_path);
        _xmlReader.MoveToContent();
        _xmlReader.ReadToDescendant("Asset");

        _xmlSerializer = new XmlSerializer(typeof(Asset));
    }

    public void EndParse()
    {
        _xmlReader?.Close();
    }

    internal Asset? GetNextAsset()
    {
        if (_xmlReader == null)
            return null;

        return _xmlSerializer?.Deserialize(_xmlReader) as Asset;
    }
}