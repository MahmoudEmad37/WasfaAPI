using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fluent.Infrastructure.FluentModel;
using FoodAPIv1.Models;
using FoodAPIv1.Classes;

namespace FoodAPIv1.Controllers
{
    /// <summary>
    /// All Operations for Users
    /// </summary>
    public class UsersController : ApiController
    {
        /// <summary>
        /// Return List of Details of All Users
        /// </summary>
        /// <returns>List of Details of All Users</returns>
        public userObjects Get()
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<UserAll> userAlls = new List<UserAll>();

                entities.Configuration.ProxyCreationEnabled = false;

                List<User> users = entities.Users.ToList();
                List<Following> followings = entities.Followings.ToList();
                //List<Favorite> favorites = entities.Favorites.ToList();
                //List<Rating> ratings = entities.Ratings.ToList();
                //List<Review> reviews = entities.Reviews.ToList();
                //List<Recipe> recipes = entities.Recipes.ToList();
                List<Link> links = entities.Links.ToList();
                for (int i=0;i<users.Count;i++)
                {
                    List<FollowingAll> followingAlls = new List<FollowingAll>();
                    //List<FavoriteAll> favoriteAlls = new List<FavoriteAll>();
                    //List<RatingAll> ratingAlls = new List<RatingAll>();
                    //List<ReviewforUser> reviewsforUsers = new List<ReviewforUser>();
                    //List<int> myRecipes = new List<int>();
                    List<LinkAll> linkAlls = new List<LinkAll>();

                    for (int j=0;j<followings.Count;j++)
                    {
                        if(users[i].Id==followings[j].UserId)
                        {
                            for(int k=0;k<users.Count;k++)
                            {
                                if(followings[j].FollowerId==users[k].Id)
                                {
                                    FollowingAll followingAll = new FollowingAll(followings[j].Id, users[k].Id, users[k].Name, users[k].ImageUrl);
                                    followingAlls.Add(followingAll);
                                }
                            }
                        }
                    }
                    //for (int x=0;x<favorites.Count;x++)
                    //{
                    //    if(users[i].Id==favorites[x].UserId)
                    //    {
                    //        FavoriteAll favoriteAll = new FavoriteAll(favorites[x].Id, favorites[x].RecipeId);
                    //        favoriteAlls.Add(favoriteAll);
                    //    }
                    //}
                    //for (int y=0;y<ratings.Count;y++)
                    //{
                    //    if (users[i].Id == ratings[y].UserId)
                    //    {
                    //        long rateDate = ((DateTime)ratings[y].CreatedData).Date.Ticks;
                    //        RatingAll ratingAll = new RatingAll(ratings[y].Id, ratings[y].RecipeId, (int)ratings[y].RatingNum, rateDate);
                    //        ratingAlls.Add(ratingAll);
                    //    }
                    //}
                    //for (int z = 0; z < reviews.Count; z++)
                    //{
                    //    if (users[i].Id == reviews[z].UserId)
                    //    {
                    //        long reviewDate = ((DateTime)reviews[z].CreatedData).Date.Ticks;
                    //        ReviewforUser reviewforUser = new ReviewforUser(reviews[z].Id, reviews[z].RecipeId, reviews[z].ReviewText, (bool)reviews[z].ReviewResult, reviewDate);
                    //        reviewsforUsers.Add(reviewforUser);
                    //    }
                    //}
                    //for (int m = 0; m < recipes.Count; m++)
                    //{
                    //    if (users[i].Id == recipes[m].UserId)
                    //    {
                    //        myRecipes.Add(recipes[m].Id);
                    //    }
                    //}
                    for (int n = 0; n < links.Count; n++)
                   {
                        if (users[i].Id == links[n].UserId)
                        {
                            LinkAll linkAll = new LinkAll(links[n].Id, links[n].Link1);
                            linkAlls.Add(linkAll);
                        }
                    }

                    //long creatDate = ((DateTime)users[i].CreatedDate).Date.Ticks;
                    UserAll userAll = new UserAll(users[i].Id, users[i].Name,
                        users[i].Email, users[i].Password, users[i].Gender,
                        users[i].ImageUrl, users[i].Phone, users[i].Bio, users[i].Nationality,
                        (Int64)users[i].CreatedDate, (int)users[i].FollowersCount, followingAlls,/* favoriteAlls,
                        ratingAlls, reviewsforUsers, myRecipes,*/ linkAlls);

                    userAlls.Add(userAll);
                }

