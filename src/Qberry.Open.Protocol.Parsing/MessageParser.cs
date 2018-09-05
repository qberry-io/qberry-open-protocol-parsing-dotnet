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

using Qberry.Open.Protocol.Core;
using Qberry.Open.Protocol.Core.Key;
using Qberry.Open.Protocol.Parsing.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Qberry.Open.Protocol.Parsing
{
    /// <summary>
    /// A static class containing method for parsing raw message from the device.
    /// </summary>
    public static class MessageParser
    {
        #region Public methods
        /// <summary>
        /// Parses the given raw message.
        /// </summary>
        /// <param name="rawMessage">The raw message from device.</param>
        /// <returns>
        /// The result of the parsing operation.
        /// </returns>
        public static ParsingResult Parse(string rawMessage)
        {
            // Validate the message (Throws if invalid)..
            Validate(rawMessage);

            // Initialize a collection..
            var keyvals = new Dictionary<string, object>();

            // Split the raw message by the Splitter Symbol..
            var splitted = rawMessage.Split(Symbol.SPLITTER);

            // Put all the keys and values to the collection..
            object val = null;
            string key = null;
            for (int i = 1; i < splitted.Length; i++)
            {
                if (i % 2 == 0)
                {
                    //val
                    val = splitted[i];
                    keyvals.Add(key, val);
                }
                else
                {
                    //key
                    key = splitted[i];
                }
            }

            // Find out the type of the message.
            var mts = keyvals.SingleOrDefault(
                i => i.Key == HeaderKeyDefinition.MESSAGE_TYPE).Value;
            var messageType = (MessageTypes)Enum.Parse(typeof(MessageTypes),
                    (string)mts);

            return new ParsingResult(rawMessage, keyvals, messageType);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Validates the given message.
        /// </summary>
        /// <param name="rawMessage">Raw message from the device.</param>
        private static void Validate(string rawMessage)
        {
            if (string.IsNullOrWhiteSpace(rawMessage))
            {
                throw new InvalidMessageException("The provided message was " +
                    "null or empty.");
            }
            else if (!rawMessage.StartsWith(Symbol.BEGIN)
               || !rawMessage.EndsWith(Symbol.END))
            {
                throw new InvalidMessageException($"A message must start " +
                    $"with {Symbol.BEGIN} character and end " +
                    $"with {Symbol.END} character.");
            }

            else if (rawMessage.Where(i => i == '|').Count() % 2 == 0)
            {
                throw new InvalidMessageException("The provided message contains " +
                  "pipes more or less than expected.");
            }
        }
        #endregion
    }
}
