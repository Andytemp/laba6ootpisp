using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasePlugins;
using System.IO;
namespace laba
{
    class ProcessorStub:Processor
    {
        public override void Process(string value, string FileToWrite)
        {
            File.WriteAllText(FileToWrite, value);
        }
    }
}
