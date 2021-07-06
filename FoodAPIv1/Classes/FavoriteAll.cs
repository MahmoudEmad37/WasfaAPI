using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class FavoriteAll
    {
        public int Id { get; set; }
        public int FavRecipeId { get; set; }

        public FavoriteAll(int id, int favRecipeId)
        {
            Id = id;
            FavRecipeId = favRecipeId;
        }
    }
}