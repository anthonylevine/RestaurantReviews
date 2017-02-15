namespace TruefitAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        LastUpdatedDate = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantPriceRanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Range = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        LastUpdatedDate = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        PriceRangeId = c.Int(nullable: false),
                        AdminId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        AddressTwo = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        ContactEmail = c.String(nullable: false),
                        WebsiteURL = c.String(),
                        FacebookURL = c.String(),
                        TwitterURL = c.String(),
                        Hours = c.String(),
                        ImageLocations = c.String(),
                        Description = c.String(nullable: false),
                        TakesReservations = c.Boolean(nullable: false),
                        OffersDelivery = c.Boolean(nullable: false),
                        OffersTakeout = c.Boolean(nullable: false),
                        AcceptsCreditCards = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedDate = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AdminId, cascadeDelete: true)
                .ForeignKey("dbo.RestaurantCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.RestaurantPriceRanges", t => t.PriceRangeId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.PriceRangeId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Location = c.String(),
                        ProfilePic = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: true),
                        LastUpdatedDate = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ReviewComment = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        DateVisited = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdatedDate = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.RestaurantId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "PriceRangeId", "dbo.RestaurantPriceRanges");
            DropForeignKey("dbo.Restaurants", "CategoryId", "dbo.RestaurantCategories");
            DropForeignKey("dbo.Restaurants", "AdminId", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "RestaurantId" });
            DropIndex("dbo.Restaurants", new[] { "AdminId" });
            DropIndex("dbo.Restaurants", new[] { "PriceRangeId" });
            DropIndex("dbo.Restaurants", new[] { "CategoryId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Users");
            DropTable("dbo.Restaurants");
            DropTable("dbo.RestaurantPriceRanges");
            DropTable("dbo.RestaurantCategories");
        }
    }
}
