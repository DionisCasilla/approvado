using Approvado.Models;

namespace Approvado.Services;
public interface IEmpresaService
{
    Task<EmpresaResponse> GestionarEmpresaAsync(Empresa empresa);
}