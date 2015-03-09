using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KickyLegs.Data;
using KickyLegs.Domain.DataContext;

namespace KickyLegs.Domain.Repositories
{
    public class EventRepository:IEventRepository
    {
        private readonly EventDbContext _eventDbContext;

        public EventRepository(EventDbContext eventDbContext)
        {
            _eventDbContext = eventDbContext;
        }

        public void Save(Event anEvent)
        {
            if (anEvent.EventId == 0)
            {
                _eventDbContext.Events.Add(anEvent);
            }
            else
            {
                _eventDbContext.Entry(anEvent).State = EntityState.Modified;

            }
            _eventDbContext.SaveChanges();
        }

        public Event GetEvent(int id)
        {
            return _eventDbContext.Events.Find(id);
        }

        public List<Event> GetEvents()
        {
            return _eventDbContext.Events.ToList();
        }

        public List<Event> GetUserEvents(string userId)
        {
            return _eventDbContext.Events.Where(e => e.UserId == userId).ToList();
        }

        public void Delete(Event anEvent)
        {
            _eventDbContext.Events.Remove(anEvent);
            _eventDbContext.SaveChanges();
        }
    }
}
