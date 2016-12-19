using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class Order
    {
        public int id { get; set; }
        public int combinacaoID { get; set; }
        public decimal valor { get; set; }
        public OrderStatus status { get; set; }

        public virtual Combinacao combinacao { get; set; }
    }

    public enum OrderStatus
    {
        OrdemConclusao,
        OrdemConstetacao,
    }
}