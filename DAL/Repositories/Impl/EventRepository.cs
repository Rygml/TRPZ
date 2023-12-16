using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(STOContent context) : base (context)
        {
        }
    }
}