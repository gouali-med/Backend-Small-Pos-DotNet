using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommercialeServices.Models.Class
{

    public class Client
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TypeClient { get; set; }
        [Required]
        public int RegionID { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string? Email { get; set; }
        public string? Siteweb { get; set; }
        public string? Adresse { get; set; }
        public string? ICE { get; set; }
        public string? RC { get; set; }
        public string? IF { get; set; }
        public string? TP { get; set; }

        [Required]
        public Region Region { get; set; }


    }
    public class Region
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
