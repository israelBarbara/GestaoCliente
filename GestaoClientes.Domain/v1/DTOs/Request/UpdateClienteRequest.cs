using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Domain.v1.DTOs.Request
{
    public class UpdateClienteRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Estado { get; set; }

    }
}
