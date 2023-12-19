using SocialNetwork.Model.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Model.Repository
{
    public interface IUserRepository
    {
        public void AddUser(User user);

        public void ReadUser(ref User user);

        public void ReadUsers(ref List<User> users);

        Task AddFriend(Friend friend);

        public void ListFreinds(string userLogin, ref List<string> freinds);
    }
}
