using System;
using System.Collections.Generic;
using System.Text;

namespace Vigenere.Managers
{
    interface IData
    {
        void SaveData(string Input);
        string LoadData(string Input);
    }
}
