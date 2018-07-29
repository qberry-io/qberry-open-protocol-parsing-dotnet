using System;
using System.Collections.Generic;
using System.Text;

namespace Qberryduino.Net.Parser
{
    public class Keyval
    {
        public Keyval(string key)
        {
            Key = key;
        }

        public void SetVal(object val)
        {
            Value = val;
        }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
