namespace Contracts.Dal
{
    public interface  IDataAccessSession
    {
        object Get<T>(int id);
        void Save<T>(T entity);
    }
}
