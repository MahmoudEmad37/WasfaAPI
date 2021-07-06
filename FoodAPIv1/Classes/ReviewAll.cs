using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class ReviewAll
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string ReviewText { get; set; }
        public string ReviewResult { get; set; }
        public bool IsCreator { get; set; }
        public long CreatedData { get; set; }

        public ReviewAll()
        {
        }

        public ReviewAll(int id, int userId, string userName, string userImage, string reviewText, string reviewResult, bool isCreator, long createdData)
        {
            Id = id;
            UserId = userId;
            UserName = userName;
            UserImage = userImage;
            ReviewText = reviewText;
            ReviewResult = reviewResult;
            IsCreator = isCreator;
            CreatedData = createdData;
        }
    }
}