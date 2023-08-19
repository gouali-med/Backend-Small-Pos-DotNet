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
    public class ProductsController : ControllerBase
    {
        private readonly IWebHostEnvironment hosting;
        private readonly IDbContextApp<Product> _products;
        private readonly IDbContextApp<Category> _categories;
        private readonly IDbContextApp<UniteOfSale> _uniteofsales;
        private readonly AppDbContext db;

        public ProductsController(AppDbContext _db, IDbContextApp<Product> products, IDbContextApp<Category> categories, IDbContextApp<UniteOfSale> uniteofsales, IWebHostEnvironment hosting)
        {
            _products = products;
            _categories = categories;
            _uniteofsales = uniteofsales;
            db = _db;
            this.hosting = hosting;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {

            return await db.Products.Select(x => new Product()
            {
                ID = x.ID,
                Name = x.Name,
                BarCode = x.BarCode,
                CategoryID = x.CategoryID,
                UniteOfSaleID = x.UniteOfSaleID,
                PurchasPrice = x.PurchasPrice,
                Price = x.Price,
                StockAlerte = x.StockAlerte,
                PicturePath = x.PicturePath,
                ImageSource = string.Format("{0}://{1}{2}:80/wwwroot/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.PicturePath),
            }).ToListAsync();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCat(int CatId)
        {

            return await db.Products.Where(m=>m.CategoryID==CatId).Select(x => new Product()
            {
                ID = x.ID,
                Name = x.Name,
                BarCode = x.BarCode,
                CategoryID = x.CategoryID,
                UniteOfSaleID = x.UniteOfSaleID,
                PurchasPrice = x.PurchasPrice,
                Price = x.Price,
                StockAlerte = x.StockAlerte,
                PicturePath = x.PicturePath,
                ImageSource = string.Format("{0}://{1}{2}:80/wwwroot/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.PicturePath),
            }).ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductDTO Product)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Product.Picture.FileName;
            string uploads = Path.Combine(hosting.WebRootPath, "Images"); // get folder with uploads name in wwwroot folder
            string fullPath = Path.Combine(uploads, uniqueFileName);

            if (Product.Picture != null)
            {


                if (!System.IO.File.Exists(fullPath))
                {
                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await Product.Picture.CopyToAsync(stream);
                        stream.Close();
                    }
                }
            }

            var model = new Product
            {

                PicturePath = uniqueFileName,
                Name = Product.Name,
                BarCode = Product.BarCode,
                CategoryID = Product.CategoryID,
                UniteOfSaleID = Product.UniteOfSaleID,
                PurchasPrice = Product.PurchasPrice,
                Price = Product.Price,
                StockAlerte = Product.StockAlerte,

            };
            var category = await _categories.Find(model.CategoryID);
            var uniteofsale = await _uniteofsales.Find(model.UniteOfSaleID);
            model.Category = category;
            model.UniteOfSale = uniteofsale;
            await _products.Add(model);
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product Product)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await _products.Update(id, Product);
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
            await _products.Delete(id);
            return Ok();
        }


    }
}
