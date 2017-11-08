using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderSheep.Common
{
    public static class FileUtil
    {
        public static string GetPicLocationById(string type, int id, string extension)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\pic";
            Directory.CreateDirectory(path);
            return path + "\\" + type + id + extension;
        }

        public static bool IsValidImage(string filename)
        {
            try
            {
                using (Image newImage = Image.FromFile(filename))
                { }
            }
            catch (OutOfMemoryException)
            {
                //The file does not have a valid image format.
                //-or- GDI+ does not support the pixel format of the file

                return false;
            }
            return true;
        }

    }

}    
