using Qberryduino.Net.Parser;
using Qberryduino.Net.Parser.Message;
using System;
using Xunit;

namespace Qberryduino.Net.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // $|11|curr|12|90865067022296647|13|123456|15|1.0.0|111|0|112|17|113|3543OK|$
            string rawMessage = "$|11|curr|12|90865067022296647|13|123456|15|1.0.0|211|1|212|41.042885|213|28.689113|214|99.300|215|0.76|216|88.6|217|1|218|12|$";

            // string rawMessage = "$|11|curr|12|90865067022296647|13|123456|15|1.0.0|111|0|112|17|113|3543OK|$";

            var td = TypeDescriptor.Describe(rawMessage);

            Assert.Equal(MessageTypes.Current, td.MessageType);

            switch (td.MessageType)
            {
                case MessageTypes.Hola:
                    break;
                case MessageTypes.Current:
                    var test = new CurrMessage(rawMessage);
                    break;
                default:
                    break;
            }
        }
    }
}
