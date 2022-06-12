using DomainModel.DataTransfer;
using Microsoft.AspNetCore.Mvc;

namespace PropertyWebApi.Interfaces
{
    /// <summary>
    /// Metodos del controller con las operaciones que llaman la logica de negocio a los servicios,
    /// </summary>
    public interface IMutanteController
    {
        Task<IActionResult> Post([FromBody] Dna propertyDt);
    }
}
