using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fluent.Infrastructure.FluentModel;
using FoodAPIv1.Models;
using FoodAPIv1.Classes;
using FoodAPIv1.Controllers;

namespace FoodAPIv1.Controllers
{
    /// <summary>
    /// All Operations for Recipes
    /// </summary>
    public class RecipesController : ApiController
    {
        /// <summary>
        /// Return List of Details of All Recipes
        /// </summary>
        /// <returns>List of Details of All Recipes</returns>
        public recipeObject Get()
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<RecipeAll> recipeAlls = new List<RecipeAll>();

                entities.Configuration.ProxyCreationEnabled = false;
                List<Recipe> recipes = entities.Recipes.ToList();
                List<User> users = entities.Users.ToList();
                List<Review> reviews = entities.Reviews.ToList();
                List<Category> categories = entities.Categories.ToList();
                List<CateRecipe> cateRecipes = entities.CateRecipes.ToList();
                List<RecipeImage> recipeImage = entities.RecipeImages.ToList();
                for (int i=0; i<recipes.Count;i++)
                {
       
                    List<ReviewAll> reviewAlls = new List<ReviewAll>();
                    List<Category> categoryAlls = new List<Category>();
                    List<string> imageUrlAlls = new List<string>();
                    string userName = ""; 
                    string userImageUrl="";
                   
                    for (int j=0;j< users.Count;j++)
                    {
                        if(recipes[i].UserId== users[j].Id)
                        {
                            userName = users[j].Name;
                            userImageUrl = users[j].ImageUrl;
                            break;
                        }
                    }
                    for(int k=0;k<reviews.Count;k++)
                    {
                        
                        if (recipes[i].Id==reviews[k].RecipeId)
                        {
                            string userReview="";
                            string userImage = "";
                            for (int j = 0; j < users.Count; j++)
                            {
                                if (reviews[k].UserId == users[j].Id)
                                {
                                    userReview = users[j].Name;
                                    userImage = users[j].ImageUrl;
                                    break;
                                }
                            }
                            ReviewAll tmp = new ReviewAll(reviews[k].Id, reviews[k].UserId,userReview,userImage, reviews[k].ReviewText,reviews[k].ReviewResult,(bool)reviews[k].IsCreator,(long)reviews[k].CreatedData);
                            reviewAlls.Add(tmp);
                        }
                    }
                    for(int x=0;x<cateRecipes.Count;x++)
                    {
                        if(recipes[i].Id==cateRecipes[x].RecipeId)
                        {
                            for(int y=0;y<categories.Count;y++)
                            {
                                if(cateRecipes[x].CategoryId==categories[y].Id)
                                {
                                    Category ctmp = new Category();
                                    ctmp.Id = categories[y].Id;
                                    ctmp.Title = categories[y].Title;
                                    categoryAlls.Add(ctmp);
                                    break;
                                }
                            }
                        }
                    }
                    for(int z=0;z<recipeImage.Count;z++)
                    {
                        if(recipes[i].Id==recipeImage[z].RecipeId)
                        {
                            imageUrlAlls.Add(recipeImage[z].ImageUrl);
                        }
                    }

                    RecipeAll recipeAll = new RecipeAll(recipes[i].Id, recipes[i].Title, recipes[i].Description, recipes[i].Ingredients, recipes[i].Steps, recipes[i].Nationality, (long)recipes[i].CreatedDate, recipes[i].PrepareTime, (int)recipes[i].LoveCount, (int)recipes[i].ShareCount, (int)recipes[i].ReviewsCount, (double)recipes[i].ReviewsRateTotal,recipes[i].Privacy, recipes[i].UserId,
                        userName, userImageUrl, reviewAlls, categoryAlls, imageUrlAlls);
                    recipeAlls.Add(recipeAll);
                }
                return new recipeObject(recipeAlls);
            }
        }

        /// <summary>
        /// Return List of Details of All Recipes for Specific User
        /// </summary>
        /// <param name="userId">Mandatory</param>
        /// <returns>List of Details of All Recipes for Specific User</returns>
        [Route("api/RecipeByUserId/{userId}")]
        public recipeObject Get(int userId)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<RecipeAll> recipeAlls = new List<RecipeAll>();

                entities.Configuration.ProxyCreationEnabled = false;
                List<Recipe> recipes = entities.Recipes.ToList();
                List<User> users = entities.Users.ToList();
                List<Review> reviews = entities.Reviews.ToList();
                List<Category> categories = entities.Categories.ToList();
                List<CateRecipe> cateRecipes = entities.CateRecipes.ToList();
                List<RecipeImage> recipeImage = entities.RecipeImages.ToList();
                for (int i = 0; i < recipes.Count; i++)
                {
                    if(recipes[i].UserId==userId)
                    {
                        List<ReviewAll> reviewAlls = new List<ReviewAll>();
                        List<Category> categoryAlls = new List<Category>();
                        List<string> imageUrlAlls = new List<string>();
                        string userName = "";
                        string userImageUrl = "";

                        for (int j = 0; j < users.Count; j++)
                        {
                            if (recipes[i].UserId == users[j].Id)
                            {
                                userName = users[j].Name;
                                userImageUrl = users[j].ImageUrl;
                                break;
                            }
                        }
                        for (int k = 0; k < reviews.Count; k++)
                        {

                            if (recipes[i].Id == reviews[k].RecipeId)
                            {
                                string userReview = "";
                                string userImage = "";
                                for (int j = 0; j < users.Count; j++)
                                {
                                    if (reviews[k].UserId == users[j].Id)
                                    {
                                        userReview = users[j].Name;
                                        userImage = users[j].ImageUrl;
                                        break;
                                    }
                                }
                                ReviewAll tmp = new ReviewAll(reviews[k].Id, reviews[k].UserId, userReview, userImage, reviews[k].ReviewText, reviews[k].ReviewResult, (bool)reviews[k].IsCreator, (long)reviews[k].CreatedData);
                                reviewAlls.Add(tmp);
                            }
                        }
                        for (int x = 0; x < cateRecipes.Count; x++)
                        {
                            if (recipes[i].Id == cateRecipes[x].RecipeId)
                            {
                                for (int y = 0; y < categories.Count; y++)
                                {
                                    if (cateRecipes[x].CategoryId == categories[y].Id)
                                    {
                                        Category ctmp = new Category();
                                        ctmp.Id = categories[y].Id;
                                        ctmp.Title = categories[y].Title;
                                        categoryAlls.Add(ctmp);
                                        break;
                                    }
                                }
                            }
                        }
                        for (int z = 0; z < recipeImage.Count; z++)
                        {
                            if (recipes[i].Id == recipeImage[z].RecipeId)
                            {
                                imageUrlAlls.Add(recipeImage[z].ImageUrl);
                            }
                        }

                        RecipeAll recipeAll = new RecipeAll(recipes[i].Id, recipes[i].Title, recipes[i].Description, recipes[i].Ingredients, recipes[i].Steps, recipes[i].Nationality, (long)recipes[i].CreatedDate, recipes[i].PrepareTime, (int)recipes[i].LoveCount, (int)recipes[i].ShareCount, (int)recipes[i].ReviewsCount, (double)recipes[i].ReviewsRateTotal, recipes[i].Privacy, recipes[i].UserId,
                            userName, userImageUrl, reviewAlls, categoryAlls, imageUrlAlls);
                        
                        recipeAlls.Add(recipeAll);

                    }
                }
                return new recipeObject(recipeAlls);
            }
        }

        /// <summary>
        /// Return List of Details of number of Recipes
        /// </summary>
        /// <param name="number">Mandatory</param>
        /// <returns>List of Details of number of Recipes</returns>
        [Route("api/SomeRecipe/{number}")]
        public recipeObject GetSomeRecipes(int number)
        {
            int num = (number - 1) * 10;
            List<RecipeAll> recipeAlls = new List<RecipeAll>();
            if (num >= 0)
            {
                using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
                {
                    List<Recipe> recipes = entities.Recipes.ToList();
                    if (num < recipes.Count)
                    {
                        int count;
                        if (recipes.Count - num > 10)
                        {
                            count = 10;
                        }
                        else
                        {
                            count = recipes.Count;
                        }

                        entities.Configuration.ProxyCreationEnabled = false;
                        List<User> users = entities.Users.ToList();
                        List<Review> reviews = entities.Reviews.ToList();
                        List<Category> categories = entities.Categories.ToList();
                        List<CateRecipe> cateRecipes = entities.CateRecipes.ToList();
                        List<RecipeImage> recipeImage = entities.RecipeImages.ToList();
                        for (int i = num; i < count; i++)
                        {

                            List<ReviewAll> reviewAlls = new List<ReviewAll>();
                            List<Category> categoryAlls = new List<Category>();
                            List<string> imageUrlAlls = new List<string>();
                            string userName = "";
                            string userImageUrl = "";

                            for (int j = 0; j < users.Count; j++)
                            {
                                if (recipes[i].UserId == users[j].Id)
                                {
                                    userName = users[j].Name;
                                    userImageUrl = users[j].ImageUrl;
                                    break;
                                }
                            }
                            for (int k = 0; k < reviews.Count; k++)
                            {

                                if (recipes[i].Id == reviews[k].RecipeId)
                                {
                                    string userReview = "";
                                    string userImage = "";
                                    for (int j = 0; j < users.Count; j++)
                                    {
                                        if (reviews[k].UserId == users[j].Id)
                                        {
                                            userReview = users[j].Name;
                                            userImage = users[j].ImageUrl;
                                            break;
                                        }
                                    }
                                    ReviewAll tmp = new ReviewAll(reviews[k].Id, reviews[k].UserId, userReview, userImage, reviews[k].ReviewText, reviews[k].ReviewResult, (bool)reviews[k].IsCreator, (long)reviews[k].CreatedData);
                                    reviewAlls.Add(tmp);
                                }
                            }
                            for (int x = 0; x < cateRecipes.Count; x++)
                            {
                                if (recipes[i].Id == cateRecipes[x].RecipeId)
                                {
                                    for (int y = 0; y < categories.Count; y++)
                                    {
                                        if (cateRecipes[x].CategoryId == categories[y].Id)
                                        {
                                            Category ctmp = new Category();
                                            ctmp.Id = categories[y].Id;
                                            ctmp.Title = categories[y].Title;
                                            categoryAlls.Add(ctmp);
                                            break;
                                        }
                                    }
                                }
                            }
                            for (int z = 0; z < recipeImage.Count; z++)
                            {
                                if (recipes[i].Id == recipeImage[z].RecipeId)
                                {
                                    imageUrlAlls.Add(recipeImage[z].ImageUrl);
                                }
                            }

                            RecipeAll recipeAll = new RecipeAll(recipes[i].Id, recipes[i].Title, recipes[i].Description, recipes[i].Ingredients, recipes[i].Steps, recipes[i].Nationality, (long)recipes[i].CreatedDate, recipes[i].PrepareTime, (int)recipes[i].LoveCount, (int)recipes[i].ShareCount, (int)recipes[i].ReviewsCount, (double)recipes[i].ReviewsRateTotal, recipes[i].Privacy, recipes[i].UserId,
                                userName, userImageUrl, reviewAlls, categoryAlls, imageUrlAlls);
                            recipeAlls.Add(recipeAll);
                        }
                        return new recipeObject(recipeAlls);
                    }
                }
            }
            return new recipeObject(recipeAlls);
        }

        /// <summary>
        /// Return List of Details of number of Commen Recipes
        /// </summary>
        /// <param name="number">Mandatory</param>
        /// <returns>List of Details of number of Commen Recipes</returns>
        [Route("api/CommenRecipe/{number}")]
        public recipeObject GetCommenRecipes(int number)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<RecipeAll> recipeAlls = new List<RecipeAll>();

                entities.Configuration.ProxyCreationEnabled = false;
                List<Recipe> recipes = entities.Recipes.ToList();
                List<User> users = entities.Users.ToList();
                List<Review> reviews = entities.Reviews.ToList();
                List<Category> categories = entities.Categories.ToList();
                List<CateRecipe> cateRecipes = entities.CateRecipes.ToList();
                List<RecipeImage> recipeImage = entities.RecipeImages.ToList();
                for (int i = 0; i < recipes.Count; i++)
                {

                    List<ReviewAll> reviewAlls = new List<ReviewAll>();
                    List<Category> categoryAlls = new List<Category>();
                    List<string> imageUrlAlls = new List<string>();
                    string userName = "";
                    string userImageUrl = "";

                    for (int j = 0; j < users.Count; j++)
                    {
                        if (recipes[i].UserId == users[j].Id)
                        {
                            userName = users[j].Name;
                            userImageUrl = users[j].ImageUrl;
                            break;
                        }
                    }
                    for (int k = 0; k < reviews.Count; k++)
                    {

                        if (recipes[i].Id == reviews[k].RecipeId)
                        {
                            string userReview = "";
                            string userImage = "";
                            for (int j = 0; j < users.Count; j++)
                            {
                                if (reviews[k].UserId == users[j].Id)
                                {
                                    userReview = users[j].Name;
                                    userImage = users[j].ImageUrl;
                                    break;
                                }
                            }
                            ReviewAll tmp = new ReviewAll(reviews[k].Id, reviews[k].UserId, userReview, userImage, reviews[k].ReviewText, reviews[k].ReviewResult, (bool)reviews[k].IsCreator, (long)reviews[k].CreatedData);
                            reviewAlls.Add(tmp);
                        }
                    }
                    for (int x = 0; x < cateRecipes.Count; x++)
                    {
                        if (recipes[i].Id == cateRecipes[x].RecipeId)
                        {
                            for (int y = 0; y < categories.Count; y++)
                            {
                                if (cateRecipes[x].CategoryId == categories[y].Id)
                                {
                                    Category ctmp = new Category();
                                    ctmp.Id = categories[y].Id;
                                    ctmp.Title = categories[y].Title;
                                    categoryAlls.Add(ctmp);
                                    break;
                                }
                            }
                        }
                    }
                    for (int z = 0; z < recipeImage.Count; z++)
                    {
                        if (recipes[i].Id == recipeImage[z].RecipeId)
                        {
                            imageUrlAlls.Add(recipeImage[z].ImageUrl);
                        }
                    }

                    RecipeAll recipeAll = new RecipeAll(recipes[i].Id, recipes[i].Title, recipes[i].Description, recipes[i].Ingredients, recipes[i].Steps, recipes[i].Nationality, (long)recipes[i].CreatedDate, recipes[i].PrepareTime, (int)recipes[i].LoveCount, (int)recipes[i].ShareCount, (int)recipes[i].ReviewsCount, (double)recipes[i].ReviewsRateTotal, recipes[i].Privacy, recipes[i].UserId,
                        userName, userImageUrl, reviewAlls, categoryAlls, imageUrlAlls);
                    recipeAlls.Add(recipeAll);
                }
                List<RecipeAll> sortedRecipeAlls=recipeAlls.OrderByDescending(x => x.ReviewsRateTotal).ToList().Take(number).ToList();
                return new recipeObject(sortedRecipeAlls);
            }
        }

        /// <summary>
        /// Search for Recipes Contain Identity in Title or Description or Ingredients or Categories
        /// </summary>
        /// <param name="Identity">Mandatory</param>
        /// <returns>List of Recipes Contain Identity in Title or Description or Ingredients or Categories</returns>
        [Route("api/RecipesSearch/{Identity}")]
        public recipeObject Get(string Identity)
        {
            Identity = Identity.ToLower();
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<RecipeAll> recipeAlls = new List<RecipeAll>();

                entities.Configuration.ProxyCreationEnabled = false;
                List<Recipe> recipes = entities.Recipes.ToList();
                List<User> users = entities.Users.ToList();
                List<Review> reviews = entities.Reviews.ToList();
                List<Category> categories = entities.Categories.ToList();
                List<CateRecipe> cateRecipes = entities.CateRecipes.ToList();
                List<RecipeImage> recipeImage = entities.RecipeImages.ToList();
                for (int i = 0; i < recipes.Count; i++)
                {
                    List<ReviewAll> reviewAlls = new List<ReviewAll>();
                    List<Category> categoryAlls = new List<Category>();
                    List<string> imageUrlAlls = new List<string>();
                    string userName = "";
                    string userImageUrl = "";

                    for (int j = 0; j < users.Count; j++)
                    {
                        if (recipes[i].UserId == users[j].Id)
                        {
                            userName = users[j].Name;
                            userImageUrl = users[j].ImageUrl;
                            break;
                        }
                    }
                    for (int k = 0; k < reviews.Count; k++)
                    {

                        if (recipes[i].Id == reviews[k].RecipeId)
                        {
                            string userReview = "";
                            string userImage = "";
                            for (int j = 0; j < users.Count; j++)
                            {
                                if (reviews[k].UserId == users[j].Id)
                                {
                                    userReview = users[j].Name;
                                    userImage = users[j].ImageUrl;
                                    break;
                                }
                            }
                            ReviewAll tmp = new ReviewAll(reviews[k].Id, reviews[k].UserId, userReview, userImage, reviews[k].ReviewText, reviews[k].ReviewResult, (bool)reviews[k].IsCreator, (long)reviews[k].CreatedData);
                            reviewAlls.Add(tmp);
                        }
                    }
                    for (int x = 0; x < cateRecipes.Count; x++)
                    {
                        if (recipes[i].Id == cateRecipes[x].RecipeId)
                        {
                            for (int y = 0; y < categories.Count; y++)
                            {
                                if (cateRecipes[x].CategoryId == categories[y].Id)
                                {
                                    Category ctmp = new Category();
                                    ctmp.Id = categories[y].Id;
                                    ctmp.Title = categories[y].Title;
                                    categoryAlls.Add(ctmp);
                                    break;
                                }
                            }
                        }
                    }
                    for (int z = 0; z < recipeImage.Count; z++)
                    {
                        if (recipes[i].Id == recipeImage[z].RecipeId)
                        {
                            imageUrlAlls.Add(recipeImage[z].ImageUrl);
                        }
                    }

                    RecipeAll recipeAll = new RecipeAll(recipes[i].Id, recipes[i].Title, recipes[i].Description, recipes[i].Ingredients, recipes[i].Steps, recipes[i].Nationality, (long)recipes[i].CreatedDate, recipes[i].PrepareTime, (int)recipes[i].LoveCount, (int)recipes[i].ShareCount, (int)recipes[i].ReviewsCount, (double)recipes[i].ReviewsRateTotal, recipes[i].Privacy, recipes[i].UserId,
                        userName, userImageUrl, reviewAlls, categoryAlls, imageUrlAlls);

                    if ((recipeAll.Title!=null&&recipeAll.Title.ToLower().Contains(Identity))|| (recipeAll.Description != null && recipeAll.Description.ToLower().Contains(Identity))
                        || (recipeAll.Ingredients != null && recipeAll.Ingredients.ToLower().Contains(Identity)))
                    {
                        recipeAlls.Add(recipeAll);
                    }
                    else
                    {
                        for(int j=0;j<recipeAll.Categories.Count;j++)
                        {
                            if(recipeAll.Categories[j].Title.ToLower().Contains(Identity))
                            {
                                recipeAlls.Add(recipeAll);
                                break;
                            }
                        }
                    }
                }
                return new recipeObject(recipeAlls);
            }
        }

        /// <summary>
        /// Create New Recipe
        /// </summary>
        /// <param name="recipe">Mandatory</param>
        public void Post([FromBody]Recipe recipe)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                entities.Recipes.Add(recipe);
                entities.SaveChanges();
                List<Recipe> recipes = entities.Recipes.ToList();
                int recipeId = recipes[recipes.Count - 1].Id;
                CateRecipe tmp = new CateRecipe();
                tmp.RecipeId = recipeId;
                for (int i=0;i<recipe.Categories.Count;i++)
                {
                    int categoryId = CategoriesController.GetByTitle(recipe.Categories[i]);
                    tmp.CategoryId = categoryId;
                    entities.CateRecipes.Add(tmp);
                    entities.SaveChanges();
                }
                RecipeImage image = new RecipeImage();
                image.RecipeId = recipeId;
                for (int i=0;i<recipe.ImagesUrls.Count;i++)
                {
                    image.ImageUrl = recipe.ImagesUrls[i]; 
                    entities.RecipeImages.Add(image);
                    entities.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Update Existing Recipe
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <param name="recipe">Mandatory</param>
        public void Put(int id, [FromBody] Recipe recipe)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent = entities.Recipes.FirstOrDefault(e => e.Id == id);
                ent.Title = recipe.Title;
                ent.Description = recipe.Description;
                ent.Nationality = recipe.Nationality;
                ent.CreatedDate = recipe.CreatedDate;
                ent.PrepareTime = recipe.PrepareTime;
                ent.LoveCount = recipe.LoveCount;
                ent.ShareCount = recipe.ShareCount;
                ent.Privacy = recipe.Privacy;
                ent.ReviewsCount = recipe.ReviewsCount;
                ent.ReviewsRateTotal = recipe.ReviewsRateTotal;
                ent.Ingredients = recipe.Ingredients;
                ent.Steps = recipe.Steps;
                ent.UserId = recipe.UserId;
                entities.SaveChanges();

            }
        }

        /// <summary>
        /// Increase Number of Lovers for Specific Recipe
        /// </summary>
        /// <param name="RecipeId">Mandatory</param>
        [Route("api/PostLove/{RecipeId}")]
        public void PostLoveCount(int RecipeId)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent1 = entities.Recipes.FirstOrDefault(e => e.Id == RecipeId);
                Recipe rec = new Recipe();
                rec.Title = ent1.Title;
                rec.Description = ent1.Description;
                rec.Nationality = ent1.Nationality;
                rec.CreatedDate = ent1.CreatedDate;
                rec.PrepareTime = ent1.PrepareTime;
                rec.LoveCount = ent1.LoveCount + 1;
                rec.ShareCount = ent1.ShareCount;
                rec.Privacy = ent1.Privacy;
                rec.ReviewsRateTotal = ent1.ReviewsRateTotal;
                rec.Ingredients = ent1.Ingredients;
                rec.Steps = ent1.Steps;
                rec.UserId = ent1.UserId;
                rec.ReviewsCount = ent1.ReviewsCount;
                Put(ent1.Id, rec);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Decrease Number of Lovers for Specific Recipe
        /// </summary>
        /// <param name="RecipeId">Mandatory</param>
        [Route("api/PostDisLove/{RecipeId}")]
        public void PostDisLoveCount(int RecipeId)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent1 = entities.Recipes.FirstOrDefault(e => e.Id == RecipeId);
                Recipe rec = new Recipe();
                rec.Title = ent1.Title;
                rec.Description = ent1.Description;
                rec.Nationality = ent1.Nationality;
                rec.CreatedDate = ent1.CreatedDate;
                rec.PrepareTime = ent1.PrepareTime;
                rec.LoveCount = ent1.LoveCount - 1;
                rec.ShareCount = ent1.ShareCount;
                rec.Privacy = ent1.Privacy;
                rec.ReviewsRateTotal = ent1.ReviewsRateTotal;
                rec.Ingredients = ent1.Ingredients;
                rec.Steps = ent1.Steps;
                rec.UserId = ent1.UserId;
                rec.ReviewsCount = ent1.ReviewsCount;
                Put(ent1.Id, rec);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Increase Number of Sharing for Specific Recipe 
        /// </summary>
        /// <param name="RecipeId">Mandatory</param>
        [Route("api/PostShare/{RecipeId}")]
        public void PostShareCount(int RecipeId)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent1 = entities.Recipes.FirstOrDefault(e => e.Id == RecipeId);
                Recipe rec = new Recipe();
                rec.Title = ent1.Title;
                rec.Description = ent1.Description;
                rec.Nationality = ent1.Nationality;
                rec.CreatedDate = ent1.CreatedDate;
                rec.PrepareTime = ent1.PrepareTime;
                rec.LoveCount = ent1.LoveCount;
                rec.ShareCount = ent1.ShareCount + 1;
                rec.Privacy = ent1.Privacy;
                rec.ReviewsRateTotal = ent1.ReviewsRateTotal;
                rec.Ingredients = ent1.Ingredients;
                rec.Steps = ent1.Steps;
                rec.UserId = ent1.UserId;
                rec.ReviewsCount = ent1.ReviewsCount;
                Put(ent1.Id, rec);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Existing Recipe
        /// </summary>
        /// <param name="id">Mandatory</param>
        public void Delete(int id)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent = entities.Recipes.FirstOrDefault(e => e.Id == id);
                entities.Entry(ent).State = System.Data.Entity.EntityState.Deleted;
                var ent2 = entities.Reviews.ToList();
                for (int i = 0; i < ent2.Count; i++)
                {
                    if (ent2[i].RecipeId == id)
                    {
                        entities.Entry(ent2[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }
                var ent3 = entities.Ratings.ToList();
                for (int i = 0; i < ent3.Count; i++)
                {
                    if (ent3[i].RecipeId == id)
                    {
                        entities.Entry(ent3[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }
                var ent4 = entities.CateRecipes.ToList();
                for (int i = 0; i < ent4.Count; i++)
                {
                    if (ent4[i].RecipeId == id)
                    {
                        entities.Entry(ent4[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }
                var ent5 = entities.Favorites.ToList();
                for (int i = 0; i < ent5.Count; i++)
                {
                    if (ent5[i].RecipeId == id)
                    {
                        entities.Entry(ent5[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }
                var ent6 = entities.RecipeImages.ToList();
                for (int i = 0; i < ent6.Count; i++)
                {
                    if (ent6[i].RecipeId == id)
                    {
                        entities.Entry(ent6[i]).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                    }
                }

                entities.SaveChanges();
            }
        }

    }
}
