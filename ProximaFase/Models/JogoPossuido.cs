using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract(Name = "JogoPossuido")]
    public class JogoPossuido : Jogo
    {
        [DataMember]
        public new int id { get; set; }
        [DataMember]
        public int usuarioID { get; set; }
        [DataMember]
        public string detalhes { get; set; }
        [DataMember]
        public DateTime dataDeCompra { get; set; }
        [DataMember]
        public CondicaoJogo? estado { get; set; }
        [DataMember]
        public bool Disponivel { get; set; }


        public virtual Usuario usuario { get; set; }
        public virtual ICollection<Combinacao> combinacoes { get; set; }
    }
}