                return new userObjects(userAlls);
            }
        }

        /// <summary>
        /// Check if User is Exist by Email or Phone for Registration
        /// </summary>
        /// <param name="userIdentity">Mandatory</param>
        /// <returns>Specific User If Found</returns>
        [Route("api/UsersByIdentity/{userIdentity}")]
        public userObjects Get(string userIdentity)
        {
            bool email = false;
            bool found = false;
            if(userIdentity.Contains("@"))
            {
                email = true;
            }
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<UserAll> userAlls = new List<UserAll>();

                entities.Configuration.ProxyCreationEnabled = false;

                List<User> users = entities.Users.ToList();
                List<Following> followings = entities.Followings.ToList();
                List<Link> links = entities.Links.ToList();
                for (int i = 0; i < users.Count; i++)
                {
                    if(email)
                    {
                        if(users[i].Email.Equals(userIdentity))
                        {
                            found = true;
                        }
                    }
                    else
                    {
                        if (users[i].Phone.Equals(userIdentity))
                        {
                            found = true;
                        }
                    }
                    if(found)
                    {
                        List<FollowingAll> followingAlls = new List<FollowingAll>();
                        List<LinkAll> linkAlls = new List<LinkAll>();

                        for (int j = 0; j < followings.Count; j++)
                        {
                            if (users[i].Id == followings[j].UserId)
                            {
                                for (int k = 0; k < users.Count; k++)
                                {
                                    if (followings[j].FollowerId == users[k].Id)
                                    {
                                        FollowingAll followingAll = new FollowingAll(followings[j].Id, users[k].Id, users[k].Name, users[k].ImageUrl);
                                        followingAlls.Add(followingAll);
                                    }
                                }
                            }
                        }
                        for (int n = 0; n < links.Count; n++)
                        {
                            if (users[i].Id == links[n].UserId)
                            {
                                LinkAll linkAll = new LinkAll(links[n].Id, links[n].Link1);
                                linkAlls.Add(linkAll);
                            }
                        }

                        UserAll userAll = new UserAll(users[i].Id, users[i].Name,
                        users[i].Email, users[i].Password, users[i].Gender,
                        users[i].ImageUrl, users[i].Phone, users[i].Bio, users[i].Nationality,
                        (Int64)users[i].CreatedDate, (int)users[i].FollowersCount, followingAlls, linkAlls);

                        userAlls.Add(userAll);
                        return new userObjects(userAlls);
                    }
                }
                return new userObjects(userAlls);
            }
        }

        /// <summary>
        /// Return Specific User by Id
        /// </summary>
        /// <param name="userId">Mandatory</param>
        /// <returns>Specific User by Id</returns>
        [Route("api/UsersById/{userId}")]
        public userObjects GetById(int userId)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<UserAll> userAlls = new List<UserAll>();

                entities.Configuration.ProxyCreationEnabled = false;

                List<User> users = entities.Users.ToList();
                List<Following> followings = entities.Followings.ToList();
                List<Link> links = entities.Links.ToList();
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Id==userId)
                    {
                        List<FollowingAll> followingAlls = new List<FollowingAll>();
                        List<LinkAll> linkAlls = new List<LinkAll>();

                        for (int j = 0; j < followings.Count; j++)
                        {
                            if (users[i].Id == followings[j].UserId)
                            {
                                for (int k = 0; k < users.Count; k++)
                                {
                                    if (followings[j].FollowerId == users[k].Id)
                                    {
                                        FollowingAll followingAll = new FollowingAll(followings[j].Id, users[k].Id, users[k].Name, users[k].ImageUrl);
                                        followingAlls.Add(followingAll);
                                    }
                                }
                            }
                        }
                        for (int n = 0; n < links.Count; n++)
                        {
                            if (users[i].Id == links[n].UserId)
                            {
                                LinkAll linkAll = new LinkAll(links[n].Id, links[n].Link1);
                                linkAlls.Add(linkAll);
                            }
                        }

                        UserAll userAll = new UserAll(users[i].Id, users[i].Name,
                        users[i].Email, users[i].Password, users[i].Gender,
                        users[i].ImageUrl, users[i].Phone, users[i].Bio, users[i].Nationality,
                        (Int64)users[i].CreatedDate, (int)users[i].FollowersCount, followingAlls, /*favoriteAlls,
                        ratingAlls, reviewsforUsers, myRecipes,*/ linkAlls);

                        userAlls.Add(userAll);
                        return new userObjects(userAlls);
                    }
                }
                return new userObjects(userAlls);
            }
        }

        /// <summary>
        /// Search for Users Contain Identity in Username or Email or Phone
        /// </summary>
        /// <param name="Identity">Mandatory</param>
        /// <returns>Specific User If Found</returns>
        [Route("api/UsersSearch/{Identity}")]
        public userObjects GetSearch(string Identity)
        {
            Identity = Identity.ToLower();
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<UserAll> userAlls = new List<UserAll>();

                entities.Configuration.ProxyCreationEnabled = false;

                List<User> users = entities.Users.ToList();
                List<Following> followings = entities.Followings.ToList();
                List<Link> links = entities.Links.ToList();
                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Name != null && users[i].Name.ToLower().Contains(Identity)) || (users[i].Email != null && users[i].Email.ToLower().Contains(Identity))
                        || (users[i].Phone != null && users[i].Phone.ToLower().Contains(Identity)))
                    {
                        List<FollowingAll> followingAlls = new List<FollowingAll>();
                        List<LinkAll> linkAlls = new List<LinkAll>();

                        for (int j = 0; j < followings.Count; j++)
                        {
                            if (users[i].Id == followings[j].UserId)
                            {
                                for (int k = 0; k < users.Count; k++)
                                {
                                    if (followings[j].FollowerId == users[k].Id)
                                    {
                                        FollowingAll followingAll = new FollowingAll(followings[j].Id, users[k].Id, users[k].Name, users[k].ImageUrl);
                                        followingAlls.Add(followingAll);
                                    }
                                }
                            }
                        }
                        for (int n = 0; n < links.Count; n++)
                        {
                            if (users[i].Id == links[n].UserId)
                            {
                                LinkAll linkAll = new LinkAll(links[n].Id, links[n].Link1);
                                linkAlls.Add(linkAll);
                            }
                        }

                        UserAll userAll = new UserAll(users[i].Id, users[i].Name,
                        users[i].Email, users[i].Password, users[i].Gender,
                        users[i].ImageUrl, users[i].Phone, users[i].Bio, users[i].Nationality,
                        (Int64)users[i].CreatedDate, (int)users[i].FollowersCount, followingAlls, linkAlls);

                        userAlls.Add(userAll);
                    }
                }
                return new userObjects(userAlls);
            }
        }

        /// <summary>
        /// User Registration
        /// </summary>
        /// <param name="user">Mandatory</param>
        /// <returns>Message for Successful or Faild Registration</returns>
        public Found Post([FromBody]User user)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<User> users = entities.Users.ToList();
                for (int i = 0; i < users.Count; i++)
                {
                    if(users[i].Email.Equals(user.Email))
                    {
                        return new Found("Invalid Email");
                    }
                    else if(users[i].Phone.Equals(user.Phone))
                    {
                        return new Found("Invalid Phone");
                    }

                }
                entities.Users.Add(user);
                entities.SaveChanges();
                userObjects xx = Get(user.Email);
                Link x = new Link();
                x.Id = 0;x.Link1 = user.Links[0];x.UserId = xx.Users[0].Id;
                entities.Links.Add(x);
                entities.SaveChanges();
                x.Link1 = user.Links[1];
                entities.Links.Add(x);
                entities.SaveChanges();
                x.Link1 = user.Links[2];
                entities.Links.Add(x);
                entities.SaveChanges();
                return new Found("Successful Registration");
            }
        }

        /// <summary>
        /// Update Existing User
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <param name="user">Mandatory</param>
        public void Put(int id, [FromBody] User user)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent = entities.Users.FirstOrDefault(e => e.Id == id);
                ent.Id = user.Id;
                ent.Name = user.Name;
                ent.Email = user.Email;
                ent.Password = user.Password;
                ent.Gender = user.Gender;
                ent.ImageUrl = user.ImageUrl;
                ent.Phone = user.Phone;
                ent.Bio = user.Bio;
                ent.Nationality = user.Nationality;
                ent.CreatedDate = user.CreatedDate;
                ent.FollowersCount = user.FollowersCount;
                entities.SaveChanges();
                
                List<LinkAll> linkAlls = new List<LinkAll>();
                List<Link> links = entities.Links.ToList();

                for (int n = 0; n < links.Count; n++)
                {
                    if (ent.Id == links[n].UserId)
                    {
                        LinkAll linkAll = new LinkAll(links[n].Id, links[n].Link1);
                        linkAlls.Add(linkAll);
                    }
                }

                for(int i=0;i<linkAlls.Count;i++)
                {
                    int y = linkAlls[i].Id;
                    var entlink = entities.Links.FirstOrDefault(e => e.Id == y);
                    entlink.Link1 = user.Links[i];
                    entities.SaveChanges();
                }


            }
        }

        /// <summary>
        /// User Follow Other User
        /// </summary>
        /// <param name="foll">Mandatory</param>
        [Route("api/UsersPostFollowing")]
        public void PostFollowing([FromBody]Following foll)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent2 = entities.Users.FirstOrDefault(e => e.Id == foll.FollowerId);
                ent2.FollowersCount = ent2.FollowersCount + 1;
                entities.SaveChanges();

                entities.Followings.Add(foll);
                entities.SaveChanges();

                //User u = new User();
                //u.Id = foll.UserId;

                //u.Name = ent2.Name;
                //u.Email = ent2.Email;
                //u.Password = ent2.Password;
                //u.Gender = ent2.Gender;
                //u.ImageUrl = ent2.ImageUrl;
                //u.Phone = ent2.Phone;
                //u.Bio = ent2.Bio;
                //u.Nationality = ent2.Nationality;
                //u.CreatedDate = ent2.CreatedDate;
                //u.FollowersCount = ent2.FollowersCount + 1;
                //Put(u.Id, u);
                //entities.Followings.Add(foll);
                //entities.SaveChanges();

            }
        }
        //[Route("api/UsersPostLink")]
        //public void PostLink([FromBody]Link link)
        //{
        //    using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
        //    {
        //        entities.Links.Add(link);
        //        entities.SaveChanges();

        //    }
        //}
        ////public void PutFollowing(int id, [FromBody] Following foll)
        ////{
        ////    using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
        ////    {
        ////        var ent = entities.Followings.FirstOrDefault(e => e.Id == id);
        ////        ent.Id = foll.Id;
        ////        ent.UserId = foll.UserId;
        ////        ent.FollowerId = foll.FollowerId;
        ////        entities.SaveChanges();
        ////    }
        ////}
        //[Route("api/UsersPutLink/{id}")]
        //public void PutLink(int id, [FromBody] Link link)
        //{
        //    using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
        //    {
        //        var ent = entities.Links.FirstOrDefault(e => e.Id == id);
        //        ent.Id = link.Id;
        //        ent.Link1 = link.Link1;
        //        ent.UserId = link.UserId;
        //        entities.SaveChanges();
        //    }
        //}

        //[Route("api/UsersPostFavourite")]
        //public void PostFavourite([FromBody]Favorite fav)
        //{
        //    using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
        //    {
        //        entities.Favorites.Add(fav);
        //        entities.SaveChanges();

        //    }
        //}

        //[Route("api/UsersPostRecipeImage")]
        //public void PostRecipeImage([FromBody]RecipeImage img)
        //{
        //    using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
        //    {
        //        entities.RecipeImages.Add(img);
        //        entities.SaveChanges();

        //    }
        //}
        //[Route("api/UsersDeleteRecipeImage/{id}")]
        //public void deleteRecipeImage(int id)
        //{
        //    using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
        //    {
        //        var ent = entities.RecipeImages.FirstOrDefault(e => e.Id == id);
        //        entities.Entry(ent).State = System.Data.Entity.EntityState.Deleted;

        //        entities.SaveChanges();
        //    }
        //}

        /// <summary>
        /// User Follow Specific User
        /// </summary>
        /// <param name="id">Mandatory</param>
        [Route("api/UsersDeleteFollowing/{id}")]
        public void deleteFollowing(int id)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent = entities.Followings.FirstOrDefault(e => e.Id == id);
                var ent2 = entities.Users.FirstOrDefault(e => e.Id == ent.FollowerId);
                ent2.FollowersCount = ent2.FollowersCount - 1;
                entities.SaveChanges();

                entities.Entry(ent).State = System.Data.Entity.EntityState.Deleted;

                entities.SaveChanges();
            }
        }

        /// <summary>
        /// User Delete his Socialmedia Accounts
        /// </summary>
        /// <param name="id">Mandatory</param>
        [Route("api/UsersDeleteLink/{id}")]
        public void deleteLink(int id)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent = entities.Links.FirstOrDefault(e => e.Id == id);
                entities.Entry(ent).State = System.Data.Entity.EntityState.Deleted;

                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Existing User Account
        /// </summary>
        /// <param name="id">Mandatory</param>
        public void delete(int id)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent = entities.Users.FirstOrDefault(e => e.Id == id);
                entities.Entry(ent).State = System.Data.Entity.EntityState.Deleted;
                var ent2 = entities.Favorites.ToList();
                for (int i = 0; i < ent2.Count; i++)
                {
                    if (ent2[i].UserId == id)
                    {
                        entities.Entry(ent2[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }
                var ent3 = entities.Followings.ToList();
                for (int i = 0; i < ent3.Count; i++)
                {
                    if (ent3[i].UserId == id)
                    {
                        entities.Entry(ent3[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }
                var ent4 = entities.Links.ToList();
                for (int i = 0; i < ent4.Count; i++)
                {
                    if (ent4[i].UserId == id)
                    {
                        entities.Entry(ent4[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }
                var ent5 = entities.Ratings.ToList();
                for (int i = 0; i < ent5.Count; i++)
                {
                    if (ent5[i].UserId == id)
                    {
                        entities.Entry(ent5[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }
                RecipesController rc = new RecipesController();
                var ent6 = entities.Recipes.ToList();
                for (int i = 0; i < ent6.Count; i++)
                {
                    if (ent6[i].UserId == id)
                    {
                        rc.Delete(ent6[i].Id);
                        entities.SaveChanges();
                    }
                }
                var ent7 = entities.Reviews.ToList();
                for (int i = 0; i < ent7.Count; i++)
                {
                    if (ent7[i].UserId == id)
                    {
                        entities.Entry(ent7[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }

                entities.SaveChanges();
            }

        }
    }
}