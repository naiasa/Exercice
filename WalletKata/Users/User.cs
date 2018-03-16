using System.Collections;
using System.Collections.Generic;

namespace WalletKata.Users
{
    public class User
    {
        private List<User> _friends = new List<User>();

        public List<User> GetFriends()
        {
            return _friends;
        }

        public void AddFriend(User friend)
        {
            _friends.Add(friend);
        }
    }
}