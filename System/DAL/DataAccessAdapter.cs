using Contracts.Dal;

namespace DAL
{
    internal sealed class DataAccessAdapter : IDataAccessAdapter
    {
        private static IDataAccessSession Session { get; set; }

        public IDataAccessSession GetSession()
        {
            return Session ?? (Session = new DataAccessSession());
        }
    }
}
