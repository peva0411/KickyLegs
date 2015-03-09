using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickyLegs.Data
{
    public class Event
    {
        public int EventId { get; set; }
        public string UserId { get; set; }
     
        [Display(Name="Event Date/Time")]
        public DateTime DateTime { get; set; }
        
        [Display(Name = "Hours since last caffeine")]
        public int? LastCaffeine { get; set; }
        
        [MaxLength(512)]
        [DisplayName("Last Food")]
        public string LastFood { get; set; }
        public int Duration { get; set; }

        [MaxLength(512)]
        public string Notes { get; set; }
    }
}
