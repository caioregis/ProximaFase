using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProximaFase.Models
{
    [DataContract]
    public class Endereco
    {
        [DataMember]
        public int id { get; set; }
        [Required]
        [DataMember]
        public string logradouro { get; set; }
        [DataMember]
        public int numero { get; set; }
        [DataMember]
        public string complemento { get; set; }
        [DataMember]
        public string bairro { get; set; }
        [DataMember]
        [Required]
        public string cidade { get; set; }
        [DataMember]
        [Required]
        public string estado { get; set; }
        //public string geoLocation { get; set; }
   }
}