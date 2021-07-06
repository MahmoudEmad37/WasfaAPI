using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class UserAll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string Nationality { get; set; }
        public Int64 CreatedDate { get; set; }
        public int FollowersCount { get; set; }
        public List<FollowingAll> Followings { get; set; }
        //public List<FavoriteAll> Favorites { get; set; }
        //public List<RatingAll>Ratings { get; set; }
        //public List<ReviewforUser> Reviews { get; set; }
        //public List<int> MyRecipes { get; set; }
        public List<LinkAll>Links  { get; set; }

        public UserAll(int id, string name, string email, string password, string gender, string imageUrl, string phone, string bio, string nationality, Int64 createdDate, int followersCount, List<FollowingAll> followings, /*List<FavoriteAll> favorites, List<RatingAll> ratings, List<ReviewforUser> reviews, List<int> myRecipes,*/ List<LinkAll> links)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Gender = gender;
            ImageUrl = imageUrl;
            Phone = phone;
            Bio = bio;
            Nationality = nationality;
            CreatedDate = createdDate;
            FollowersCount = followersCount;
            Followings = followings;
            //Favorites = favorites;
            //Ratings = ratings;
            //Reviews = reviews;
            //MyRecipes = myRecipes;
            Links = links;
        }
    }
}