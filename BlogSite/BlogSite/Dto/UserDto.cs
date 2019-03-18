using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}