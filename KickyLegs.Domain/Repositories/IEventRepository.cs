using System;
using System.Collections.Generic;
using KickyLegs.Data;

namespace KickyLegs.Domain.Repositories
{
    public interface IEventRepository
    {
        void Save(Event anEvent);
        Event GetEvent(int id);
        List<Event> GetEvents();
        List<Event> GetUserEvents(string userId);
        void Delete(Event anEvent);
    }
}