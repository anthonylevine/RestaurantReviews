﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TruefitAPI.Models;

namespace TruefitAPI.Controllers
{
    public class RestaurantsController : ApiController
    {
        private TruefitAPIContext db = new TruefitAPIContext();

        [ActionName("GetRestaurants")]
        public List<RestaurantDTO> GetRestaurants(string city)
        {
            var restaurants = from r in db.Restaurants
                              where r.City.Equals(city)
                              select new RestaurantDTO()
                              {
                                  Id = r.Id,
                                  CategoryId = r.CategoryId,
                                  CategoryLabel = r.Category.Category,
                                  PriceRangeId = r.PriceRangeId,
                                  PriceRangeLabel = r.PriceRange.Range,
                                  AdminId = r.AdminId,
                                  AdminName = r.Admin.Name,
                                  Name = r.Name,
                                  Address = r.Address,
                                  AddressTwo = r.AddressTwo,
                                  City = r.City,
                                  State = r.State,
                                  ZipCode = r.ZipCode,
                                  PhoneNumber = r.PhoneNumber,
                                  ContactEmail = r.ContactEmail,
                                  WebsiteURL = r.WebsiteURL,
                                  FacebookURL = r.FacebookURL,
                                  TwitterURL = r.TwitterURL,
                                  Hours = r.Hours
                              };
            return restaurants.ToList();
        }

        [ResponseType(typeof(Restaurant))]
        public async Task<IHttpActionResult> GetRestaurant(int id)
        {
            Restaurant restaurant = await db.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Restaurant))]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurant);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurant.Id }, restaurant);
        }

        [ResponseType(typeof(Restaurant))]
        public async Task<IHttpActionResult> DeleteRestaurant(int id)
        {
            Restaurant restaurant = await db.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
            await db.SaveChangesAsync();

            return Ok(restaurant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.Id == id) > 0;
        }
    }
}