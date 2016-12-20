using System;
using System.Runtime.Serialization;

namespace ProximaFase.Models
{
    [DataContract]
    public class CartaoDeCredito
    {
        [DataMember]
        public int CartaoDeCreditoID { get; set; }
        [DataMember]
        public int UsuarioID { get; set; }
        [DataMember]
        public string Bandeira { get; set; }
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public DateTime DataVencimento { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}