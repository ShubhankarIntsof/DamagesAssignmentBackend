using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Damages_Assignment_2.Models
{
    public partial class ShubhankarLkpDamageEvidence
    {
        public ShubhankarLkpDamageEvidence()
        {
            ShubhankarAssetInspectionEvidence = new HashSet<ShubhankarAssetInspectionEvidence>();
        }

        public int DamageEvidenceId { get; set; }
        public string DamageLevel { get; set; }
        public int? DamageTypeId { get; set; }
        public string IsDeleted { get; set; }

        public virtual ShubhankarLkpDamageType DamageType { get; set; }
        public virtual ICollection<ShubhankarAssetInspectionEvidence> ShubhankarAssetInspectionEvidence { get; set; }
    }
}
