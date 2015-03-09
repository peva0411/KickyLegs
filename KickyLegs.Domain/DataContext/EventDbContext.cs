using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KickyLegs.Data;

namespace KickyLegs.Domain.DataContext
{
    public class EventDbContext :DbContext
    {
        public EventDbContext():base("DefaultConnection")
        {
        }

        public DbSet<Event> Events { get; set; } 

    }
}
