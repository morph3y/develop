namespace Business.Contracts
{
    public interface IUserAccessManager
    {
        bool Authenticate(string userName, string password);
    }
}
