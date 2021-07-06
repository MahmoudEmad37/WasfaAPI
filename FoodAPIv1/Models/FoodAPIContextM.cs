using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FoodAPIv1.Models
{
    public class FoodAPIContextM:DbContext
    {
        public DbSet<UserM> User { get; set; }
        public DbSet<RecipeM> Recipe { get; set; }
        public DbSet<ReviewM> Review { get; set; }
        public DbSet<RatingM> Rating { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CateRecipeM> CateRecipe { get; set; }
        public DbSet<FavoritesM> Favorites { get; set; }
        public DbSet<FollowingM> Following { get; set; }
        public DbSet<LinksM> Links { get; set; }
        public DbSet<RecipeImageM> RecipeImage { get; set; }

    }
}