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

using Qberry.Open.Protocol.Core.Key;
using System;

namespace Qberry.Open.Protocol.Parsing.Messaging
{
    /// <summary>
    /// Represents a BATT message.
    /// </summary>
    public class BattMessage : Message
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BattMessage"/> class.
        /// </summary>
        /// <param name="parseResult">The instance of the <see cref="MessageParseResult"/>
        /// created by the <see cref="MessageParser"/> utility.</param>
        public BattMessage(MessageParseResult parseResult) : base(
                        parseResult.RawMessage,
                        parseResult.Keyvals,
                        MessageTypes.BATT)
        { }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the Charge Status of the device. 
        /// </summary>
        public byte ChargeStatus
        { get { return Convert.ToByte(GetObject(BattKeyDefinition.CHARGE_STATUS)); } }

        /// <summary>
        /// Gets the Battery Level of the device.
        /// </summary>
        public int BatteryLevel
        { get { return Convert.ToInt32(GetObject(BattKeyDefinition.BATTERY_LEVEL)); } }

        /// <summary>
        /// Gets the Battery Voltage of the device.
        /// </summary>
        public double BatteryVoltage
        { get { return Convert.ToDouble(GetObject(BattKeyDefinition.BATTERY_VOLTAGE)); } }
        #endregion
    }
}
