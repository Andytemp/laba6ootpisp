using System;
using BasePlugins;
using System.IO;
using System.IO.Compression;
namespace ZipProcessor
{
    public class Archiver:Processor
    {
        public override void Process(string value, string FileToWrite)
        {
            File.WriteAllText(FileToWrite, value);
            
            using (FileStream fs = new FileStream(Path.GetDirectoryName(FileToWrite)+"\\"+Path.GetFileNameWithoutExtension(FileToWrite)+".zip", FileMode.Create))
            using (ZipArchive arch = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                arch.CreateEntryFromFile(FileToWrite, Path.GetFileName(FileToWrite));
            }
            File.Delete(FileToWrite);
        }
    }
}
