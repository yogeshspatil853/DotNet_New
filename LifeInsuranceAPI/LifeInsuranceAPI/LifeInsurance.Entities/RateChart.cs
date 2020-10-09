using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeInsurance.Entities
{
    public partial class RateChart
    {
       
		public int Id { get; set; }
		
        public string CustomerGender { get; set; }
		public string CustomerAge { get; set; }
		public decimal NetPrice { get; set; }
		public DateTime AddedDate { get; set; }
		public DateTime? Modifieddate { get; set; }
		public bool Isdeleted { get; set; }

		[ForeignKey(nameof(CoveragePlans))]
		public int CoveragePlansId { get; set; }
		public virtual CoveragePlans CoveragePlans  { get; set; }
	}

}
