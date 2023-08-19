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

namespace GestionCommercialeServicesServices.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UniteOfSalesController :ControllerBase
    {
        private readonly IDbContextApp<UniteOfSale> _uniteOfSales;

        public UniteOfSalesController(IDbContextApp<UniteOfSale> uniteOfSales)
        {
            _uniteOfSales = uniteOfSales;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _uniteOfSales.List());
        }
        [HttpPost]
        public async Task<IActionResult> Add(UniteOfSale UniteOfSale)
        {
            if (ModelState.IsValid)
            {
               await _uniteOfSales.Add(UniteOfSale);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UniteOfSale UniteOfSale)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await _uniteOfSales.Update(id, UniteOfSale);
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
            await _uniteOfSales.Delete(id);
            return Ok();
        }
    }
}
