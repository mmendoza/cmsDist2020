using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020
{
    public class SqlConnectionConfiguration
    {
        public string Value { get; }
        public SqlConnectionConfiguration(string value) => Value = value;
    }
}
