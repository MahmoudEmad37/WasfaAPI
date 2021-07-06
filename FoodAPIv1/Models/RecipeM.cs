using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FoodAPIv1.Models
{
    public class RecipeM : DbContext
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "text")]
        public string Ingredients { get; set; }
        [Column(TypeName = "text")]
        public string Steps { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Nationality { get; set; }
        public long CreatedDate { get; set; }
        public string PrepareTime { get; set; }
        public int LoveCount { get; set; }
        public double ShareCount { get; set; }
        public string Privacy { get; set; }
        public int ReviewsCount { get; set; }
        public double ReviewsRateTotal { get; set; }
        public int UserId { get; set; }

       
    }
}