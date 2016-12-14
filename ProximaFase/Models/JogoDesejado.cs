using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class JogoDesejado
    {
        public int id { get; set; }
        public int jogoID { get; set; }
        public int usuarioID { get; set; }
        public CondicaoJogo? estado { get; set; }

        public virtual Jogo jogo { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}