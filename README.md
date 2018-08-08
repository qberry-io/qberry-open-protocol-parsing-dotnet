
# Qberry Open Protocol Parsing Library for dotnet v.1.0.0-beta1

"Qberry Open Parsing Library" is the official library for parsing messages built with ["Qberry Open Protocol"](https://github.com/denizkanmaz/qberry-open-protocol).

You can get the latest release from the official Nuget.org feed or from the github releases page.

## Getting Started

### Example 1:

    // The raw message from the device..
    string rawMessage = "$|11|HOLA|12|90111122223333444|13|WMXQFV|14|B23a56|15|ONE|16|1.0.0|$";
    
    // Parse the raw message using MessageParser utility.
    var pr = MessageParser.Parse(rawMessage);
    
    // Writing the message type to the console.
    System.Console.WriteLine($"The type of the message is {pr.MessageType}.");
    
    // Creation of the object form of the message.
    var m = new HolaMessage(pr);
    
    // Writing some values to the console.
    System.Console.WriteLine($"The device id is {m.DeviceIdentity}.");
    System.Console.WriteLine($"The protocol version of the device id is {m.ProtocolVersion}.");
  
### Example 2:

    // The raw message from the device..
    string rawMessage = "$|11|GNSS|12|90111122223333444|13|WMXQFV|211|1|212|39.922790|213|32.838507|214|108.600|215|0.43|216|344.6|217|1|218|5|219|0|$";
    
    // Parse the raw message using MessageParser utility.
    var pr = MessageParser.Parse(rawMessage);
    
    // Writing the message type to the console
    System.Console.WriteLine($"The type of the message is {pr.MessageType}.");
    
    // Creation of the object form of the message.
    var m = new GnssMessage(pr);
    
    // Writing some values to the console.
    System.Console.WriteLine($"The device id is {m.DeviceIdentity}.");
    System.Console.WriteLine($"Latitude is {m.Latitude}.");
    System.Console.WriteLine($"Longtitude is {m.Longtitude}.");
    System.Console.WriteLine($"Moving in {m.SpeedOverGround}/km speed.");

## Versioning

Used [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/denizkanmaz/qberryduino-gateway-one/tags). 

## Authors

* **[Deniz Kanmaz](https://github.com/denizkanmaz)** - *Initial work* - [qberry.io](https://qberry.io)

## License

This project is licensed under the GNU General Public License v3 - see the [LICENSE.md](LICENSE.md) file for details.

NOTICE: This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
