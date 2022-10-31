using Damages_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Damages_Assignment_2.DamagesData
{
    public class Damages_Data : IDamagesData
    {
        private Freshers_Training2022Context _damagesData;
        public Damages_Data(Freshers_Training2022Context damagesData)
        {
            _damagesData = damagesData;
        }
        //Helper
        public async Task<List<ShubhankarLkpDamageEvidence>> GetDamageEvidence(int id)
        {
            var k = await _damagesData.ShubhankarLkpDamageEvidence
                .Where(x => x.DamageTypeId == id && x.IsDeleted == "false")
                .ToListAsync();
            return (k);
        }
        //Gives whole data
        public async Task<List<ShubhankarAssetInspectionDamage>> GetDamagesList()
        {
            var k = await _damagesData.ShubhankarAssetInspectionDamage
                .Where(x => x.IsDeleted == "false")
                .ToListAsync();
            return (k);
        }
        //Gives Single data
        public ShubhankarAssetInspectionDamage GetDamages(Guid id)
        {
            var k = _damagesData.ShubhankarAssetInspectionDamage
                .Where(x => x.DamageId == id)
                .SingleOrDefault();
            return (k);
        }

        //Provides Evidence Data for Specific case Guid (Like fire, water etc)
        public async Task<List<ShubhankarAssetInspectionEvidence>> GetEvidence(Guid id)
        {
            var k = await _damagesData.ShubhankarAssetInspectionEvidence
                .Where(x => x.IsDeleted == "false" && x.DamageId == id)
                .ToListAsync();
            return k;
        }
        //Done__
        //lookup Table for Evidences like fire, flood etc.
        public async Task<List<ShubhankarLkpDamageType>> GetDamageType()
        {
            var k = await _damagesData.ShubhankarLkpDamageType
                .Where(x => x.IsDeleted == "false")
                .ToListAsync();
            return k;
        }
        //Done
        //Provides data when case guid given
        public async Task<ShubhankarAssetInspectionDamage> GetMainData(Guid id)
        {
            ShubhankarAssetInspectionDamage k = new ShubhankarAssetInspectionDamage();
            k = await _damagesData.ShubhankarAssetInspectionDamage
                .Where(x => x.DamageId == id)
                .SingleOrDefaultAsync();

            k.ShubhankarAssetInspectionEvidence = await _damagesData.ShubhankarAssetInspectionEvidence
                .Where(x => x.IsDeleted == "false" && x.DamageId == id)
                .ToListAsync();
            return (k);
        }
        //to create a new Damage case
        public async Task<ShubhankarAssetInspectionDamage> AddDamage(ShubhankarAssetInspectionDamage NewDamage)
        {
            //NewDamage.DamageId = new Guid();
            NewDamage.IsDeleted = "false";
            NewDamage.CreatedOn = DateTime.Now;
            NewDamage.ModifiedOn = DateTime.Now;
            
            _damagesData.ShubhankarAssetInspectionDamage.Add(NewDamage);
            await _damagesData.SaveChangesAsync();

            return NewDamage;
        }
        
        public async Task DeleteDamage(Guid id)
        {
            var k = await _damagesData.ShubhankarAssetInspectionDamage.
                Where(x => x.DamageId == id).SingleOrDefaultAsync() ;
            k.IsDeleted = "true";
            _damagesData.ShubhankarAssetInspectionDamage.Update(k);
            foreach (var item in k.ShubhankarAssetInspectionEvidence)
            {
                item.IsDeleted = "true";
                 _damagesData.ShubhankarAssetInspectionEvidence.Update(item);
            }
           await _damagesData.SaveChangesAsync();
        }
        //Edit 
        public async Task EditDamage(ShubhankarAssetInspectionDamage NewData)
        {
            NewData.ModifiedOn = DateTime.Now;
            _damagesData.ShubhankarAssetInspectionDamage.Update(NewData);
            foreach (var item in NewData.ShubhankarAssetInspectionEvidence)
            {
                item.IsDeleted = "true";
                _damagesData.ShubhankarAssetInspectionEvidence.Update(item);
            }
            await _damagesData.SaveChangesAsync();
            
        }
    }
}
