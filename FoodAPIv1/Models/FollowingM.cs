using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Models
{
    public class FollowingM : DbContext
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        
    }
}