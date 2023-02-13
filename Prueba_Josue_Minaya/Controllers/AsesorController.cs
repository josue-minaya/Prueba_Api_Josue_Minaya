using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Josue_Minaya.DB;
using Prueba_Josue_Minaya.Models;
using Prueba_Josue_Minaya.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Josue_Minaya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsesorController : Controller
    {
        private readonly IAsesorRepository _asesorRepository;
        public AsesorController(IAsesorRepository asesorRepository)
        {
            _asesorRepository = asesorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaAsesor = await _asesorRepository.Get();
            return Ok(listaAsesor);
        }

        [HttpPost]
        public async Task<IActionResult> Created(Asesor asesor)
        {
           await _asesorRepository.CreateAndSave(asesor);
           return Created(string.Empty,asesor.IdAsesor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asesor = await _asesorRepository.GetById(id);
            return Ok(asesor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var asesorExiste = await _asesorRepository.GetById(id);
            if (asesorExiste != null)
            {
                await _asesorRepository.DeleteAndSave(id);
                return Ok();
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Asesor asesor)
        {
           var asesorExiste= await _asesorRepository.GetById(asesor.IdAsesor);
            if (asesorExiste != null)
            {
                asesorExiste.Nombre = asesor.Nombre;
                await _asesorRepository.UpdateAndSave(asesorExiste);
                return Ok();
            }
            return NoContent();
        }


    }
}
