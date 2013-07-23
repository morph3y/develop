using System;

namespace Framework.Grid
{
    public class SimplePropertyData : IPropertyData
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public Type Type { get; set; }
    }
}
