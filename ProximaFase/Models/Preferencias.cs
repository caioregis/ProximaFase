using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class Preferencias
    {
        public int id { get; set; }
        public int distanciaMaximaDeBusca { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}