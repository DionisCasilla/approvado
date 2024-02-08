using Approvado.Services;
using Microsoft.AspNetCore.Mvc;

namespace Approvado.Controllers;
using System.Collections.Generic;
using Approvado.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EmpresaController : ControllerBase
{
    private readonly EmpresaService _empresaService; // Suponiendo que tienes un servicio similar al proporcionado anteriormente.

    public EmpresaController(EmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empresa>>> ObtenerTodasLasEmpresas()
    {
        var _empresa=new Empresa{
            Tipo="L",
            Modo=1
        };
        var empresas =await _empresaService.GestionarEmpresaAsync(_empresa);
        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public ActionResult<Empresa> ObtenerEmpresaPorId(int id)
    {
          var _empresa=new Empresa{
            Tipo="L",
            Modo=2,
            Empresa1="AS"
        };
        var empresa = _empresaService.GestionarEmpresaAsync(_empresa);

        if (empresa == null)
        {
            return NotFound();
        }

        return Ok(empresa);
    }

    [HttpPost]
    public async Task<ActionResult> CrearEmpresa([FromBody] Empresa empresa)
    {
        if (ModelState.IsValid)
        {
           empresa.Tipo="C";
           empresa.Modo=1;
            await  _empresaService.GestionarEmpresaAsync(empresa);
            return CreatedAtAction(nameof(ObtenerEmpresaPorId), new { id = empresa.Empresa1 }, empresa);
        }

        return BadRequest(ModelState);
    }

    // [HttpPut("{id}")]
    // public ActionResult ActualizarEmpresa(int id, [FromBody] Empresa empresa)
    // {
    //     if (id != empresa.Id)
    //     {
    //         return BadRequest();
    //     }

    //     if (ModelState.IsValid)
    //     {
    //         _empresaService.ActualizarEmpresa(empresa);
    //         return NoContent();
    //     }

    //     return BadRequest(ModelState);
    // }

    // [HttpDelete("{id}")]
    // public ActionResult EliminarEmpresa(int id)
    // {
    //     _empresaService.EliminarEmpresa(id);
    //     return NoContent();
    // }
}
