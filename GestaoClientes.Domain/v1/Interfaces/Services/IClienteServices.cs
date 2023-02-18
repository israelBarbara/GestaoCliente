using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
using GestaoClientes.Infrastructure;
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
        public IEnumerable<string> GetEstados();
        public Task<IEnumerable<ClientesResponse>> PesquisaCliente(string searchBy, string searchValue);
        public Task<bool> Delete(int id);
        public  Task<Cliente> FindCliente(int id);
        public Task<Cliente> UpdateCliente(Cliente cliente);

    }
}
