using System.Collections.Generic;
using WalletKata.Users;
using WalletKata.Exceptions;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        private readonly IUserSession _userSession = null;
        private readonly IWalletDAO _walletDAO = null;

        public WalletService(IUserSession userSession, IWalletDAO walletDAO)
        {
            _userSession = userSession;
            _walletDAO = walletDAO;
        }

        public List<Wallet> GetWalletsByUser(User user)
        {
            List<Wallet> walletList = new List<Wallet>();
            User loggedUser = _userSession.GetLoggedUser();

            if (loggedUser == null)
                throw new UserNotLoggedInException();

            if (user.GetFriends().Contains(loggedUser))
                walletList = _walletDAO.FindWalletsByUser(user);

            return walletList;
        }
    }
}