using Damages_Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Damages_Assignment_2.DamagesData
{
    public interface IDamagesData
    {
        Task <List<ShubhankarAssetInspectionDamage>> GetDamagesList();
        Task<List<ShubhankarAssetInspectionEvidence>> GetEvidence(Guid id);
        Task<List<ShubhankarLkpDamageType>> GetDamageType();
        Task<List<ShubhankarLkpDamageEvidence>> GetDamageEvidence(int id);
        ShubhankarAssetInspectionDamage GetDamages(Guid id);
        Task<ShubhankarAssetInspectionDamage> GetMainData(Guid id);
        Task<ShubhankarAssetInspectionDamage> AddDamage(ShubhankarAssetInspectionDamage shubhankarAssetInspectionDamage);
        Task DeleteDamage(Guid id);
        Task EditDamage(ShubhankarAssetInspectionDamage NewData);


    }
}
