using System;
using System.Collections.Generic;

namespace SpeciesSiteMatch.Data.Models
{
    public partial class Specie
    {
        public Specie()
        {
            SpecieDetails = new List<SpecieDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SpecieDetail> SpecieDetails { get; set; }
    }
}
