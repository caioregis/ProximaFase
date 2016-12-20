using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract]
    public class Preferencias
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int distanciaMaximaDeBusca { get; set; }
        [DataMember]
        public int UsuarioId { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}