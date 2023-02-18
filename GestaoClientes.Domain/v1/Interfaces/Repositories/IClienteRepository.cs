using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
using GestaoClientes.Infrastructure;

namespace GestaoClientes.Domain.v1.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        public Task<bool> InsertCliente(InsertClienteRequest cliente);
        public Task<Cliente> FindCliente(int id);
        public Task<IEnumerable<ClientesResponse>> FindAllClientes();
        //public Cliente UpdateCliente(UpdateClienteRequest cliente);
        public Task<bool> RemoveCliente(int id);

        public Task<IEnumerable<ClientesResponse>> PesquisarNome(string nome);
        public Task<IEnumerable<ClientesResponse>> PesquisarCpf(string cpf);
        public Task<IEnumerable<ClientesResponse>> PesquisarUF(string uf);
        public Task<Cliente> UpdateCliente(Cliente cliente);

    }
}
