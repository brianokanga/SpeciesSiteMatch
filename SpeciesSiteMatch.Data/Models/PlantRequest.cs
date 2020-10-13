//using System;
//using System.Collections.Generic;

//namespace SpeciesSiteMatch.Data.Models
//{
//    public partial class PlantRequest
//    {
//        public PlantRequest()
//        {
//            SubCounties = new List<SubCounty>();
//        }
//        public int Id { get; set; }
//        public int CountyId { get; set; }
//        public int SubCountyId { get; set; }
//        public int LocationId { get; set; }
//        public int SpecieId { get; set; }

//        public virtual County County { get; set; }
//        public virtual Location Location { get; set; }
//        public virtual Specie Specie { get; set; }
//        public virtual List<SubCounty> SubCounties { get; set; }
//    }
//}
