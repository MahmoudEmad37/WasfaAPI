using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FoodAPIv1.Controllers
{
    /// <summary>
    /// All Operations for Users
    /// </summary>
    public class ReviewsController : ApiController
    {
        /// <summary>
        /// User Add Review for Specific Recipe and Calculate Recipe's Rate
        /// </summary>
        /// <param name="rev">Mandatory</param>
        public string Post([FromBody]Review rev)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent1 = entities.Recipes.FirstOrDefault(e => e.Id == rev.RecipeId);
                var ent2 = entities.Users.FirstOrDefault(e => e.Id == rev.UserId);

                entities.Reviews.Add(rev);
                entities.SaveChanges();


                List<Review> reviews = entities.Reviews.ToList();
                double total=(double)ent1.ReviewsRateTotal;
                double pCount = 0;
                double Count = 0;
                for (int k = 0; k < reviews.Count; k++)
                {

                    if (rev.RecipeId == reviews[k].RecipeId)
                    {
                        if (Convert.ToDouble(reviews[k].ReviewResult) > 0)
                        {
                            pCount++;
                            Count++;
                        }
                        else
                        {
                            Count++;
                        }
                    }
                    
                }
                if (Count > 0)
                {
                    total = (pCount / Count) * 10;
                }
                else
                    total = 0;
                // Add function for increasing review count on recipe table
                Recipe rec = new Recipe();
                rec.Title = ent1.Title;
                rec.Description = ent1.Description;
                rec.Nationality = ent1.Nationality;
                rec.CreatedDate = ent1.CreatedDate;
                rec.PrepareTime = ent1.PrepareTime;
                rec.LoveCount = ent1.LoveCount;
                rec.ShareCount = ent1.ShareCount;
                rec.Privacy = ent1.Privacy;
                rec.ReviewsRateTotal = total;
                rec.Ingredients = ent1.Ingredients;
                rec.Steps = ent1.Steps;
                rec.UserId = ent1.UserId;
                rec.ReviewsCount = ent1.ReviewsCount + 1;
                RecipesController recController = new RecipesController();
                recController.Put(ent1.Id,rec);
                entities.SaveChanges();
                

                return total.ToString();
            }

        }

        /// <summary>
        /// User Update his Review for Specific Recipe
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <param name="rev">Mandatory</param>
        public void Put(int id, [FromBody] Review rev)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent = entities.Reviews.FirstOrDefault(e => e.Id == id);
                ent.ReviewText = rev.ReviewText;
                ent.ReviewResult = rev.ReviewResult;
                ent.CreatedData = rev.CreatedData;
                ent.UserId = rev.UserId;
                ent.RecipeId = rev.RecipeId;
                entities.SaveChanges();

            }
        }

        /// <summary>
        /// User Delete his Review for Specific Recipe
        /// </summary>
        /// <param name="id">Mandatory</param>
        public void Delete(int id)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                var ent = entities.Reviews.FirstOrDefault(e => e.Id == id);
                var ent1 = entities.Recipes.FirstOrDefault(e => e.Id == ent.RecipeId);
                Recipe rec = new Recipe();
                rec.Title = ent1.Title;
                rec.Description = ent1.Description;
                rec.Nationality = ent1.Nationality;
                rec.CreatedDate = ent1.CreatedDate;
                rec.PrepareTime = ent1.PrepareTime;
                rec.LoveCount = ent1.LoveCount;
                rec.ShareCount = ent1.ShareCount;
                rec.Privacy = ent1.Privacy;
                rec.ReviewsRateTotal = ent1.ReviewsRateTotal;
                rec.Ingredients = ent1.Ingredients;
                rec.Steps = ent1.Steps;
                rec.UserId = ent1.UserId;
                rec.ReviewsCount = ent1.ReviewsCount - 1;
                RecipesController recController = new RecipesController();
                recController.Put(ent1.Id, rec);
                entities.Entry(ent).State = System.Data.Entity.EntityState.Deleted;
                entities.SaveChanges();
            }
        }
    }
}