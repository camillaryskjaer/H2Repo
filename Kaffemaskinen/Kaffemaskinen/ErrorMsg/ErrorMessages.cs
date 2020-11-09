using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Kaffemaskinen.ErrorMsg
{
    public class ErrorMessages
    {
        public string Message(ErrorTypes type)
        {
            switch (type)
            {
                case ErrorTypes.Input:
                    return "Sorry i didnt understand your input";

                case ErrorTypes.WrongSize:
                    return "Wrong size";

                case ErrorTypes.TooMuchContent:
                    return "Whoops theres an overflow";
                default:
                    return "Unknown error";
            }
        }
    }
}
