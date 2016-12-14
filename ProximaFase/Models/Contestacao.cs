using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class Contestacao
    {
        public int ContestacaoID { get; set; }
        public int CombinacaoID { get; set; }
        public int UsuarioAcusadoID { get; set; }
        public bool FraudeConfirmada { get; set; }
        public decimal ValorMulta { get; set; }

        public virtual Combinacao Combinacao { get; set; }
        public virtual Usuario UsuarioAcusado { get; set; }
    }
}