using BlogSite.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSite.Controllers
{
    public class CommentController : ApiController
    {
        BlogSiteEntities db;

        public CommentController()
        {
            db = new BlogSiteEntities();
        }

        [HttpPost]
        public IHttpActionResult Add(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                return Json("Content must be filled!");
            }
            db.Comments.Add(comment);
            db.SaveChanges();
            return Json("Comment added");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Comment deletedComment = db.Comments.Find(id);
                db.Comments.Remove(deletedComment);
                db.SaveChanges();
                return Json("comment deleted");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(Comment comment)
        {
            if(string.IsNullOrWhiteSpace(comment.Content))
            {
                return Json("Content cannot be empty!");
            }
            Comment updatedComment = db.Comments.Find(comment.CommentID);
            updatedComment.Content = comment.Content;
            updatedComment.Image = comment.Image;
            db.SaveChanges();
            return Json("Comment updated");
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Comment getComment = db.Comments.Find(id);
                if (getComment == null)
                {
                    return Json("Comment not found");
                }
                CommentDto c = new CommentDto();
                c.UserID = getComment.User.UserID;
                c.PostID = getComment.PostID;
                c.Username = getComment.User.UserName;
                c.CommentImage = getComment.Image;
                c.CommentContent = getComment.Content;
                return Json(c);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }            
        }

        [HttpGet]
        public IHttpActionResult GetAllPassive()
        {
            try
            {
                List<CommentDto> comments = new List<CommentDto>();
                foreach (Comment item in db.Comments.Where(x => !x.Active.Value))
                {
                    CommentDto c = new CommentDto();
                    c.UserID = item.User.UserID;
                    c.PostID = item.PostID;
                    c.Username = item.User.UserName;
                    c.CommentImage = item.Image;
                    c.CommentContent = item.Content;
                    comments.Add(c);
                }
                return Json(comments);
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
            
        }
    }
}
