using System;
using System.Collections.Generic;

namespace SpeciesSiteMatch.Data.Models
{
    public partial class Location
    {
        public Location()
        {
            SpecieDetails = new List<SpecieDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SubCountyId { get; set; }
        
        public virtual SubCounty SubCounty { get; set; }
        public virtual ICollection<SpecieDetail> SpecieDetails { get; set; }
    }
}
