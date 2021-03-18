using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BiografAPI.Tests
{
    public class FileProcesses
    {
        public bool filenameexists(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(filename);
            }
            return File.Exists(filename);
        }
    }
}
