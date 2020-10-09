using System;
using System.Collections.Generic;

namespace LifeInsurance.Entities
{
      public partial class CoveragePlans
    {
        public CoveragePlans()
        {
            RateChart = new HashSet<RateChart>();
        }
        public int Id { get; set; }
        public string CoveragePlan { get; set; }
        public DateTime EligibilityDateFrom { get; set; }
        public DateTime EligibilityDateTo { get; set; }
        public string EligibilityCountry { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool Isdeleted { get; set; }
        public ICollection<RateChart> RateChart { get; set; }
    }
}
