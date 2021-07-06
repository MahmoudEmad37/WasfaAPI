using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FoodAPIv1.Models
{
    public class ReviewM:DbContext
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        [Column(TypeName = "text")]
        public string ReviewText { get; set; }
        public string ReviewResult { get; set; }
        public bool IsCreator { get; set; }
        public long CreatedData { get; set; }

       
    }
}