using System;
namespace Qberryduino.Net.Parser.Messaging
{
	public sealed class TypeDescription
    {
        public string Version { get; set; }
        public MessageTypes MessageType { get; set; }

		public TypeDescription(string version, MessageTypes messageType)
		{
			Version = version;
			MessageType = messageType;
		}

		public override string ToString()
		{
			return $"{MessageType.ToString()} - {Version}";
		}
	}
}
