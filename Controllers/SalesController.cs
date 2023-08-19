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
using GestionCommercialeServices.DTO;

namespace GestionCommercialeServicesServices.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SalesController : ControllerBase
    {
        private readonly IDbContextApp<Sale> _sales;
        private readonly IDbContextApp<PaymentClient> _paimentsClients;
        private readonly IDbContextApp<DetailsSale> _details;

        public SalesController(IDbContextApp<Sale> sales, IDbContextApp<PaymentClient> paimentsClients, IDbContextApp<DetailsSale> details)
        {
            _sales = sales;
            _details = details;
            _paimentsClients = paimentsClients;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sales.List());
        }
        [HttpPost]
        public async Task<IActionResult> Add(SaleDTO dto)
        {
            Sale sale = new Sale()
            {
                ClientID = dto.ClientID,
                UserID = dto.UserID,
                TotalHT = dto.TotalHT,
                TotalTVA = dto.TotalTVA,
                TotalTTC = dto.TotalTCC
                
            };
            await _sales.Add(sale);

            PaymentClient payment = new PaymentClient()
            {
                UserID = dto.UserID,
                Payed = dto.TotalTCC,
                VenteID = sale.ID,
                TypePaymentID = 7

            };
     
            await _paimentsClients.Add(payment);
         

            for (int i = 0; i < dto.details.Count; i++)
            {
                DetailsSale details = new DetailsSale()
                {
                    VenteID = sale.ID,
                    ProductID = dto.details[i].ProductID,
                    Quantite = dto.details[i].Quantite,
                    Montant = dto.details[i].Montant,
                };
                try
                {
                    await _details.Add(details);
                }
                catch (Exception ex) { Console.Write(ex.Message); }

            }

            return Ok();


        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Sale Sale)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await _sales.Update(id, Sale);
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


            await _sales.Delete(id);
            return Ok();
        }
    }
}
