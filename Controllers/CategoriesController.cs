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

namespace GestionCommercialeServices.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IWebHostEnvironment hosting;
        private readonly IDbContextApp<Category> _categories;
        private readonly IDbContextApp<Taxe> _taxes;
        private readonly AppDbContext db;

        public CategoriesController(AppDbContext _db,IDbContextApp<Category> categories, IDbContextApp<Taxe> taxes, IWebHostEnvironment hosting)
        {
            _categories = categories;
            _taxes = taxes;
            db = _db;
            this.hosting = hosting;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {

            return await db.Categories.Select(x => new Category()
            {
                ID = x.ID,
                Name = x.Name,
                TaxeID = x.TaxeID,
                Picture = x.Picture,
                ImageSource = string.Format("{0}://{1}{2}:80/wwwroot/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Picture),
            }).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]CategoryDTO category)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + category.Picture.FileName;
            string uploads = Path.Combine(hosting.WebRootPath, "Images"); // get folder with uploads name in wwwroot folder
            string fullPath = Path.Combine(uploads, uniqueFileName);

            if (category.Picture != null)
            {

                
                if (!System.IO.File.Exists(fullPath))
                {
                    using(FileStream stream =new FileStream(fullPath, FileMode.Create))
                    {
                        await category.Picture.CopyToAsync(stream);
                        stream.Close();
                    }
                }
            }

            var model = new Category
            {

                Picture = uniqueFileName,
                Name = category.Name,
                TaxeID = category.TaxeID,

            };
            var taxe = await _taxes.Find(model.TaxeID);
            model.Taxe = taxe;
            await _categories.Add(model);
            return Ok();

        }
       
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {


            if (ModelState.IsValid)
            {
                try
                {
                   await _categories.Update(id,category);
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
            await _categories.Delete(id);
            return Ok();
        }



        string  UploadFile(IFormFile file)
        {

            if (file != null)
            {

                string uniqueFileName ="image"+ Guid.NewGuid().ToString();
                string uploads = Path.Combine(hosting.WebRootPath, "Images"); // get folder with uploads name in wwwroot folder
                string fullPath = Path.Combine(uploads, uniqueFileName);
                if (!System.IO.File.Exists(fullPath))
                {
                    file.CopyTo(new FileStream(fullPath, FileMode.Create));

                    return uniqueFileName;
                }
            }


            return null;
        }



    }
}
