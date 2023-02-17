using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
using GestaoClientes.Domain.v1.Interfaces.Repositories;
using GestaoClientes.Domain.v1.Interfaces.Services;

namespace GestaoClientes.Domain.v1.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public async Task<bool> InsertCliente(InsertClienteRequest cliente)
        {
            await _clienteRepository.InsertCliente(cliente);
            return true;         
        }

        public async Task<IEnumerable<ClientesResponse>> GetClientes()
        {
            IEnumerable<ClientesResponse> _clientes = await _clienteRepository.FindAllClientes();
            return _clientes;
        }

    }
}
