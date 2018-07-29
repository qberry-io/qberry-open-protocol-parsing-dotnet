using System;
using System.Collections.Generic;
using System.Text;
using Qberryduino.Net.Parser.Core;

namespace Qberryduino.Net.Parser.Message
{
    public sealed class CurrMessage : MessageBase
    {
		public MessageTypes MessageType { get { return MessageTypes.Current; } }
        public List<KeyValuePair<string, object>> Keyvals { get; private set; }
        public string RawMessage { get; private set; }

        public CurrMessage(string rawMessage)
        {
			Keyvals = new List<KeyValuePair<string, object>>();
			RawMessage = rawMessage;

            ////

			var splitted = rawMessage.Split(Symbol.SPLITTER);

			KeyValuePair<string, object> kv;
			object val = null;
            for (int i = 1; i < splitted.Length; i++)
            {
                if (i % 2 == 0)
                {
                    //val
					val = splitted[i];
                    Keyvals.Add(kv);
                }
                else
                {
                    //key
					kv = new KeyValuePair<string, object>(splitted[i], val);
                }
            }
        }      
    }
}
