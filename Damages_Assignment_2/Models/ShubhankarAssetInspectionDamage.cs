using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Damages_Assignment_2.Models
{
    public partial class ShubhankarAssetInspectionDamage
    {
        public ShubhankarAssetInspectionDamage()
        {
            ShubhankarAssetInspectionEvidence = new HashSet<ShubhankarAssetInspectionEvidence>();
        }

        public Guid DamageId { get; set; }
        public int? EstimateOfDamages { get; set; }
        public string IsStructuralDamage { get; set; }
        public string IsSlidingDamage { get; set; }
        public string IsRoofDamage { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<ShubhankarAssetInspectionEvidence> ShubhankarAssetInspectionEvidence { get; set; }
        
    }
}
