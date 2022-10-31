using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Damages_Assignment_2.Models
{
    public partial class ShubhankarLkpDamageType
    {
        public ShubhankarLkpDamageType()
        {
            ShubhankarAssetInspectionEvidence = new HashSet<ShubhankarAssetInspectionEvidence>();
            ShubhankarLkpDamageEvidence = new HashSet<ShubhankarLkpDamageEvidence>();
        }

        public int DamageTypeId { get; set; }
        public string DamageValue { get; set; }
        public string IsDeleted { get; set; }

        public virtual ICollection<ShubhankarAssetInspectionEvidence> ShubhankarAssetInspectionEvidence { get; set; }
        public virtual ICollection<ShubhankarLkpDamageEvidence> ShubhankarLkpDamageEvidence { get; set; }
    }
}
