using System;
using System.Collections.Generic;
using Qberryduino.Net.Parser.Core.KeyDefinition;

namespace Qberryduino.Net.Parser.Core.Message
{
	public class ElectricityMessage : MessageBase
    {
		public ElectricityMessage(string rawMessage,
                    IEnumerable<KeyValuePair<string, object>> keyvals
                   ) : base(
                        rawMessage,
                        keyvals,
                        MessageTypes.Current)
        { }

		public byte ChargeStatus
		{ get { return (byte)GetVal(ElectricityKeyDefinition.CHARGE_STATUS); } }

		public byte BatteryLevel
		{ get { return (byte)GetVal(ElectricityKeyDefinition.BATTERY_LEVEL); } }

		public double BatteryVoltage
		{ get { return (byte)GetVal(ElectricityKeyDefinition.BATTERY_VOLTAGE); } }
    }
}
