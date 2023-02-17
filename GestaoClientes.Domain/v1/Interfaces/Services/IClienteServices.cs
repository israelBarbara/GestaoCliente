using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClientes.Domain.v1.Interfaces.Services
{
    public interface IClienteServices
    {
        public Task<bool> InsertCliente(InsertClienteRequest cliente);
        public Task<IEnumerable<ClientesResponse>> GetClientes();
    }
}
