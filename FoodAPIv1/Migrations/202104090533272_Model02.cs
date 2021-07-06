namespace FoodAPIv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CateRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Recipe_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Follower_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Follower_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Follower_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(unicode: false, storeType: "text"),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RecipeImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(unicode: false, storeType: "text"),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeImages", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Links", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Followings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Followings", "Follower_Id", "dbo.Users");
            DropForeignKey("dbo.Favorites", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Favorites", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.CateRecipes", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.CateRecipes", "Category_Id", "dbo.Categories");
            DropIndex("dbo.RecipeImages", new[] { "Recipe_Id" });
            DropIndex("dbo.Links", new[] { "User_Id" });
            DropIndex("dbo.Followings", new[] { "User_Id" });
            DropIndex("dbo.Followings", new[] { "Follower_Id" });
            DropIndex("dbo.Favorites", new[] { "User_Id" });
            DropIndex("dbo.Favorites", new[] { "Recipe_Id" });
            DropIndex("dbo.CateRecipes", new[] { "Recipe_Id" });
            DropIndex("dbo.CateRecipes", new[] { "Category_Id" });
            DropTable("dbo.RecipeImages");
            DropTable("dbo.Links");
            DropTable("dbo.Followings");
            DropTable("dbo.Favorites");
            DropTable("dbo.CateRecipes");
            DropTable("dbo.Categories");
        }
    }
}
