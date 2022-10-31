using Damages_Assignment_2.DamagesData;
using Damages_Assignment_2.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Damages_Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DamagesController : ControllerBase
    {
        private IDamagesData _damageData;
        public DamagesController(IDamagesData damageData)
        {
            _damageData = damageData;
        }

        [HttpGet("GetDamagesList")]
        public async Task<IActionResult> GetDamagesList()
        {
            return Ok(await _damageData.GetDamagesList());
        }
        //Gives evidence details for specific guid
        [HttpGet("GetEvidence/{id}")]
        public async Task<IActionResult> GetEvidence(Guid id)
        {
            var k = await _damageData.GetEvidence(id);
            if(k!= null)
            {
                return Ok(k);
            }
            else
            {
                return NotFound($"Data with {id} not found.");
            }
        }
        //lookup table for the options for the level
        //of damages like 50% for fire 10% for flood etc
        [HttpGet("GetDamageEvidence/{id}")]
        public async Task<IActionResult> GetDamageEvidence(int id)
        {
            return Ok(await _damageData.GetDamageEvidence(id));
        }
        //Done__
        //lookup table for the options for Fire Flood etc options
        [HttpGet("GetLkpDamageType")]
        public async Task<IActionResult> GetLkpDamageType()
        {
            return Ok(await _damageData.GetDamageType());
        }
        [HttpPost("PostMainData")]
        public async Task<IActionResult> PostMainData(ShubhankarAssetInspectionDamage Data)
        {
            var k = await _damageData.AddDamage(Data);
            return Ok(k);
        }
        [HttpGet("GetMainData/{id}")]
        public async Task<IActionResult> GetMainData(Guid id)
        {
           return Ok(await _damageData.GetMainData(id)); 
        }
        [HttpDelete("DeleteDamages/{id}")]
        public async Task<IActionResult> DeleteDamages(Guid id)
        {
            var k = await _damageData.GetMainData(id);
            if(k != null)
            {
                await _damageData.DeleteDamage(id);
                return Ok(k);
            }

            return NotFound($"Case with {id} not found.");
        }
        [HttpPut("EditDamages")]
        public async Task<IActionResult> EditDamages(ShubhankarAssetInspectionDamage NewData)
        {
            await _damageData.EditDamage(NewData);
            return Ok(NewData);
        }
    }
}
