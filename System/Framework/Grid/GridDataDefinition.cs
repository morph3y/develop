using System;
using System.Collections.Generic;
using Entities.Entities;

namespace Framework.Grid
{
    public class GridDataDefinition
    {
        private readonly List<BusinessObject> _origin;

        public GridDataDefinition(List<BusinessObject> businessObjects)
        {
            _origin = businessObjects;
        }

        public GridDataDefinition(BusinessObject businessObject)
            : this(new List<BusinessObject> { businessObject })
        { }

        public Int32 CurrentPage { get; set; }
        public Int32 ItemsPerPage { get; set; }
        public String Area { get; set; }
        public String Controller { get; set; }
        public String Action { get; set; }

        public List<GridDataObject> DataObjects
        {
            get
            {
                var toReturn = new List<GridDataObject>();
                foreach (var businessObject in _origin)
                {
                    toReturn.Add(new GridDataObject(businessObject));
                }
                return toReturn;
            }
        }
    }
}
