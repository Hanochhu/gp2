using System;
using System.Collections.Generic;

#nullable disable

namespace gp2.Models
{
    public partial class Post 
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime? PostPubdate { get; set; }
        public int? PostRank { get; set; }
        public int? PostSid { get; set; }
        public int? PostUserid { get; set; }
    }
}
