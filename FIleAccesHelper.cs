using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glopezS5A
{
    public class FIleAccesHelper
    {
        public static string GetLocalFolderPath(string filename) 
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
