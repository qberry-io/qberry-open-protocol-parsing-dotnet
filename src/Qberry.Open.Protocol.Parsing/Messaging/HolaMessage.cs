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

namespace Qberry.Open.Protocol.Parsing.Messaging
{
    /// <summary>
    /// Represents a HOLA message.
    /// </summary>
    public class HolaMessage : Message
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HolaMessage"/> class.
        /// </summary>
        /// <param name="parseResult">The instance of the <see cref="MessageParseResult"/>
        /// created by the <see cref="MessageParser"/> utility.</param>
        public HolaMessage(MessageParseResult parseResult) : base(
                       parseResult.RawMessage,
                       parseResult.Keyvals,
                       MessageTypes.HOLA)
        { }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the Secret Key of the device.
        /// </summary>
        public string SecretKey
        { get { return GetString(HolaKeyDefinition.SECRET_KEY); } }

        /// <summary>
        /// Gets the Model of the device.
        /// </summary>
        public string DeviceModel
        { get { return GetString(HolaKeyDefinition.DEVICE_MODEL); } }

        /// <summary>
        /// Gets the version of protocol.
        /// </summary>
        public string ProtocolVersion
        { get { return GetString(HolaKeyDefinition.PROTOCOL_VERSION); } }
        #endregion
    }
}
