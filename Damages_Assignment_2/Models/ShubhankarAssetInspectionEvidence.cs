using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Damages_Assignment_2.Models
{
    public partial class ShubhankarAssetInspectionEvidence
    {
        public int EvidenceId { get; set; }
        public int? DamageType { get; set; }
        public int? DamageEvidence { get; set; }
        public string SpecifyOthers { get; set; }
        public string IsDeleted { get; set; }
        public Guid? DamageId { get; set; }

        public virtual ShubhankarAssetInspectionDamage Damage { get; set; }
        public virtual ShubhankarLkpDamageEvidence DamageEvidenceNavigation { get; set; }
        public virtual ShubhankarLkpDamageType DamageTypeNavigation { get; set; }
    }
}
