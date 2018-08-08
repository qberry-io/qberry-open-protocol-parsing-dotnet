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
using System.Collections.Generic;

namespace Qberry.Open.Protocol.Parsing.Messaging
{
    /// <summary>
    /// Represents a GNSS message.
    /// </summary>
    public class GnssMessage : Message
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GnssMessage"/> class.
        /// </summary>
        /// <param name="parseResult">The instance of the <see cref="MessageParseResult"/>
        /// created by the <see cref="MessageParser"/> utility.</param>
        public GnssMessage(MessageParseResult parseResult) : base(
                        parseResult.RawMessage,
                        parseResult.Keyvals,
                        MessageTypes.GNSS)
        { }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the Fix Status of the GNSS information.
        /// </summary>
        public bool FixStatus => GetBoolean(GnssKeyDefinition.FIX_STATUS);

        /// <summary>
        /// Gets the Latitude of the location.
        /// </summary>
        public double Latitude => GetDouble(GnssKeyDefinition.LATITUDE);

        /// <summary>
        /// Gets the Longtitude of the location.
        /// </summary>
        public double Longtitude => GetDouble(GnssKeyDefinition.LONGTITUDE);

        /// <summary>
        /// Gets the Altitude of the location.
        /// </summary>
        public double Altitude => GetDouble(GnssKeyDefinition.MSL_ALTITUDE);

        /// <summary>
        /// Gets the Speed (in KM) of the point.
        /// </summary>
        public double SpeedOverGround => GetDouble(GnssKeyDefinition.SPEED_OVER_GROUND);

        /// <summary>
        /// Gets the actual direction of the point.
        /// </summary>
        public double CourseOverGround => GetDouble(GnssKeyDefinition.COURSE_OVER_GROUND);

        /// <summary>
        /// Gets the Fix Mode status of the device.
        /// </summary>
        public bool FixMode => GetBoolean(GnssKeyDefinition.FIX_MODE);

        /// <summary>
        /// Gets the number of GNSS satellites used.
        /// </summary>
        public byte GNSSSatellitesUsed => GetByte(GnssKeyDefinition.GNSS_USED);

        /// <summary>
        /// Gets the number of GLONASS Satellites used.
        /// </summary>
        public byte GLONASSSatellitesUsed => GetByte(GnssKeyDefinition.GLONASS_USED);
        #endregion
    }
}
