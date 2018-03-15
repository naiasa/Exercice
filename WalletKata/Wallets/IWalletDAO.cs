using System.Collections.Generic;
using WalletKata.Users;

namespace WalletKata.Wallets
{
    public interface IWalletDAO
    {
        List<Wallet> FindWalletsByUser(User user);
    }
}