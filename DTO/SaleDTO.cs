using GestionCommercialeServices.Models.Class;

namespace GestionCommercialeServices.DTO
{
    public record SaleDTO
    {

        public float TotalHT { get; set; }
        public float TotalTVA { get; set; }
        public float TotalTCC { get; set; }
        public float Solde { get; set; }
        public float Reste { get; set; }

        public int ClientID { get; set; }
        public int UserID { get; set; }
        public List<DetailsSale> details { get; set; }
    }
}
