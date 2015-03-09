using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KickyLegs.Web.Models.Events
{
    public class CreateEventViewModel
    {
        [Display(Name="Event Time")]
        public DateTime EventTime { get; set; }
        
        [Display(Name = "Hours Since Last Caffeine")]
        public List<SelectListItem> CaffeineHours{ get; set; }

        [Display(Name = "Event Duration (minutes)")]
        public List<SelectListItem> DurationList { get; set; } 

        public int LastCaffeine { get; set; }
        [Display(Name = "Last Food")]
        public string LastFood { get; set; }
        public int Duration { get; set; }
        public string Notes { get; set; }


        public CreateEventViewModel()
        {
            CreateCaffeineList();
            CreateDurationList();
        }

        private void CreateDurationList()
        {
            DurationList = new List<SelectListItem>();
            DurationList.Add(new SelectListItem() {Text = "0-15", Value = "15"});
            DurationList.Add(new SelectListItem() {Text = "16-30", Value = "30"});
            DurationList.Add(new SelectListItem() {Text = "31-45", Value = "45"});
            DurationList.Add(new SelectListItem() {Text = "46-60", Value = "60"});
        }

        private void CreateCaffeineList()
        {
            CaffeineHours = new List<SelectListItem>();

            CaffeineHours.Add(new SelectListItem() {Text = "No Caffeine", Value = "-1", Selected = true});
            CaffeineHours.Add(new SelectListItem() {Text = "Less than 1 hour", Value = "0"});

            for (int i = 1; i < 11; i++)
            {
                CaffeineHours.Add(new SelectListItem()
                {
                    Text = string.Format("{0} ({1:h:mm tt})", i, DateTime.Now.AddHours(-i)),
                    Value = i.ToString()
                });
            }

            CaffeineHours.Add(new SelectListItem()
            {
                Text = string.Format("12 ({0: h:mm tt})", DateTime.Now.AddHours(12)),
                Value = "12"
            });

            LastCaffeine = -1;
        }
    }
}