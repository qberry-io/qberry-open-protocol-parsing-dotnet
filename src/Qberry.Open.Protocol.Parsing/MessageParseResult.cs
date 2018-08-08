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

using System.Collections.Generic;

namespace Qberry.Open.Protocol.Parsing
{
    /// <summary>
    /// Represents the result of a parse operation.
    /// </summary>
    public class MessageParseResult
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageParseResult"/>
        /// class.
        /// </summary>
        /// <param name="rawMessage">Raw message from the device.</param>
        /// <param name="keyvals">KeyVal collection created by
        /// <see cref="MessageParser"/> utility.</param>
        /// <param name="messageType">Type of the message.</param>
        internal MessageParseResult(string rawMessage,
                                    Dictionary<string, object> keyvals,
                                    MessageTypes messageType)
        {
            RawMessage = rawMessage;
            Keyvals = keyvals;
            MessageType = messageType;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the Keyval (Key / Value) collection.
        /// </summary>
        public Dictionary<string, object> Keyvals { get; private set; }

        /// <summary>
        /// Gets the type of message.
        /// </summary>
        public MessageTypes MessageType { get; private set; }

        /// <summary>
        /// Gets the original message string.
        /// </summary>
        public string RawMessage { get; private set; }
        #endregion
    }
}
