using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class userObjects
    {
        public List<UserAll> Users { get; set; }

        public userObjects(List<UserAll> users)
        {
            Users = users;
        }

    }
    public class recipeObject
    {
        public List<RecipeAll> Recipe { get; set; }

        public recipeObject(List<RecipeAll> recipe)
        {
            Recipe = recipe;
        }

    }
    //public class LinksObject
    //{
    //    public List<string> Links { get; set; }

    //    public LinksObject(List<string> links)
    //    {
    //        Links = links;
    //    }

    //}
}

