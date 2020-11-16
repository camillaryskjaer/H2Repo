using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vigenere.Managers
{
    public class SaveToFile
    {
        public void SaveToTxt(string input)
        {
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\crypto.txt", input + Environment.NewLine);
        }
    }
}
