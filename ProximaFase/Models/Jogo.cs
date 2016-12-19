using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class Jogo
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime anoLancamento { get; set; }
        public decimal valor { get; set; }

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