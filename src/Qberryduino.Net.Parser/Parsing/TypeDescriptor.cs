using System;
using Qberryduino.Net.Parser.Core;

namespace Qberryduino.Net.Parser.Messaging.v1
{
	public class TypeDescriptor : ITypeDescriptor
    {      
		/// <inheritdoc />
		public TypeDescription Describe(string message)
		{
			if (!message.StartsWith(Symbol.BEGIN.ToString(), StringComparison.Ordinal)
			    || !message.EndsWith(Symbol.END.ToString(), StringComparison.Ordinal))
            { throw new Exception("Invalid message format."); }
                     
			var splitted = message.Split(Symbol.SPLITTER);

            /*
            if (verKey < 0)
			{ throw new Exception("Version information couldn't be found in message."); }

			var typeKey = Array.IndexOf(splitted, MESSAGE_TYPE_KEY);
            if (typeKey < 0)
			{ throw new Exception("Type of message couldn't be found in message."); }
            */

			MessageTypes mt;

            switch (splitted[typeKey + 1])
            {
                case "hola":
                    mt = MessageTypes.Hola;
                    break;
                case "curr":
                    mt = MessageTypes.Current;
                    break;
                default:
                    throw new Exception("Unknown message type.");
            }

			return new TypeDescription(message, mt);
		}
	}
}
