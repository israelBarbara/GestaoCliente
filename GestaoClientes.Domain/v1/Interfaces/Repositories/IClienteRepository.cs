using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
using GestaoClientes.Infrastructure;

namespace GestaoClientes.Domain.v1.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        public Task InsertCliente(InsertClienteRequest cliente);
        public Task<Cliente> FindCliente(int id);
        public Task<IEnumerable<ClientesResponse>> FindAllClientes();
        //public Cliente UpdateCliente(UpdateClienteRequest cliente);
        public Task<bool> RemoveCliente(int id);

    }
}
