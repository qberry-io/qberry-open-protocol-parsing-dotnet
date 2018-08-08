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
using System.Collections.Generic;
using System.Linq;

namespace Qberry.Open.Protocol.Parsing.Messaging
{
    /// <summary>
    /// Represents an abstract Message (See derived classes).
    /// </summary>
    public abstract class Message
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="rawMessage">Raw message from the device.</param>
        /// <param name="keyvals">KeyVal collection created by
        /// <see cref="MessageParser"/> utility. </param>
        /// <param name="messageType">Type of the message</param>
        public Message(string rawMessage,
                               Dictionary<string, object> keyvals,
                               MessageTypes messageType)
        {
            Keyvals = keyvals;
            RawMessage = rawMessage;
            MessageType = messageType;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the original message that came from the device.
        /// </summary>
        public string RawMessage { get; private set; }

        /// <summary>
        /// Gets the type of message.
        /// </summary>
        public MessageTypes MessageType { get; private set; }

        /// <summary>
        /// Gets the identity of device.
        /// </summary>
        public string DeviceIdentity
        { get { return GetString(HeaderKeyDefinition.DEVICE_IDENTITY); } }

        /// <summary>
        /// Gets the identity of connection.
        /// </summary>
        public string ConnectionId
        { get { return GetString(HeaderKeyDefinition.CONNECTION_ID); } }

        /// <summary>
        /// Gets the KeyVal (Key / Value) collection of the message.
        /// </summary>
        public Dictionary<string, object> Keyvals { get; private set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets the value stored with the specified key. 
        /// </summary>
        /// <param name="key">The key of the expected value.</param>
        /// <returns>Value as <see cref="object"/></returns>
        public object GetObject(string key)
        {
            if (Keyvals.Where((i) => i.Key == key).Count() == 0)
            { return null; }

            return Keyvals.Where((i) => i.Key == key).SingleOrDefault().Value;
        }

        /// <summary>
        /// Gets the value stored with the specified key.
        /// </summary>
        /// <param name="key">The key of the expected value.</param>
        /// <returns>Value as <see cref="Double"/></returns>
        public double GetDouble(string key) => Convert.ToDouble(GetObject(key));

        /// <summary>
        /// Gets the value stored with the specified key.
        /// </summary>
        /// <param name="key">The key of the expected value.</param>
        /// <returns>Value as <see cref="Boolean"/></returns>
        public bool GetBoolean(string key) => (string)GetObject(key) == "1";

        /// <summary>
        /// Gets the value stored with the specified key.
        /// </summary>
        /// <param name="key">The key of the expected value.</param>
        /// <returns>Value as <see cref="byte"/></returns>
        public byte GetByte(string key) => Convert.ToByte(GetObject(key));

        /// <summary>
        /// Gets the value stored with the specified key.
        /// </summary>
        /// <param name="key">The key of the expected value.</param>
        /// <returns>Value as <see cref="string"/></returns>
        public string GetString(string key) => (string)GetObject(key);
        #endregion

        #region Overriden methods
        public override string ToString()
        { return RawMessage; }
        #endregion
    }
}
