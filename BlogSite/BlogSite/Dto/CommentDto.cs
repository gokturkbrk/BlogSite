using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Dto
{
    public class CommentDto
    {
        public string Username { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }
        public string CommentImage { get; set; }
        public string CommentContent { get; set; }
    }
}