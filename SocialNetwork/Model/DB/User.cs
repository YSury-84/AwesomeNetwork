using Microsoft.AspNetCore.Identity;
using System;

namespace SocialNetwork.Model.DB
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }

        public string PassReg { get; set; }

        public string FIO { get; set; }

        public DateTime UserData { get; set; }

        public string Image { get; set; }

        public string About { get; set; }

        public User()
        {
            Image = "https://cdn-m.sport24.ru/m/ff81/47da/ce50/4534/b200/b05d/3fa2/fab9/400_10000_max.jpeg";
            About = "Информация обо мне.";
        }
    }
}
