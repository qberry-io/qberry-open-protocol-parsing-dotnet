using System;
using System.Collections.Generic;
using System.Linq;

namespace Qberryduino.Net.Parser.Core.Message
{
    public abstract class MessageBase
    {
		public string RawMessage { get; private set; }
		public MessageTypes MessageType { get; private set; }
		public IEnumerable<KeyValuePair<string, object>> Keyvals { get; private set; }

		public MessageBase(string rawMessage,
		                   IEnumerable<KeyValuePair<string, object>> keyvals,
		                   MessageTypes messageType)
        {
			RawMessage = rawMessage;
			MessageType = messageType;
        }

        protected object GetVal(string key)
		{
			if(Keyvals.Where((i) => i.Key == key).Count() == 0)
			{ return null; }

			return Keyvals.Where((i) => i.Key == key).SingleOrDefault().Value;
		}
    }
}
