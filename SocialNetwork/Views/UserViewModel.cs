using SocialNetwork.Model.DB;
using System.Collections.Generic;

namespace SocialNetwork.Views
{
    public class UserViewModel
    {
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }

        public List<User> Friends { get; set; }

        public string GetUserName()
        {
            return User.Login;
        }

    }
}
