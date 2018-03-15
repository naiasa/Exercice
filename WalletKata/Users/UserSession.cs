using WalletKata.Exceptions;

namespace WalletKata.Users
{
    public class UserSession : IUserSession
    {
        private static readonly UserSession userSession = new UserSession();

        public UserSession() { }

        public static UserSession GetInstance()
        {
            return userSession;
        }

        public User GetLoggedUser()
        {
            throw new ThisIsAStubException("UserSession.IsUserLoggedIn() should not be called in an unit test");
        }
    }
}