using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract(Name = "JogoDesejado")]
    public class JogoDesejado : Jogo
    {
        [DataMember]
        public new int id { get; set; }
        [DataMember]
        public int usuarioID { get; set; }
        [DataMember]
        public CondicaoJogo? estado { get; set; }

        public virtual Usuario usuario { get; set; }
    }
}