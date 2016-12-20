using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int combinacaoID { get; set; }
        [DataMember]
        public decimal valor { get; set; }
        [DataMember]
        public OrderStatus status { get; set; }

        public virtual Combinacao combinacao { get; set; }
    }

    public enum OrderStatus
    {
        OrdemConclusao,
        OrdemConstetacao,
    }
}