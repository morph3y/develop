using System;
using System.Collections.Generic;
using Entities.Entities;

namespace Framework.Grid
{
    public class GridDataObject
    {
        private readonly BusinessObject _origin;
        private List<IPropertyData> _properties; 

        public GridDataObject(BusinessObject businessObject)
        {
            _origin = businessObject;
            Id = businessObject.Id;
        }
        public Guid Id { get; private set; }

        public List<IPropertyData> Properties
        {
            get
            {
                if (_properties != null)
                {
                    return _properties;
                }
                return _properties = GetProperties();
            }
        }

        private List<IPropertyData> GetProperties()
        {
            var propertyReflection = _origin.GetType().GetProperties();
            var toReturn = new List<IPropertyData>();
            foreach (var propertyInfo in propertyReflection)
            {
                //TODO: refactor
                if (propertyInfo.Name == "Id")
                {
                    continue;
                }
                var property = new SimplePropertyData
                {
                    Name = propertyInfo.Name,
                    Value = propertyInfo.GetValue(_origin, null),
                    Type = propertyInfo.GetType()
                };
                toReturn.Add(property);
            }
            return toReturn;
        }
    }
}
