using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{

    public class RecipeAll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public string Nationality { get; set; }
        public long CreatedDate { get; set; }
        public string PrepareTime { get; set; }
        public int LoveCount { get; set; }
        public int ShareCount { get; set; }
        public int ReviewsCount { get; set; }
        public double ReviewsRateTotal { get; set; }
        public string Privacy { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public List<ReviewAll> Reviews { get; set; }
        public List<Category> Categories { get; set; }
        public List<string> ImagesUrls { get; set; }

        public RecipeAll(int id, string title, string description, string ingredients, string steps, string nationality, long createdDate, string prepareTime, int loveCount, int shareCount, int reviewsCount, double reviewsRateTotal, string privacy, int userId, string userName, string userImageUrl, List<ReviewAll> reviews, List<Category> categories, List<string> imagesUrls)
        {
            Id = id;
            Title = title;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
            Nationality = nationality;
            CreatedDate = createdDate;
            PrepareTime = prepareTime;
            LoveCount = loveCount;
            ShareCount = shareCount;
            ReviewsCount = reviewsCount;
            ReviewsRateTotal = reviewsRateTotal;
            Privacy = privacy;
            UserId = userId;
            UserName = userName;
            UserImageUrl = userImageUrl;
            Reviews = reviews;
            Categories = categories;
            ImagesUrls = imagesUrls;
        }
    }

}