using System;
using BasePlugins;
using System.IO;
using System.IO.Compression;
namespace ZipDeprocessor
{
    public class Dearchiver:Deprocessor
    {
        public override string Deprocess(string FileToReadFrom)
        {
            ZipFile.ExtractToDirectory(FileToReadFrom, Path.GetDirectoryName(FileToReadFrom));
            string jsonstring = File.ReadAllText(Path.GetDirectoryName(FileToReadFrom)+"\\"+Path.GetFileNameWithoutExtension(FileToReadFrom)+".txt");
            File.Delete(Path.GetDirectoryName(FileToReadFrom) + "\\" + Path.GetFileNameWithoutExtension(FileToReadFrom) + ".txt");
            return jsonstring;
        }
    }
}
