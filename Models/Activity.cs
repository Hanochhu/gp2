using System;
using System.Collections.Generic;

#nullable disable

namespace gp2.Models
{
    public partial class Activity 
    {
        public int ActId { get; set; }
        public string ActTitle { get; set; }
        public string ActPic { get; set; }
        public int? ActWriter { get; set; }
        public string ActTime { get; set; }
        public DateTime? ActBegintime { get; set; }
        public DateTime? ActEndtime { get; set; }
        public string ActSpend { get; set; }
        public int? ActNum { get; set; }
        public string ActPhone { get; set; }
        public string ActContent { get; set; }
    }
}
