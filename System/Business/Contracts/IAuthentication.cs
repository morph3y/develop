namespace Business.Contracts
{
    public interface IAuthentication
    {
        void SetCookies(string userName);
        void DeleteCookies();
    }
}
