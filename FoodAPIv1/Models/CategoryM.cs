using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Models
{
    public class CategoryM : DbContext
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Title { get; set; }
        

    }
}