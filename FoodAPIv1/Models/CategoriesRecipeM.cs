using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Models
{
    public class CategoriesRecipeM : DbContext
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public List<int> categ { get; set; }

    }
}