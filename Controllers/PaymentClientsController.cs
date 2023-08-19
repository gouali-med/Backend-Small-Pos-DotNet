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
    public class PaymentClientsController : ControllerBase
    {
        private readonly IDbContextApp<PaymentClient> _paymentsClients;

        public PaymentClientsController(IDbContextApp<PaymentClient> paymentsClients)
        {
            _paymentsClients = paymentsClients;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentsClients.List());
        }
        [HttpPost]
        public async Task<IActionResult> Add(PaymentClient PaymentClient)
        {
            if (ModelState.IsValid)
            {
               await _paymentsClients.Add(PaymentClient);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PaymentClient PaymentClient)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await _paymentsClients.Update(id, PaymentClient);
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


            await _paymentsClients.Delete(id);
            return Ok();
        }
    }
}
