using System;

namespace DAL.Entities
{
    public class PrivUser
    {
        public int PrivUserId { get; set; }
        public String Name { get; set; }
        public int Surname { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String AccountType { get; set; }
    }
}