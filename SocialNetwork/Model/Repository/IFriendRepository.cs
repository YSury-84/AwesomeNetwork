using SocialNetwork.Model.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Model.Repository
{
    public interface IFriendRepository
    {
        Task AddFriend(Friend friend);

        public void ListFreinds(string userLogin, ref List<string> freinds);

    }
}
