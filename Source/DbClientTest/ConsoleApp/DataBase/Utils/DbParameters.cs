using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;    

namespace ConsoleApp.DataBase.Utils
{
    internal class DbParameters : ReadOnlyDictionary<string, object>
    {
        IDictionary<string, object> baseSource;

        public DbParameters() : base(new Dictionary<string, object>())
        {
            var type = typeof(ReadOnlyDictionary<string, object>);
            var value = type.GetField("source", BindingFlags.Instance | BindingFlags.NonPublic);
            baseSource = value.GetValue(this) as IDictionary<string, object>;
        }

        public new void Add(string key, object value)
        {
            baseSource.Add(key, value ?? DBNull.Value);
        }
    }
}
