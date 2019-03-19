using BlogSite.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSite.Controllers
{
    public class PostController : ApiController
    {
        BlogSiteEntities db;
        public PostController()
        {
            db = new BlogSiteEntities();
        }

        [HttpPost]
        public IHttpActionResult Add(Post post)
        {
            if (string.IsNullOrWhiteSpace(post.Content))
            {
                return Json("Content must be filled!");
            }
            db.Posts.Add(post);
            db.SaveChanges();
            return Json("Post added!");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Post deletedPost = db.Posts.Find(id);
                db.Posts.Remove(deletedPost);
                db.SaveChanges();
                return Json("Post deleted!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(Post post)
        {
            if (string.IsNullOrWhiteSpace(post.Content))
            {
                return Json("Content must be filled!");
            }
            Post updatedPost = db.Posts.Find(post.PostID);
            updatedPost.Content = post.Content;
            updatedPost.Image = post.Image;
            db.SaveChanges();
            return Json("Post updated!");
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Post getPost = db.Posts.Find(id);
                if (getPost == null)
                {
                    return Json("Post not found!");
                }
                PostDto p = new PostDto();
                p.City = getPost.City.CityName;
                p.Content = getPost.Content;
                p.Image = getPost.Image;
                return Json("Post added!");
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
                List<PostDto> posts = new List<PostDto>();
                foreach (Post item in db.Posts)
                {
                    PostDto p = new PostDto();
                    p.City = item.City.CityName;
                    p.Content = item.Content;
                    p.Image = item.Image;
                    posts.Add(p);
                }
                return Json(posts);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
            
        }
    }
}
