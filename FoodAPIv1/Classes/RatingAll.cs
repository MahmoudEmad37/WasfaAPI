using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class RatingAll
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int Rating { get; set; }
        public long RatingDate { get; set; }

        public RatingAll(int id, int recipeid, int rating, long ratingDate)
        {
            Id = id;
            RecipeId = recipeid;
            Rating = rating;
            RatingDate = ratingDate;
        }
    }
}