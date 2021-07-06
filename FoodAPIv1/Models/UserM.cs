using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPIv1.Models
{
    public class UserM:DbContext
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Gender { get; set; }
        [Column(TypeName = "text")]
        public string ImageUrl { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Phone { get; set; }
        [Column(TypeName = "text")]
        public string Bio { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Nationality { get; set; }
        public Int64 CreatedDate { get; set; }
        public int FollowersCount { get; set; }

    }
}