using GestaoClientes.Domain.v1.DTOs.Response;
using GestaoClientes.Domain.v1.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoClientes.App.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServices _service;
        public ClienteController(IClienteServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ClientesResponse> _clientes = await _service.GetClientes();
            return View(_clientes);
        }




    }
}
