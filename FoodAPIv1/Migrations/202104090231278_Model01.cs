namespace FoodAPIv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        RatingNum = c.Int(nullable: false),
                        CreatedData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Description = c.String(unicode: false, storeType: "text"),
                        Nationality = c.String(unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        PrepareTime = c.DateTime(nullable: false),
                        RatingCount = c.Int(nullable: false),
                        RatingTotal = c.Double(nullable: false),
                        ReviewsCount = c.Int(nullable: false),
                        ReviewsRateTotal = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        ReviewText = c.String(unicode: false, storeType: "text"),
                        ReviewResult = c.Boolean(nullable: false),
                        CreatedData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Gender = c.String(unicode: false),
                        ImageUrl = c.String(unicode: false, storeType: "text"),
                        Phone = c.String(unicode: false),
                        Bio = c.String(unicode: false, storeType: "text"),
                        Nationality = c.String(unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        FollowersCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
            DropTable("dbo.Recipes");
            DropTable("dbo.Ratings");
        }
    }
}
