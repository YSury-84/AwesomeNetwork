using System;

namespace SocialNetwork.Model.DB
{
    public class Friend
    {
        public Guid Id { get; set; }
        public string UserLogin { get; set; }
        public string FrendLogin { get; set; }
        public DateTime AddDate { get; set; }
        public Friend() 
        { 
            AddDate = DateTime.Now;
        }
    }
}
