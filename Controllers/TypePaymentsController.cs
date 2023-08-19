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
    public class TypePaymentsController :ControllerBase
    {
        private readonly IDbContextApp<TypePayment> _typePayments;

        public TypePaymentsController(IDbContextApp<TypePayment> typePayments)
        {
            _typePayments = typePayments;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _typePayments.List());
        }
        [HttpPost]
        public async Task<IActionResult> Add(TypePayment TypePayment)
        {
            if (ModelState.IsValid)
            {
               await _typePayments.Add(TypePayment);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TypePayment TypePayment)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await _typePayments.Update(id, TypePayment);
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


            await _typePayments.Delete(id);
            return Ok();
        }
    }
}
