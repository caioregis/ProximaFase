using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract]
    public class Mensagem
    {
        [DataMember]
        public int MensagemID { get; set; }
        [DataMember]
        public int CombinacaoID { get; set; }
        [DataMember]
        public int DeUsuarioID { get; set; }
        [DataMember]
        public string MensagemText { get; set; }
        [DataMember]
        public DateTime DataHora { get; set; }

        public virtual Combinacao Combinacao { get; set; }
        public virtual Usuario DeUsuario { get; set; }
    }
}