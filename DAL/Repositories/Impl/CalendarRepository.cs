using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class CalendarRepository : BaseRepository<Calendar>, ICalendarRepository
    {
        internal CalendarRepository(STOContent context) : base (context)
        {
            
        }
    }
}