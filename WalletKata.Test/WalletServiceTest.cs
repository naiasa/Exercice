using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WalletKata.Exceptions;
using WalletKata.Users;
using WalletKata.Wallets;

namespace WalletKata.Test
{
    [TestFixture]
    public class WalletServiceTest
    {
        #region Utilities
        UserSession GetUserSessionFake(User user)
        {
            var userSessionFake = new Mock<UserSession>();
            var getLoggedUser = userSessionFake.As<IUserSession>();
            getLoggedUser.Setup(u => u.GetLoggedUser()).Returns(user);

            return userSessionFake.Object;
        }

        WalletDAO GetWalletDAOFake(User user)
        {
            List<Wallet> wallets = new List<Wallet>();
            wallets.Add(new Wallet());
            wallets.Add(new Wallet());
            wallets.Add(new Wallet());

            var walletDAOFake = new Mock<WalletDAO>();
            var findWalletsByUser = walletDAOFake.As<IWalletDAO>();
            findWalletsByUser.Setup(w => w.FindWalletsByUser(user)).Returns(wallets);

            return walletDAOFake.Object;
        }

        #endregion Utilities

        [Test]
        public void GetWalletsByUser_UserNotLogged()
        {
            User user = null;
            WalletService walletService = new WalletService(GetUserSessionFake(user), GetWalletDAOFake(user));

            Assert.That(() => walletService.GetWalletsByUser(user), Throws.TypeOf<UserNotLoggedInException>());
        }

        [Test]
        public void GetWalletsByUser_UserNotFriend_ListFriendsEmpty()
        {
            User loggedUser = new User();
            User user = new User();
            WalletService walletService = new WalletService(GetUserSessionFake(loggedUser), GetWalletDAOFake(user));

            Assert.AreEqual(walletService.GetWalletsByUser(user).Count, 0);
        }

        [Test]
        public void GetWalletsByUser_UserNotFriend_ListFriends()
        {
            User loggedUser = new User();
            User user = new User();
            user.AddFriend(new User());
            user.AddFriend(new User());
            user.AddFriend(new User());
            WalletService walletService = new WalletService(GetUserSessionFake(loggedUser), GetWalletDAOFake(user));

            Assert.AreEqual(walletService.GetWalletsByUser(user).Count, 0);
        }

        [Test]
        public void GetWalletsByUser_UserFriend()
        {
            User loggedUser = new User();
            User user = new User();
            user.AddFriend(new User());
            user.AddFriend(loggedUser);
            user.AddFriend(new User());
            WalletService walletService = new WalletService(GetUserSessionFake(loggedUser), GetWalletDAOFake(user));

            Assert.AreEqual(walletService.GetWalletsByUser(user).Count,3);
        }
    }
}
