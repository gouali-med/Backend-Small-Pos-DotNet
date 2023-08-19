
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommercialeServices.Models.Class
{
    public class Sale
    {
        public int ID { get; set; }
        public DateTime DateOperation { get; set; } = DateTime.Now;
        public float TotalHT { get; set; }
        public float TotalTVA { get; set; }
        public float TotalTTC { get; set; }
        public float Solde { get; set; }
        public float Reste { get; set; }

        public int ClientID { get; set; }
        public int UserID { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }

    
    }
    public class DetailsSale
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public float Quantite { get; set; }
        public float Montant { get; set; }
        public int VenteID { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Sale? Sale { get; set; }

    }

 
}
