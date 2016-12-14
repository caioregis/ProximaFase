using System;

namespace ProximaFase.Models
{
    public class CartaoDeCredito
    {
        public int CartaoDeCreditoID { get; set; }
        public int UsuarioID { get; set; }
        public string Bandeira { get; set; }
        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}