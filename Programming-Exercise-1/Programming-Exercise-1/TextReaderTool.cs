using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Exercise_1
{
    internal static class TextReaderTool
    {
        const string exampleInput = "RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00- 21:00\n" +
                                    "ASTRID=MO10:00 - 12:00, TH12: 00 - 14:00, SU20: 00 - 21:00\n" +
                                    "ANDRES=MO10:00 - 12:00, TH12: 00 - 14:00, SU20: 00 - 21:00";
        public static string ReadTextFromFile(string fileName)
        { 
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, exampleInput);
                return exampleInput;
            }else
            { 
                string textFromFile = File.ReadAllText(fileName);
                return textFromFile;
            }
        }
    }
}
