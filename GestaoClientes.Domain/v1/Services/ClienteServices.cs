using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
using GestaoClientes.Domain.v1.Extensions;
using GestaoClientes.Domain.v1.Interfaces.Repositories;
using GestaoClientes.Domain.v1.Interfaces.Services;
using GestaoClientes.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

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
            if (!Cpf.Validar(cliente.Cpf)) return false;
            await _clienteRepository.InsertCliente(cliente);
            return true;         
        }

        public async Task<IEnumerable<ClientesResponse>> GetClientes()
        {
            IEnumerable<ClientesResponse> _clientes = await _clienteRepository.FindAllClientes();
            return _clientes;
        }

        public IEnumerable<string> GetEstados()
        {
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            List<string> _estadosOrder = (from e in estados orderby e select e).OrderBy(e => e).ToList();
            return _estadosOrder;
        }

        public async Task<IEnumerable<ClientesResponse>> PesquisaCliente(string searchBy, string searchValue)
        {
            IEnumerable<ClientesResponse> clientes = new List<ClientesResponse>();

            if (searchBy == null || searchValue == null) return await _clienteRepository.FindAllClientes();

            switch (searchBy.ToUpper()) 
            {
                case "NOME":
                    clientes =  await _clienteRepository.PesquisarNome(searchValue);
                    break;

                case "CPF":
                    clientes =  await _clienteRepository.PesquisarCpf(searchValue);
                    break;

                case "UF":
                    clientes = await _clienteRepository.PesquisarUF(searchValue);
                    break;
            }

            return clientes;
        }

        public async Task<bool> Delete(int id)
        {
            await _clienteRepository.RemoveCliente(id);
            return true;
        }

        public async Task<Cliente> FindCliente(int id)
        {
            return await _clienteRepository.FindCliente(id);
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            if(cliente.Cidade.Length >100 || cliente.Endereco.Length >100) return null;
            Cliente _cli = await _clienteRepository.UpdateCliente(cliente);
            return _cli;
        }

    }
}
