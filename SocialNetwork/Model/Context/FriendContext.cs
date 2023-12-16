using Microsoft.EntityFrameworkCore;
using SocialNetwork.Model.DB;

namespace SocialNetwork.Model.Context
{
    public sealed class FriendContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<Friend> Friends { get; set; }

        // Логика взаимодействия с таблицами в БД
        public FriendContext(DbContextOptions<FriendContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
