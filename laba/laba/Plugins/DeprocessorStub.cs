using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasePlugins;
using System.IO;
namespace laba
{
    class DeprocessorStub:Deprocessor
    {
        override public string Deprocess(string FileToReadFrom)
        {
            return File.ReadAllText(FileToReadFrom);
        }
    }
}
