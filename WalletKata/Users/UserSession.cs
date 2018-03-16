using WalletKata.Exceptions;

namespace WalletKata.Users
{
    public class UserSession : IUserSession
    {
        public UserSession() { }

        public User GetLoggedUser()
        {
            throw new ThisIsAStubException("UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }
}