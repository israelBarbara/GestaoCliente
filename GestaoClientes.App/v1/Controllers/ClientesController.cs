using GestaoClientes.Domain.v1.DTOs.Request;
using GestaoClientes.Domain.v1.DTOs.Response;
using GestaoClientes.Domain.v1.Interfaces.Services;
using GestaoClientes.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace GestaoClientes.App.v1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteServices _service;
        public ClientesController(IClienteServices service)
        {
            _service = service;
        }
        [AllowAnonymous]
        //public async Task<IActionResult> Index()
        //{
        //    IEnumerable<ClientesResponse> _clientes = await _service.GetClientes();
        //    return View(_clientes);
        //}

        public async Task<IActionResult> Create()
        {
            ViewData["Estados"] = new SelectList(_service.GetEstados());

            IEnumerable<ClientesResponse> _clientes = await _service.GetClientes();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertClienteRequest cliente)
        {
            if (ModelState.IsValid)
            {
                await _service.InsertCliente(cliente);
                return RedirectToAction(nameof(Index));
            }

            //ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome", produto.FornecedorId);
            return View(cliente);
        }



        public async Task<IActionResult> Index(string searchBy, string searchValue)
        {
            var clientes = await _service.PesquisaCliente(searchBy, searchValue);
            return View(clientes);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Cliente cliente =  await _service.FindCliente(id);
            return View(cliente);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _service.FindCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["Estados"] = new SelectList(_service.GetEstados());
            return View(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            Cliente abc = await _service.UpdateCliente(cliente);
            return RedirectToAction(nameof(Index));
        }






    }
}
