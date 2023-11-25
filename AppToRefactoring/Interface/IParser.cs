using AppToRefactoring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppToRefactoring.Interface
{
    interface IParser
    {
        void Open(string path);
        void Close();
        List<Asset> ReadData();
    }
}
