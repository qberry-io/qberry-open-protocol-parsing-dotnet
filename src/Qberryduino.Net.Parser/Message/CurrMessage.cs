using System;
using System.Collections.Generic;
using System.Text;

namespace Qberryduino.Net.Parser.Message
{
    public sealed class CurrMessage : MessageBase
    {
        public CurrMessage(string rawMessage)
        {
            Keyvals = new List<Keyval>();
            Raw = rawMessage;

            ////

            var splitted = rawMessage.Split('|');

            Keyval kv = null;
            for (int i = 1; i < splitted.Length; i++)
            {
                if (i % 2 == 0)
                {
                    //val
                    kv.SetVal(splitted[i]);
                    Keyvals.Add(kv);
                }
                else
                {
                    //key
                    kv = new Keyval(splitted[i]);
                }
            }
        }
        public MessageTypes MessageType { get; set; }
        public List<Keyval> Keyvals { get; set; }
        public string Raw { get; set; }
    }
}
