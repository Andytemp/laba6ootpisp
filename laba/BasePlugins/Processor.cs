using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BasePlugins
{
    public abstract class Processor
    {
        public abstract void Process(string value, string FileToWrite);
    }
}
