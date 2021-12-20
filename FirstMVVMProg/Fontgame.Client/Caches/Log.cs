using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fontgame.Client
{
    public static class Log
    {
       
        public static void Write(string name,string text)
        {
            string _path =Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FontGame\\Log", name);

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FontGame\\Log"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FontGame\\Log");
                File.Create(_path);
            }
            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(text);
            }
            

        }

    }
}
