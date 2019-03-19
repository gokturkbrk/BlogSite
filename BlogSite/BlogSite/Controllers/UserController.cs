using BlogSite.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSite.Controllers
{
    public class UserController : ApiController
    {
        BlogSiteEntities db;

        public UserController()
        {
            db = new BlogSiteEntities();
        }
        [HttpPost]
        public IHttpActionResult Add(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                return Json<string>("Username must be filled!");
            }
            db.Users.Add(user);
            db.SaveChanges();
            return Json("User added!");
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                User deletedUser = db.Users.Find(id);
                db.Users.Remove(deletedUser);
                db.SaveChanges();
                return Json("User deleted!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPut]
        public IHttpActionResult Update(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                return Json("Username must be filled");
            }
            User updatedUser = db.Users.Find(user.UserName);
            updatedUser.UserName = user.UserName;
            updatedUser.Password = user.Password;
            updatedUser.Name = user.Name;
            updatedUser.Surname = user.Surname;
            db.SaveChanges();
            return Json("User updated");
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                User getUser = db.Users.Find(id);
                if (getUser==null)
                {
                    return Json("User not found!");
                }
                UserDto u = new UserDto();
                u.Name = getUser.Name;
                u.Surname = getUser.Surname;
                u.UserName = getUser.UserName;
                u.EMail = getUser.EMail;
                u.Password = getUser.Password;
                return Json(u);
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
                List<UserDto> users = new List<UserDto>();
                foreach (User user in db.Users.ToList())
                {
                    UserDto u = new UserDto();
                    u.Name = user.Name;
                    u.Surname = user.Surname;
                    u.UserName = user.UserName;
                    u.EMail = user.EMail;
                    u.Password = user.Password;
                    u.UserRole = user.UserRole.Name;
                    users.Add(u);
                }
                return Json(users);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
        [HttpGet]
        public IHttpActionResult GetUserByLogin(string mail, string password)
        {
            User u = db.Users.Where(x => x.EMail == mail && x.Password == password).SingleOrDefault();
            if (u==null)
            {
                return Json("Wrong email or password");
            }
            UserDto uDto = new UserDto();
            uDto.Name = u.Name;
            uDto.Surname = u.Surname;
            uDto.UserName = u.UserName;
            uDto.EMail = u.EMail;
            uDto.Password = u.Password;
            uDto.UserRole = u.UserRole.Name;
            return Json(uDto);
        }
    }
}
