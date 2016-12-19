using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class Mensagem
    {
        public int MensagemID { get; set; }
        public int CombinacaoID { get; set; }
        public int? DeUsuarioID { get; set; }
        public string MensagemText { get; set; }
        public DateTime DataHora { get; set; }

        public virtual Combinacao Combinacao { get; set; }
        public virtual Usuario DeUsuario { get; set; }
    }
}