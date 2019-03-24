using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodShareApp.Models
{
    public class AdminDashboardModel
    {
        public IEnumerable<FoodProvider> AllFoodProviders { get; set; }
        public IEnumerable<Food> AllFoods { get; set; }
        public IEnumerable<Event> AllEvents { get; set; }
    }
}