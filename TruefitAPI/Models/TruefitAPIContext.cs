using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TruefitAPI.Models
{
    public class TruefitAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TruefitAPIContext() : base("name=TruefitAPIContext")
        {
        }

        public System.Data.Entity.DbSet<TruefitAPI.Models.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<TruefitAPI.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<TruefitAPI.Models.RestaurantCategory> RestaurantCategories { get; set; }

        public System.Data.Entity.DbSet<TruefitAPI.Models.RestaurantPriceRange> RestaurantPriceRanges { get; set; }

        public System.Data.Entity.DbSet<TruefitAPI.Models.Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
