using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandbrakeBatchConvert
{
    public class BatchConvert
    {
        public static string[] GetFileList(string filePath)
        {
            var files = Directory.GetFiles(filePath, "*.avi", SearchOption.AllDirectories);

            return files;
        }
    }
}
