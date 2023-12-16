using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class ObjectRepository : BaseRepository<Object>, IObjectRepository
    {
        internal ObjectRepository(STOContent context) : base (context)
        {
            
        }
    }
}