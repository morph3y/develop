using System;

namespace Framework.Grid
{
    public interface IPropertyData
    {
        String Name { get; set; }
        object Value { get; set; }
        Type Type { get; set; }
    }
}
