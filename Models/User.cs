using System;
using System.Collections.Generic;

#nullable disable

namespace gp2.Models
{
    public partial class User 
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPic { get; set; }
        public string UserPhone { get; set; }
        public string UserPassword { get; set; }
        public int? UserSex { get; set; }
        public int? Isdeleted { get; set; }
    }
}
