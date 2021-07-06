namespace FoodAPIv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CateRecipes", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Recipes", "UserId", "dbo.Users");
            DropForeignKey("dbo.CateRecipes", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Favorites", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Favorites", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Followings", "Follower_Id", "dbo.Users");
            DropForeignKey("dbo.Followings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Links", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Ratings", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Ratings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RecipeImages", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Reviews", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.Users");
            DropIndex("dbo.CateRecipes", new[] { "Category_Id" });
            DropIndex("dbo.CateRecipes", new[] { "Recipe_Id" });
            DropIndex("dbo.Recipes", new[] { "UserId" });
            DropIndex("dbo.Favorites", new[] { "Recipe_Id" });
            DropIndex("dbo.Favorites", new[] { "User_Id" });
            DropIndex("dbo.Followings", new[] { "Follower_Id" });
            DropIndex("dbo.Followings", new[] { "User_Id" });
            DropIndex("dbo.Links", new[] { "User_Id" });
            DropIndex("dbo.Ratings", new[] { "Recipe_Id" });
            DropIndex("dbo.Ratings", new[] { "User_Id" });
            DropIndex("dbo.RecipeImages", new[] { "Recipe_Id" });
            DropIndex("dbo.Reviews", new[] { "Recipe_Id" });
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropColumn("dbo.CateRecipes", "Category_Id");
            DropColumn("dbo.CateRecipes", "Recipe_Id");
            DropColumn("dbo.Recipes", "UserId");
            DropColumn("dbo.Favorites", "Recipe_Id");
            DropColumn("dbo.Favorites", "User_Id");
            DropColumn("dbo.Followings", "Follower_Id");
            DropColumn("dbo.Followings", "User_Id");
            DropColumn("dbo.Links", "User_Id");
            DropColumn("dbo.Ratings", "Recipe_Id");
            DropColumn("dbo.Ratings", "User_Id");
            DropColumn("dbo.RecipeImages", "Recipe_Id");
            DropColumn("dbo.Reviews", "Recipe_Id");
            DropColumn("dbo.Reviews", "User_Id");
            AddColumn("dbo.CateRecipes", "RecipeId", c => c.Int(nullable: false));
            AddColumn("dbo.CateRecipes", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Favorites", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Favorites", "RecipeId", c => c.Int(nullable: false));
            AddColumn("dbo.Followings", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Followings", "FollowerId", c => c.Int(nullable: false));
            AddColumn("dbo.Links", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Ratings", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Ratings", "RecipeId", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeImages", "RecipeId", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "RecipeId", c => c.Int(nullable: false));
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "User_Id", c => c.Int());
            AddColumn("dbo.Reviews", "Recipe_Id", c => c.Int());
            AddColumn("dbo.RecipeImages", "Recipe_Id", c => c.Int());
            AddColumn("dbo.Ratings", "User_Id", c => c.Int());
            AddColumn("dbo.Ratings", "Recipe_Id", c => c.Int());
            AddColumn("dbo.Links", "User_Id", c => c.Int());
            AddColumn("dbo.Followings", "User_Id", c => c.Int());
            AddColumn("dbo.Followings", "Follower_Id", c => c.Int());
            AddColumn("dbo.Favorites", "User_Id", c => c.Int());
            AddColumn("dbo.Favorites", "Recipe_Id", c => c.Int());
            AddColumn("dbo.Recipes", "UserId", c => c.Int());
            AddColumn("dbo.CateRecipes", "Recipe_Id", c => c.Int());
            AddColumn("dbo.CateRecipes", "Category_Id", c => c.Int());
            DropColumn("dbo.Reviews", "RecipeId");
            DropColumn("dbo.Reviews", "UserId");
            DropColumn("dbo.RecipeImages", "RecipeId");
            DropColumn("dbo.Ratings", "RecipeId");
            DropColumn("dbo.Ratings", "UserId");
            DropColumn("dbo.Links", "UserId");
            DropColumn("dbo.Followings", "FollowerId");
            DropColumn("dbo.Followings", "UserId");
            DropColumn("dbo.Favorites", "RecipeId");
            DropColumn("dbo.Favorites", "UserId");
            DropColumn("dbo.Recipes", "UserId");
            DropColumn("dbo.CateRecipes", "CategoryId");
            DropColumn("dbo.CateRecipes", "RecipeId");
            CreateIndex("dbo.Reviews", "User_Id");
            CreateIndex("dbo.Reviews", "Recipe_Id");
            CreateIndex("dbo.RecipeImages", "Recipe_Id");
            CreateIndex("dbo.Ratings", "User_Id");
            CreateIndex("dbo.Ratings", "Recipe_Id");
            CreateIndex("dbo.Links", "User_Id");
            CreateIndex("dbo.Followings", "User_Id");
            CreateIndex("dbo.Followings", "Follower_Id");
            CreateIndex("dbo.Favorites", "User_Id");
            CreateIndex("dbo.Favorites", "Recipe_Id");
            CreateIndex("dbo.Recipes", "UserId");
            CreateIndex("dbo.CateRecipes", "Recipe_Id");
            CreateIndex("dbo.CateRecipes", "Category_Id");
            AddForeignKey("dbo.Reviews", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Reviews", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.RecipeImages", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.Ratings", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Ratings", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.Links", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Followings", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Followings", "Follower_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Favorites", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Favorites", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.CateRecipes", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.Recipes", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.CateRecipes", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
