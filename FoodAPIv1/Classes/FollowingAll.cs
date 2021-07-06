using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class FollowingAll
    {
        public int Id { get; set; }
        public int FollowingId { get; set; }
        public string FollowingName { get; set; }
        public string FollowingImage { get; set; }

        public FollowingAll(int id, int followingId, string followingName, string followingImage)
        {
            Id = id;
            FollowingId = followingId;
            FollowingName = followingName;
            FollowingImage = followingImage;
        }
    }
}