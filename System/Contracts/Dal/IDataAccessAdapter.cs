namespace Contracts.Dal
{
    public interface IDataAccessAdapter
    {
        IDataAccessSession GetSession();
    }
}
