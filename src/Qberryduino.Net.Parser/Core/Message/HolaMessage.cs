using System;
using System.Collections.Generic;
using Qberryduino.Net.Parser.Core.KeyDefinition;

namespace Qberryduino.Net.Parser.Core.Message
{
	public class HolaMessage:MessageBase
    {
		public HolaMessage(string rawMessage,
		            IEnumerable<KeyValuePair<string, object>> keyvals
		           ):base(
			           rawMessage,
			           keyvals,
			           MessageTypes.Hola)
        { }

		public string DeviceIdentity
		{ get { return (string) GetVal(HeaderKeyDefinition.DEVICE_IDENTITY); } }

		public string SecretKey
		{ get { return (string) GetVal(HeaderKeyDefinition.SECRET_KEY); } }

		public string DeviceModel
		{ get { return (string)GetVal(HeaderKeyDefinition.DEVICE_MODEL); } }

		public string ProtocolVersion
		{ get { return (string)GetVal(HeaderKeyDefinition.PROTOCOL_VERSION); } }

		public override string ToString()
		{ return RawMessage; }
	}
}
