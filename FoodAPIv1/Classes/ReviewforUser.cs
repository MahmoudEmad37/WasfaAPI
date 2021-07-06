using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class ReviewforUser
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string ReviewText { get; set; }
        public bool IsCreator { get; set; }
        public long CreatedData { get; set; }

        public ReviewforUser(int id, int recipeid, string reviewText, bool isCreator, long createdData)
        {
            Id = id;
            RecipeId = recipeid;
            ReviewText = reviewText;
            IsCreator = isCreator;
            CreatedData = createdData;
        }
    }
}