using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using DomainModel.DataTransfer;
using PropertyWebApi.Interfaces;

namespace PropertyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MutanteController : ControllerBase, IMutanteController
    {
        public readonly IMutanteService _MutanteService;

        public MutanteController(IMutanteService mutanteService)
        {
            _MutanteService = mutanteService;
        }

       
        [HttpPost, Route("mutant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult>  Post([FromBody] Dna dnaEntrada )
        {
            try
            {                      
                if (await this._MutanteService.esMutante(dnaEntrada)) 
                {
                   return  Ok();
                }
                else 
                {
                    return Forbid();
                }               
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
              return BadRequest();
            }

        }

        [HttpGet, Route("stats")]
        public ActionResult Get()
        {
            try
            {                            
               return Ok(this._MutanteService.estadisticas());                          
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
 
}

