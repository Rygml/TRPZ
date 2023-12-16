using System;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Object = DAL.Entities.Object;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private STOContent db;
        private CalendarRepository _calendarRepository;
        private ObjectRepository _objectRepository;
        private EventRepository _eventRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new STOContent(options);
        }
        public IRepository<Calendar> Calendars 
        {
            get
            {
                if (_calendarRepository == null)
                    _calendarRepository = new CalendarRepository(db);
                return _calendarRepository;
            }
        }
        public IRepository<Object> Objects
        {
            get
            {
                if (_objectRepository == null)
                    _objectRepository = new ObjectRepository(db);
                return _objectRepository;
            }
        }

        public IRepository<Event> Events
        {
            get
            {
                if (_eventRepository == null)
                    _eventRepository = new EventRepository(db);
                return _eventRepository;
            }
        }


        public IObjectRepository ObjectRepository { get; }
        public ICalendarRepository CalendarRepository { get; }
        public IEventRepository EventRepository { get; }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        private IUnitOfWork _unitOfWorkImplementation;
        private IUnitOfWork _unitOfWorkImplementation1;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}