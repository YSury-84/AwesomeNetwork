﻿using Microsoft.EntityFrameworkCore;
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
    public class FriendRepository : IFriendRepository
    {
        // ссылка на контекст
        private readonly FriendContext _context;

        // Метод-конструктор для инициализации
        public FriendRepository(FriendContext context)
        {
            _context = context;
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
