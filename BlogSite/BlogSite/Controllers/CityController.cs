using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSite.Controllers
{
    public class CityController : ApiController
    {
        BlogSiteEntities db;
        public CityController()
        {
            db = new BlogSiteEntities();
        }

        [HttpPost]
        public IHttpActionResult Add(City city)
        {
            if (string.IsNullOrWhiteSpace(city.CityName))
            {
                return Json("City name must be filled!");
            }
            db.Cities.Add(city);
            db.SaveChanges();
            return Json("City added!");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                City deletedCity = db.Cities.Find(id);
                db.Cities.Remove(deletedCity);
                db.SaveChanges();
                return Json("City deleted!");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }

        //[HttpPut]
        //public IHttpActionResult Update(City city)
        //{
        //    if (string.IsNullOrWhiteSpace(city.CityName))
        //    {
        //        return Json("City name must be filled");
        //    }
        //    db.Entry(city).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //    return Json("City updated");
        //}

        [HttpPut]
        public IHttpActionResult Update(City city)
        {
            if (string.IsNullOrWhiteSpace(city.CityName))
            {
                return Json("City name must be filled");
            }
            City updatedCity = db.Cities.Find(city.CityID);
            updatedCity.CityName = city.CityName;
            db.SaveChanges();
            return Json("City updated");
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                City getCity = db.Cities.Find(id);
                if (getCity==null)
                {
                    return Json("City not found!");
                }
                return Json(getCity);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Json(db.Cities.ToList());
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }

        
    }
}
