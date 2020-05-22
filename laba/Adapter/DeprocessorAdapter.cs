using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePlugins;
using System.Reflection;
namespace Adapter
{
    public class DeprocessorAdapter:Deprocessor
    {
        public object RealDeprocessor;
        public string RealDeprocessFunctionName;
        public DeprocessorAdapter(object Adaptee, string AdapteeMethodName)
        {
            RealDeprocessor = Adaptee;
            RealDeprocessFunctionName = AdapteeMethodName;
        }
        public override string Deprocess(string FileToReadFrom)
        {
            MethodInfo method = RealDeprocessor.GetType().GetMethod(RealDeprocessFunctionName);
            return method.Invoke(RealDeprocessor, new object[] { FileToReadFrom }).ToString(); 
        }
    }
}
