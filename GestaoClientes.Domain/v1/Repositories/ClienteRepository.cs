
using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
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
                                                                 DataNascimento = C.DataNascimento.ToString("dd/MMMM/yyyy"),
                                                                 Sexo = C.Sexo.ToString(),
                                                                 Endereco = C.Endereco,
                                                                 Estado = C.Estado,
                                                                 Cidade = C.Cidade,

                                                             }).ToListAsync();


           return _clientes;
        }

        public async Task InsertCliente(InsertClienteRequest cliente)
        {
            Cliente _cliente = new Cliente
            {
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                Endereco = cliente.Endereco,
                Estado = cliente.Estado,
                Cidade = cliente.Cidade,
            };
             _context.Cliente.Add(_cliente);
            await _context.SaveChangesAsync();
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



    }
}
