using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class Combinacao
    {
        public int CombinacaoID { get; set; }
        public ICollection<JogoPossuido> JogosEnvolvidos { get; set; }
        public decimal ValorCombinacao { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<Mensagem> Mensagens { get; set; }
        public virtual ICollection<Contestacao> Contestacoes { get; set; }
    }

    public enum Status
    {
        Aberta,
        Finalizada,
        Fechada
    }
}