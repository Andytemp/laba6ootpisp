using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BasePlugins;
namespace Adapter
{
    public class ProcessorAdapter:Processor
    {
        public object RealProcessor;
        public string RealProcessFunctionName;
        public ProcessorAdapter(object Adaptee,string AdapteeMethodName)
        {
            RealProcessor = Adaptee;
            RealProcessFunctionName = AdapteeMethodName;
        }
        public override void Process(string value, string FileToWrite)
        {
            MethodInfo method = RealProcessor.GetType().GetMethod(RealProcessFunctionName);
            method.Invoke(RealProcessor, new object[] { value,FileToWrite }); 
        }
    }
}
