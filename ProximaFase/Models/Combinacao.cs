using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract]
    [KnownType(typeof(JogoPossuido))]
    public class Combinacao
    {
        [DataMember]
        public int CombinacaoID { get; set; }
        [DataMember]
        public decimal ValorCombinacao { get; set; }
        [DataMember]
        public Status Status { get; set; }

        public virtual ICollection<Usuario> UsuariosEnvolvidos { get; set; }
        public virtual ICollection<JogoPossuido> JogosEnvolvidos { get; set; }
        public virtual ICollection<Mensagem> Mensagens { get; set; }
        public virtual ICollection<Contestacao> Contestacoes { get; set; }
    }

    public enum Status
    {
        Aberta,
        Concluida,
        Fechada
    }
}