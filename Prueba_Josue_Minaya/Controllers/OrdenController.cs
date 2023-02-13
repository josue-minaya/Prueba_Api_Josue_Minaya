using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Josue_Minaya.DB.Models;
using Prueba_Josue_Minaya.Models;
using Prueba_Josue_Minaya.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Josue_Minaya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrdenController : ControllerBase
    {
        private readonly IOrdenRepository _ordenRepository;
        public OrdenController(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrden()
        {
            var listaOrden = await _ordenRepository.GetOrden();
            return Ok(listaOrden);
        }

        [HttpPost]
        public async Task<IActionResult> Created(Venta venta)
        {
            
            await _ordenRepository.CreateAndSave(venta);
            return Created(string.Empty, venta.orden.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orden = await _ordenRepository.GetById(id);
            return Ok(orden);
        }

       

       
    }
}
