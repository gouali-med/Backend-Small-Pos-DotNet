
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommercialeServices.Models.Class
{
    public class User
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string? Phone { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }



    }
}
