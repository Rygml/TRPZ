using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public IEnumerable<Users> UsedUsersAccounts { get; set; }
        public IEnumerable<PrivUser> UsedAdministratorAccounts { get; set; }
        public IEnumerable<Object> Objects { get; set; }
        public IEnumerable<Calendar> Date { get; set; }
    }
}