using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareApp.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<FoodProvider> foodProvider { get; set; }
        public IEnumerable<Food> food { get; set; }
        public IEnumerable<Event> events { get; set; }

        public IEnumerable<Notification> notifications { get; set; }
    }
}