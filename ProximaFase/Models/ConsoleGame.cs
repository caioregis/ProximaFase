using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class ConsoleGame
    {
        public int ConsoleGameID { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}