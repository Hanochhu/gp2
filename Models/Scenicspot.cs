using System;
using System.Collections.Generic;

#nullable disable

namespace gp2.Models
{
    public partial class Scenicspot
    {
        public int SpotId { get; set; }
        public string SpotName { get; set; }
        public string SpotProvince { get; set; }
        public string SpotCity { get; set; }
        public string SpotInformation { get; set; }
        public string SpotOpentime { get; set; }
        public string SpotPicture { get; set; }
        public string SpotAddress { get; set; }
        public int? SpotLove { get; set; }
        public decimal? SpotLng { get; set; }
        public decimal? SpotLat { get; set; }
    }
}
