using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FoodAPIv1.Models
{
    public class RatingM:DbContext
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public int RatingNum { get; set; }
        public DateTime CreatedData { get; set; }

        
    }
}