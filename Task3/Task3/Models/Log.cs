using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Task3.Models
{
    public static class Log
    {
        public static void Write(string text)
    
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt";
            if (System.IO.File.ReadAllLines(path).Length > 200)
                File.WriteAllText(path, "");
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(text + "\n");
            }
        }
       
    }
}
