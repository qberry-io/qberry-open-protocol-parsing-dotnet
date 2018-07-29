using System;
using System.Collections.Generic;
using Qberryduino.Net.Parser.Core.KeyDefinition;

namespace Qberryduino.Net.Parser.Core.Message
{
	public class GNSSMessage : MessageBase
    {
		public GNSSMessage(string rawMessage,
		            IEnumerable<KeyValuePair<string, object>> keyvals
		           ) :base(
        				rawMessage,
        				keyvals,
        				MessageTypes.Current)
		{
			Header = new HolaMessage(rawMessage, keyvals);
		}

		public HolaMessage Header
		{ get; private set; }

		public bool FixStatus
		{ get { return (bool)GetVal(GNSSKeyDefinition.FIX_STATUS); } }

		public double Latitude
		{ get { return (double)GetVal(GNSSKeyDefinition.LATITUDE); } }

		public double Longtitude
		{ get { return (double)GetVal(GNSSKeyDefinition.LONGTITUDE); } }

		public double Altitude
		{ get { return (double)GetVal(GNSSKeyDefinition.MSL_ALTITUDE); } }

		public double SpeedOverGround
		{ get { return (double)GetVal(GNSSKeyDefinition.SPEED_OVER_GROUND); } }

		public double CourseOverGround
		{ get { return (double)GetVal(GNSSKeyDefinition.COURSE_OVER_GROUND); } }
        
		public bool FixMode
		{ get { return (bool)GetVal(GNSSKeyDefinition.FIX_MODE); } }
        
		public byte GNSSUsed
		{ get { return (byte)GetVal(GNSSKeyDefinition.GNSS_USED); } }
        
		public byte GLONASSUsed
		{ get { return (byte)GetVal(GNSSKeyDefinition.GLONASS_USED); } }
    }
}
