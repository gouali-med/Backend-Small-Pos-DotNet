using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionCommercialeServices.Models;
using GestionCommercialeServices.Models.Class;
using GestionCommercialeServices.Models.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace GestionCommercialeServicesServices.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaxesController :ControllerBase
    {
        private readonly IDbContextApp<Taxe> _taxes;
        private readonly AppDbContext _db;

        public TaxesController(IDbContextApp<Taxe> taxes, AppDbContext db)
        {
            _taxes = taxes;
            this._db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _taxes.List());
        }

        [HttpGet]
        public async Task<IActionResult> GetByCategory(int cat_id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(b => b.ID == cat_id);
            var Taxe = await _db.Taxes.SingleOrDefaultAsync(b => b.ID == category.TaxeID);

          
            return Ok( Taxe.Valeur.ToString());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Taxe Taxe)
        {
            if (ModelState.IsValid)
            {
               await _taxes.Add(Taxe);
                return Ok(Taxe);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Taxe Taxe)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await _taxes.Update(id, Taxe);
                }
                catch (Exception ex)
                {

                    return NotFound(ex.Message);

                }
            }
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {


            await _taxes.Delete(id);
            return Ok();
        }
    }
}
