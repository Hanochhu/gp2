using System;
using System.Collections.Generic;

#nullable disable

namespace gp2.Models
{
    public partial class Strategy
    {
        public int StaId { get; set; }
        public string StaPic { get; set; }
        public string StaTitle { get; set; }
        public int? StaWriter { get; set; }
        public string StaInfo { get; set; }
        public string StaContent { get; set; }
        public string StaScenic { get; set; }
        public DateTime? StaPubdate { get; set; }
        public int? StaRequiredtime { get; set; }
        public int? StaViews { get; set; }
        public int? StaCosts { get; set; }
        public int? StaPopulation { get; set; }
        public int? StaLove { get; set; }
    }
}
