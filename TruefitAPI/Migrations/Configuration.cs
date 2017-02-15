namespace TruefitAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TruefitAPI.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<TruefitAPI.Models.TruefitAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TruefitAPI.Models.TruefitAPIContext context)
        {
           
        }
    }
}
