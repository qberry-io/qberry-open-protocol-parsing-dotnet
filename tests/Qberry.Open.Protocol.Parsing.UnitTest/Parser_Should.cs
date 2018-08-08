//  Copyright (c) 2018-present, Deniz Kanmaz. All rights reserved.
//  This source code is licensed under the GNU GENERAL PUBLIC
//  LICENCE V3. Use of this source code is governed by a license
//  that can be found in the LICENSE file.

//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  LICENSE file for more details.

//  You should have received a copy of the LICENSE file along with
//  this program. If not, see <http://www.gnu.org/licenses/>.

using Qberry.Open.Protocol.Parsing.Exception;
using Qberry.Open.Protocol.Parsing.Messaging;
using Xunit;

namespace Qberry.Open.Protocol.Parsing.UnitTest
{
    public class Parser_Should
    {
        [Fact]
        public void Parse_HOLA_Messages_Correctly()
        {
            string rawMessage = "$|11|HOLA|12|90111122223333444|13|WMXQFV|14|B23a56|15|ONE|16|1.0.0|$";

            var pr = MessageParser.Parse(rawMessage);
            Assert.Equal(MessageTypes.HOLA, pr.MessageType);

            var m = new HolaMessage(pr);
            Assert.Equal(MessageTypes.HOLA, m.MessageType);
            Assert.Equal("90111122223333444", m.DeviceIdentity);
            Assert.Equal("WMXQFV", m.ConnectionId);
            Assert.Equal("1.0.0", m.ProtocolVersion);
            Assert.Equal("ONE", m.DeviceModel);
            Assert.Equal("B23a56", m.SecretKey);
        }

        [Fact]
        public void Parse_BATT_Messages_Correctly()
        {
            string rawMessage = "$|11|BATT|12|90111122223333444|13|WMXQFV|111|1|112|33|113|3664|$";

            var pr = MessageParser.Parse(rawMessage);
            Assert.Equal(MessageTypes.BATT, pr.MessageType);

            var m = new BattMessage(pr);
            Assert.Equal(MessageTypes.BATT, m.MessageType);
            Assert.Equal("90111122223333444", m.DeviceIdentity);
            Assert.Equal("WMXQFV", m.ConnectionId);
            Assert.Equal(1, m.ChargeStatus);
            Assert.Equal(33, m.BatteryLevel);
            Assert.Equal(3664, m.BatteryVoltage);
        }

        [Fact]
        public void Parse_GNSS_Messages_Correctly()
        {
            string rawMessage = "$|11|GNSS|12|90111122223333444|13|WMXQFV|211|1|212|41.042820|213|28.689460|214|108.600|215|0.43|216|344.6|217|1|218|5|219|0|$";

            var pr = MessageParser.Parse(rawMessage);
            Assert.Equal(MessageTypes.GNSS, pr.MessageType);

            var m = new GnssMessage(pr);
            Assert.Equal(MessageTypes.GNSS, m.MessageType);
            Assert.Equal("90111122223333444", m.DeviceIdentity);
            Assert.Equal("WMXQFV", m.ConnectionId);
            Assert.True(m.FixStatus);
            Assert.Equal(41.042820, m.Latitude);
            Assert.Equal(28.689460, m.Longtitude);
            Assert.Equal(108.600, m.Altitude);
            Assert.Equal(0.43, m.SpeedOverGround);
            Assert.Equal(344.6, m.CourseOverGround);
            Assert.True(m.FixMode);
            Assert.Equal(5, m.GNSSSatellitesUsed);
            Assert.Equal(0, m.GLONASSSatellitesUsed);
        }

        [Fact]
        public void Throw_Exception_If_The_Message_Is_Invalid()
        {
            string rawMessage = null;

            // null
            Assert.Throws<InvalidMessageException>(() => MessageParser.Parse(rawMessage));

            // Empty string
            rawMessage = string.Empty;
            Assert.Throws<InvalidMessageException>(() => MessageParser.Parse(rawMessage));

            // Doesn't start with "$"
            rawMessage = "|11|GNSS|12|90111122223333444|13|WMXQFV|211|1|212|41.042820|213|28.689460|214|108.600|215|0.43|216|344.6|217|1|218|5|219|0|$";
            Assert.Throws<InvalidMessageException>(() => MessageParser.Parse(rawMessage));

            // Doesn't end with "$"
            rawMessage = "$|11|GNSS|12|90111122223333444|13|WMXQFV|211|1|212|41.042820|213|28.689460|214|108.600|215|0.43|216|344.6|217|1|218|5|219|0|";
            Assert.Throws<InvalidMessageException>(() => MessageParser.Parse(rawMessage));

            // Doesn't start and end with "$"
            rawMessage = "|11|GNSS|12|90111122223333444|13|WMXQFV|211|1|212|41.042820|213|28.689460|214|108.600|215|0.43|216|344.6|217|1|218|5|219|0|";
            Assert.Throws<InvalidMessageException>(() => MessageParser.Parse(rawMessage));

            // Contains pipes more or less than expected.
            rawMessage = "$|11|GNSS|12|90111122223333444|13||WMXQFV|211|1|212|41.042820|213|28.689460|214|108.600|215|0.43|216|344.6|217|1|218|5|219|0|$";
            Assert.Throws<InvalidMessageException>(() => MessageParser.Parse(rawMessage));
        }
    }
}
