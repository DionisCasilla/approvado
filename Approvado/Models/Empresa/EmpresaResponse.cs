namespace Approvado.Models;

public class EmpresaResponse
{
     public int cError { get; set; }
    public string Mensaje { get; set; }
    
    public List<Empresa>? data {get; set;}
}
