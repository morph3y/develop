using System;

namespace DAL.Exceptions
{
    public class EntitySaveException : Exception
    {
        public EntitySaveException()
            : base("An error occured during the save of the entity.")
        { }

        public EntitySaveException(Exception innerException)
            : base("An error occured during the save of the entity.", innerException)
        { }
    }
}
