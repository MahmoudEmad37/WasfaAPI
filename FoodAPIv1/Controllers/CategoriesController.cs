using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fluent.Infrastructure.FluentModel;
using FoodAPIv1.Models;
using FoodAPIv1.Classes;

namespace FoodAPIv1.Controllers
{
    public class CategoriesController : ApiController
    {
        
        //public IEnumerable<CategoriesAll> Get()
        //{
        //    using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
        //    {
        //        List<CategoriesAll> categoriesAlls = new List<CategoriesAll>();
        //        RecipesController recipesController = new RecipesController();
        //        //List<RecipeAll> recipeAlls = (recipeobject)recipesController.Get();
        //        recipeObject recipeAlls = recipesController.Get();
        //        entities.Configuration.ProxyCreationEnabled = false;
        //        List<Category> categories = entities.Categories.ToList();
        //        List<CateRecipe> cateRecipes = entities.CateRecipes.ToList();

        //        for (int i = 0; i < categories.Count; i++)
        //        {
        //            List<RecipeAll> recipes = new List<RecipeAll>();
        //            for (int j = 0; j < cateRecipes.Count; j++)
        //            {
        //                if (categories[i].Id == cateRecipes[j].CategoryId)
        //                {
        //                    for (int k = 0; k < recipeAlls.Recipe.Count; k++)
        //                    {
        //                        if (cateRecipes[j].RecipeId == recipeAlls.Recipe[k].Id)
        //                        {
        //                            recipes.Add(recipeAlls.Recipe[k]);
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            CategoriesAll categoryAll = new CategoriesAll(categories[i].Id, categories[i].Title, recipes);
        //            categoriesAlls.Add(categoryAll);
        //        }
        //        return categoriesAlls;
        //    }
        //}

        [Route("api/CategoryId/{Title}")]
        public static int GetByTitle(string title)
        {
            using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
            {
                List<Category> categories = entities.Categories.ToList();
                for (int i = 0; i < categories.Count; i++)
                {
                    if (categories[i].Title.Equals(title))
                    {
                        return categories[i].Id;
                    }
                }
                return -1;
            }
        }

       // [Route("api/CateRecipe")]
       // public void postCateRecipes([FromBody]CategoriesRecipeM cat)
       // {
       //     using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
       //     {
       //         List<Category> categories = entities.Categories.ToList();
       //         CateRecipe c = new CateRecipe();
       //         for (int i = 0; i < categories.Count; i++)
       //         {
       //             for (int j = 0; j < cat.categ.Count; j++)
       //             {
       //                 if (cat.categ[j] == categories[i].Id)
       //                 {
       //                      c.RecipeId = cat.RecipeId;
       //                      c.CategoryId = cat.categ[j];
       //                      entities.CateRecipes.Add(c);
       //                 }
       //             }
       //             entities.SaveChanges();
       //         }
               
       //     }
       // }
       // public void Post([FromBody]Category cat)
       // {
       //     using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
       //     {
       //         entities.Categories.Add(cat);

       //         entities.SaveChanges();

       //     }
       // }
       ////lazm n3ml el category recipes
       // public void Put(int id, [FromBody] Category cat)
       // {
       //     using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
       //     {
       //         var ent = entities.Categories.FirstOrDefault(e => e.Id == id);
       //         ent.Title = cat.Title;
       //         entities.SaveChanges();

       //     }
       // }
       // public void delete(int id)
       // {
       //     using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
       //     {
       //         var ent = entities.Categories.FirstOrDefault(e => e.Id == id);
       //         entities.Entry(ent).State = System.Data.Entity.EntityState.Deleted;
       //         var ent2 = entities.CateRecipes.ToList();
       //         for(int i = 0; i < ent2.Count; i++)
       //         {
       //             if(ent2[i].CategoryId == id )
       //             {
       //                 entities.Entry(ent2[i]).State = System.Data.Entity.EntityState.Deleted;
       //                 entities.SaveChanges();
       //             }
       //         }
                
       //         entities.SaveChanges();
       //     }
       // }
       // [Route("api/DeleteCateRecipe/{id}")]
       // public void deleteCateRecipe(int id)
        //{
        //    using (FoodAPIv1Entities entities = new FoodAPIv1Entities())
        //    {
        //        var ent = entities.CateRecipes.FirstOrDefault(e => e.Id == id);
        //        entities.Entry(ent).State = System.Data.Entity.EntityState.Deleted;
               
        //        entities.SaveChanges();
        //    }
        //}
    }
}