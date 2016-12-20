using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract]
    public class Jogo
    {
        public int id { get; set; }
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public int anoLancamento { get; set; }
        [DataMember]
        public decimal valor { get; set; }
        [DataMember]
        public int consoleID { get; set; }
        public virtual ConsoleGame console { get; set; }
    }

    public enum CondicaoJogo
    {
        PerfeitoEstado,
        CapaAvariada,
        SemCapa
    }
}