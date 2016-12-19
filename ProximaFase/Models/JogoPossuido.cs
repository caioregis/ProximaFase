using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class JogoPossuido : Jogo
    {
        public new int id { get; set; }
        public int usuarioID { get; set; }
        public string detalhes { get; set; }
        public DateTime dataDeCompra { get; set; }
        public CondicaoJogo? estado { get; set; }
        public bool Disponivel { get; set; }


        public virtual Usuario usuario { get; set; }
        public virtual ICollection<Combinacao> combinacoes { get; set; }
    }
}