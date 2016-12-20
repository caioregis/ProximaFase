using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract]
    public class Contestacao
    {
        [DataMember]
        public int ContestacaoID { get; set; }
        [DataMember]
        public int CombinacaoID { get; set; }
        [DataMember]
        public int UsuarioAcusadoID { get; set; }
        [DataMember]
        public bool FraudeConfirmada { get; set; }
        [DataMember]
        public decimal ValorMulta { get; set; }

        public virtual Combinacao Combinacao { get; set; }
        public virtual Usuario UsuarioAcusado { get; set; }
    }
}