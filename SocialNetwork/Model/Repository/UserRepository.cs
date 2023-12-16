using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialNetwork.Model.Context;
using SocialNetwork.Model.DB;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace SocialNetwork.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        // ссылка на контекст
        private readonly UserContext _context;

        // Метод-конструктор для инициализации
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            // Добавление пользователя
            foreach (var people in _context.Users)
            {
                if (people.Login == user.Login && user.About != "")
                {
                    _context.Users.Remove(people);
                }
            }
            var entry = _context.Entry(user);
               if (entry.State == EntityState.Detached)
            await _context.Users.AddAsync(user);
            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public void ReadUser(ref User user)
        {
            foreach (var entry in _context.Users) 
            { 
                if (entry.Login == user.Login)
                    user = entry;
            }
        }

        public void ReadUsers(ref List<User> users)
        {
            users.Clear();
            foreach (var entry in _context.Users)
            {
                users.Add(entry);
            }

        }

        public async Task AddFriend(Friend friend)
        {
            var entry = _context.Entry(friend);
            if (entry.State == EntityState.Detached)
                await _context.Friends.AddAsync(friend);
            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public void ListFreinds(string userLogin, ref List<string> freinds)
        {
            foreach (var user in _context.Friends)
            {
                if (user.UserLogin == userLogin)
                {
                    freinds.Add(user.FrendLogin);
                }
            }

        }

    }
}
