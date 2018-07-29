using System;
using System.Linq;

namespace Qberryduino.Net.Parser
{
    public static class TypeDescriptor
    {
        public static TypeDescription Describe(string rawMessage)
        {

            if (!rawMessage.StartsWith("$") || !rawMessage.EndsWith("$"))
            { throw new Exception("This is not a message expected."); }


            var splitted = rawMessage.Split('|');

            var verKey = Array.IndexOf(splitted, "15");
            if (verKey < 0)
            { throw new Exception("Version couldn't be found."); }

            var typeKey = Array.IndexOf(splitted, "11");
            if (typeKey < 0)
            { throw new Exception("Type couldn't be found."); }

            TypeDescription td = new TypeDescription();

            switch (splitted[typeKey + 1])
            {
                case "hola":
                    td.MessageType = MessageTypes.Hola;
                    break;
                case "curr":
                    td.MessageType = MessageTypes.Current;
                    break;
                default:
                    throw new Exception("Unknown message type.");
            }

            return td;

        }

        public class TypeDescription
        {
            public string Version { get; set; }
            public MessageTypes MessageType { get; set; }
        }
    }
}
