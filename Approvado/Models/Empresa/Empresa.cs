using System;
using System.Collections.Generic;

namespace Approvado.Models;

public partial class Empresa
{
    public string Empresa1 { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? RncCedula { get; set; }

    public string? Descripcion { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? Logo { get; set; }

    public int Estatus { get; set; }

    public string? CorreoPrincipal { get; set; }

    public string? SendGridKey { get; set; }

    public string? OneSignalKey { get; set; }

    public string? PrimaryColor { get; set; }

    public string? SecondColor { get; set; }

    public string? Tipo { get; set; }
    public int? Modo { get; set; }
    public int? Pagina { get; set; }=1;
    public int? ElementosPorPagina { get; set; }=10;
}
