using System;
using System.Collections.Generic;
using System.Text;

namespace HelpJakob
{
    // class to send message
    class Send
    {
        ConvertHtml convert = new ConvertHtml();
        public void sendMessage(MessageCarrier type, Message m, bool isHTML)
        {
            if (isHTML)
            {
                m.Body = convert.ConvertBodyToHTML(m.Body);
            }

            //herinde sendes der en email ud til modtageren
            if (type.Equals(MessageCarrier.Smtp))
            {
                //her implementeres alt koden til at sende via Smtp
            }

            if (type.Equals(MessageCarrier.VMessage))
            {
                //her implementeres alt koden til at sende via VMessage
            }
        }
        public void sendMessageToAll(MessageCarrier type, string[] to, Message m, bool isHTML)
        {
            if (isHTML)
            {
                m.Body = convert.ConvertBodyToHTML(m.Body);
            }
            if (type.Equals(MessageCarrier.Smtp))
            {
                //her implementeres alt koden til at sende via Smtp
            }

            if (type.Equals(MessageCarrier.VMessage))
            {
                //her implementeres alt koden til at sende via VMessage
            }
        }
    }
}
