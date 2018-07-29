using System;
namespace Qberryduino.Net.Parser.Messaging
{
    public interface ITypeDescriptor
    {
		/// <summary>
        ///  Testing
        /// </summary>
        /// <returns>The describe.</returns>
        /// <param name="message">Message.</param>
		TypeDescription Describe(string message);
    }
}
