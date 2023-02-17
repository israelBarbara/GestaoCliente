using GestaoClientes.Domain.v1.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Domain.v1.DTOs.Request
{
    public class InsertClienteRequest
    {

        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public Sexo Sexo { get; set; }
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Cidade { get; set; }

    }
}
