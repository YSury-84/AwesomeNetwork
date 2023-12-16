using Microsoft.EntityFrameworkCore;
using SocialNetwork.Model.DB;

namespace SocialNetwork.Model.Context
{
    public sealed class UserContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }

        // Логика взаимодействия с таблицами в БД
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
