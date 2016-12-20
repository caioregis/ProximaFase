using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        [Required]
        public string login { get; set; }
        [Required]
        [DataMember]
        public string email { get; set; }
        [Required, DataType(DataType.Password)]
        [DataMember]
        public string senha { get; set; }
        [Required]
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public string telefone { get; set; }
        [DataMember]
        public byte?[] foto { get; set; }
        [DataMember]
        public int enderecoID { get; set; }

        public virtual Endereco endereco { get; set; }
        public virtual ICollection<Preferencias> preferencias { get; set; }
        //public virtual ICollection<ConsoleGame> consolesPossuidos { get; set; }
        public virtual ICollection<JogoPossuido> JogosPossuidos { get; set; }
        public virtual ICollection<JogoDesejado> JogosDesejados { get; set; }
        public virtual ICollection<Combinacao> Combinacoes { get; set; }
        public virtual ICollection<CartaoDeCredito> MeiosDePagamento { get; set; }
    }
}