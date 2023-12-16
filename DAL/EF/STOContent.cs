using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class STOContent : DbContext
    {
        public System.Data.Entity.DbSet<Event> Events  { get; set; }
        public System.Data.Entity.DbSet<Object> Objects { get; set; }
        public System.Data.Entity.DbSet<Calendar> Calendars { get; set; }

        public STOContent(DbContextOptions options) : base(options)
        {
        }
    }
}