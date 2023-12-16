using System;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IObjectRepository ObjectRepository { get; }
        ICalendarRepository CalendarRepository { get; }
        IEventRepository EventRepository { get; }
        void Save();
    }
}