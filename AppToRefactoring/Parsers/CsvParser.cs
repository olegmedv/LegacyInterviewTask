using AppToRefactoring.Interface;
using AppToRefactoring.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppToRefactoring.Parsers
{
    public class CsvParser : IParser
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

            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine().Split(';');
                string currency1 = values[0];
                string currency2 = values[1];
                decimal ratio = Convert.ToDecimal(values[2], CultureInfo.InvariantCulture);

                assets.Add(new Asset { Currency1 = currency1, Currency2 = currency2, Ratio = ratio });
            }

            return assets;
        }
    }
}
