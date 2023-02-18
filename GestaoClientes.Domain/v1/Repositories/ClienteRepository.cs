
using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
using GestaoClientes.Domain.v1.enums;
using GestaoClientes.Domain.v1.Interfaces.Repositories;
using GestaoClientes.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GestaoClientes.Domain.v1.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly GestaoClientesContext _context;

        public ClienteRepository(GestaoClientesContext context) 
        {
            _context = context;
        }

        public async Task<Cliente> FindCliente(int id)
        {
            Cliente? _cliente = await _context.Cliente.FindAsync(id);
            if (_cliente == null) return null;
            return _cliente;
        }

        public async Task<IEnumerable<ClientesResponse>> FindAllClientes()
        {
            IEnumerable<ClientesResponse> _clientes = await (from C in _context.Cliente
                                                             select new ClientesResponse
                                                             {
                                                                 Id = C.Id,
                                                                 Nome = C.Nome,
                                                                 Cpf = C.Cpf,
                                                                 DataNascimento = C.DataNascimento.ToString("dd MMM yyyy"),
                                                                 Sexo = ((Sexo)C.Sexo).ToString(),
                                                                 Endereco = C.Endereco,
                                                                 Estado = C.Estado,
                                                                 Cidade = C.Cidade,

                                                             }).ToListAsync();


           return _clientes;
        }

        public async Task<bool> InsertCliente(InsertClienteRequest cliente)
        {
            Cliente _cliente = new Cliente
            {
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                Sexo = (int)cliente.Sexo,
                Endereco = cliente.Endereco,
                Estado = cliente.Estado,
                Cidade = cliente.Cidade,
            };
             _context.Cliente.Add(_cliente);
             await _context.SaveChangesAsync();
             return true;
        }

        //public Cliente UpdateCliente(UpdateClienteRequest cliente)
        //{
        //    Cliente? _cliente = _context.Cliente.Find(cliente.Id);
        //    if(_cliente == null) return null;

        //    _cliente.Nome = cliente.Nome;
        //    _cliente.Email = cliente.Email;        
        //    _context.SaveChanges();
        //    return _cliente;
        //}
        public async Task<bool> RemoveCliente(int id)
        {
            Cliente? _cliente = await _context.Cliente.FindAsync(id);
            if (_cliente == null) return false;

            _context.Remove(_cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ClientesResponse>> PesquisarCpf(string cpf)
        {
            IEnumerable<ClientesResponse> _clientes = await (from C in _context.Cliente.Where(x => x.Cpf.Contains(cpf.Replace(".","").Replace("-","")))
                                                             select new ClientesResponse
                                                             {
                                                                 Id = C.Id,
                                                                 Nome = C.Nome,
                                                                 Cpf = C.Cpf,
                                                                 DataNascimento = C.DataNascimento.ToString("dd MMM yyyy"),
                                                                 Sexo = C.Sexo.ToString(),
                                                                 Endereco = C.Endereco,
                                                                 Estado = C.Estado,
                                                                 Cidade = C.Cidade,

                                                             }).ToListAsync();


            return _clientes;
        }

        public async Task<IEnumerable<ClientesResponse>> PesquisarNome(string nome)
        {
            IEnumerable<ClientesResponse> _clientes = await (from C in _context.Cliente.Where(x => x.Nome.Contains(nome))
                                                             select new ClientesResponse
                                                             {
                                                                 Id = C.Id,
                                                                 Nome = C.Nome,
                                                                 Cpf = C.Cpf,
                                                                 DataNascimento = C.DataNascimento.ToString("dd MMM yyyy"),
                                                                 Sexo = C.Sexo.ToString(),
                                                                 Endereco = C.Endereco,
                                                                 Estado = C.Estado,
                                                                 Cidade = C.Cidade,

                                                             }).ToListAsync();


            return _clientes;
        }

        public async Task<IEnumerable<ClientesResponse>> PesquisarUF(string uf)
        {
            IEnumerable<ClientesResponse> _clientes = await (from C in _context.Cliente.Where(x => x.Estado.Contains(uf))
                                                             select new ClientesResponse
                                                             {
                                                                 Id = C.Id,
                                                                 Nome = C.Nome,
                                                                 Cpf = C.Cpf,
                                                                 DataNascimento = C.DataNascimento.ToString("dd MMM yyyy"),
                                                                 Sexo = C.Sexo.ToString(),
                                                                 Endereco = C.Endereco,
                                                                 Estado = C.Estado,
                                                                 Cidade = C.Cidade,

                                                             }).ToListAsync();

            return _clientes;

        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            Cliente _cli = await FindCliente(cliente.Id);
            if (_cli != null)
            {
                _cli.Endereco = cliente.Endereco;
                _cli.Estado = cliente.Estado;
                _cli.Cidade = cliente.Cidade;
                await _context.SaveChangesAsync();
            }
            else
            {
                return null;
            }
            return _cli;


        }



    }
}
