using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class CategoriesAll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<RecipeAll> Recipes { get; set; }

        public CategoriesAll(int id, string title, List<RecipeAll> recipes)
        {
            Id = id;
            Title = title;
            Recipes = recipes;
        }
    }
}