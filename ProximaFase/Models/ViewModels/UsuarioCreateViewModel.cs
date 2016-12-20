using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProximaFase.Models.ViewModels
{
    public class UsuarioCreateViewModel
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string email { get; set; }
        [Required, DataType(DataType.Password)]
        public string senha { get; set; }
        [Required]
        public string nome { get; set; }
        public string telefone { get; set; }

        [Required]
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        [Required]
        public string bairro { get; set; }
        [Required]
        public string cidade { get; set; }
        [Required]
        public string estado { get; set; }
    }
}