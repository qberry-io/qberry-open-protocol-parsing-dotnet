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

namespace Qberry.Open.Protocol.Core.Key
{
    /// <summary>
    /// A static class containing GNSS KEY constants.
    /// </summary>
    public static class GnssKeyDefinition
    {
        public const string FIX_STATUS = "211";
        public const string LATITUDE = "212";
        public const string LONGTITUDE = "213";
        public const string MSL_ALTITUDE = "214";
        public const string SPEED_OVER_GROUND = "215";
        public const string COURSE_OVER_GROUND = "216";
        public const string FIX_MODE = "217";
        public const string GNSS_USED = "218";
        public const string GLONASS_USED = "219";
    }
}
