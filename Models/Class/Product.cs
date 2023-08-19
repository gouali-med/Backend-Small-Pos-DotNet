using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GestionCommercialeServices.Models.Class
{
    public class Product
    {
        public int ID { get; set; }
        public string? BarCode { get; set; }
        public string? PicturePath { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int UniteOfSaleID { get; set; }
        public float PurchasPrice { get; set; }
        public float Price { get; set; }
        public float? StockAlerte { get; set; }
        [NotMapped]
        public string ImageSource { get; set; }

        public virtual Category Category { get; set; }
        public virtual UniteOfSale UniteOfSale { get; set; }

    }

    public class Category
    {
        public int ID { get; set; }
        public string? Picture { get; set; }
        public string Name { get; set; }
        public int TaxeID { get; set; }
        public virtual Taxe? Taxe { get; set; }
        [NotMapped]
        public string ImageSource { get; set; }
      

    }
    public class Taxe
    {
        public int ID { get; set; }
        public float Valeur { get; set; }
    }
    public class UniteOfSale
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }

}
