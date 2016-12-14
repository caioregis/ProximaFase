using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class Endereco
    {
        public int id { get; set; }
        [Required]
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        [Required]
        public string cidade { get; set; }
        [Required]
        public string estado { get; set; }
        //public string geoLocation { get; set; }
   }
}