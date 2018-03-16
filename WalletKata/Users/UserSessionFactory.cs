using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletKata.Users
{
    public class UserSessionFactory : IUserSessionFactory
    {
        public UserSession GetInstance()
        {
            return new UserSession();
        }
    }
}
