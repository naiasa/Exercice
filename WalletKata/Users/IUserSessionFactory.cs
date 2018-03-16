namespace WalletKata.Users
{
    public interface IUserSessionFactory
    {
         UserSession GetInstance();
    }
}