using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommercialeServices.Models.Class
{
    public class PaymentClient
    {
        public int ID { get; set; }
        public DateTime DateOperation { get; set; } = DateTime.Now;
        public float Payed { get; set; }
        public DateTime? DateEcheance { get; set; }
        public int UserID { get; set; }
        public int TypePaymentID { get; set; }
        public int VenteID { get; set; }
        public virtual User User { get; set; }
        public virtual TypePayment TypePayment { get; set; }
        public virtual Sale Vente { get; set; }
    }


    public class TypePayment
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

}
