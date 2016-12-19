using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class Usuario
    {
        public int id { get; set; }

        [Required]
        public string login { get; set; }
        [Required]
        public string email { get; set; }
        [Required, DataType(DataType.Password)]
        public string senha { get; set; }
        [Required]
        public string nome { get; set; }
        public string telefone { get; set; }
        public byte?[] foto { get; set; }
        public int enderecoID { get; set; }

        public virtual Endereco endereco { get; set; }
        public virtual ICollection<Preferencias> preferencias { get; set; }
        //public virtual ICollection<ConsoleGame> consolesPossuidos { get; set; }
        //public virtual ICollection<JogoPossuido> JogosPossuidos { get; set; }
        //public virtual ICollection<JogoDesejado> JogosDesejados { get; set; }
        public virtual ICollection<CartaoDeCredito> MeiosDePagamento { get; set; }
    }
}