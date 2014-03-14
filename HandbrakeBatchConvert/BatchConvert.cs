﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandbrakeBatchConvert
{
    public static class BatchConvert
    {
        public static string[] GetFileList(string filePath)
        {
            string[] files = null;

            if (Directory.Exists(filePath))
            {
                files = Directory.GetFiles(filePath, "*.avi", SearchOption.AllDirectories);
            }

            return files;
        }

        /// <summary>
        /// Builds a command line instruction to convert a video file using handbrake cli
        /// </summary>
        /// <param name="inputPath">The source file to be converted</param>
        /// <param name="outputPath">The output file to be saved</param>
        /// <param name="query">Either a preset conversion type or a custom query</param>
        /// <param name="custom">Indicates if the query is custom or a preset</param>
        /// <returns></returns>
        public static string BuildCLICommand(string inputPath, string outputPath, string query, bool custom)
        {
            //TODO: Set outputpath using textdestination and filepath filename and extension
            var fileInfo = new FileInfo(inputPath);
            outputPath = string.Format(outputPath, Path.GetFileNameWithoutExtension(fileInfo.Name));

            var command = "-i \"{0}\" -o \"{1}\" {2}";
            command = string.Format(command, inputPath, outputPath, custom ? query : "--preset=\"" + query + "\"");

            return command;
        }
    }
}
