using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Models
{
    public class RecipeImageM : DbContext
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        [Column(TypeName = "text")]
        public string ImageUrl { get; set; }
    }
}