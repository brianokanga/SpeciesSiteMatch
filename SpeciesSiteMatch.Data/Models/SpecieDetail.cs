using System;
using System.Collections.Generic;

namespace SpeciesSiteMatch.Data.Models
{
    public partial class SpecieDetail
    {
        public int Id { get; set; }

        public string MapUrl { get; set; }
        public int LocationId { get; set; }
        public int SpecieId { get; set; }


        public virtual Location Location { get; set; }
        public virtual Specie Specie { get; set; }


    }
}
