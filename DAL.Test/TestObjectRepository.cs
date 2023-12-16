using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Test
{
    public class TestObjectRepository : BaseRepository<Object>
    {
        public TestObjectRepository(DbContext context) : base(context)
        {
        }
    }
}