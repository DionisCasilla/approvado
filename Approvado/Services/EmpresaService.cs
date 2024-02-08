using System.Data;
using Approvado.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Approvado.Services;

public class EmpresaService : IEmpresaService
{
    private readonly DbA46041ApprovadoContext _dbContext;

    public EmpresaService(DbA46041ApprovadoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EmpresaResponse> GestionarEmpresaAsync(Empresa empresaModel)
    {
    var parametros = new List<SqlParameter>
        {
            new SqlParameter("@Empresa", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(empresaModel.Empresa1)?DBNull.Value:empresaModel.Empresa1 },
            new SqlParameter("@Nombre", SqlDbType.VarChar, 300) { Value = string.IsNullOrEmpty(empresaModel.Nombre)?DBNull.Value:empresaModel.Nombre   },
            new SqlParameter("@RNC_CEDULA", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(empresaModel.RncCedula)?DBNull.Value:empresaModel.RncCedula     },
            new SqlParameter("@Descripcion", SqlDbType.NText) { Value = string.IsNullOrEmpty(empresaModel.Descripcion)?DBNull.Value:empresaModel.Descripcion     },
            new SqlParameter("@Direccion", SqlDbType.NVarChar, 400) { Value = string.IsNullOrEmpty(empresaModel.Direccion)?DBNull.Value:empresaModel.Direccion     },
            new SqlParameter("@Telefono1", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(empresaModel.Telefono1)?DBNull.Value:empresaModel.Telefono1  },
            new SqlParameter("@Telefono2", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(empresaModel.Telefono2)?DBNull.Value:empresaModel.Telefono2  },
            new SqlParameter("@Logo", SqlDbType.NVarChar, -1) { Value = string.IsNullOrEmpty(empresaModel.Logo)?DBNull.Value:empresaModel.Logo    },
            new SqlParameter("@Estatus", SqlDbType.Int) { Value = empresaModel.Estatus   },
            new SqlParameter("@Correo_Principal", SqlDbType.NVarChar, 200) { Value = string.IsNullOrEmpty(empresaModel.CorreoPrincipal)?DBNull.Value:empresaModel.CorreoPrincipal    },
            new SqlParameter("@SendGridKey", SqlDbType.NVarChar, -1) { Value = string.IsNullOrEmpty(empresaModel.SendGridKey)?DBNull.Value:empresaModel.SendGridKey  },
            new SqlParameter("@OneSignalKey", SqlDbType.NVarChar, -1) { Value = string.IsNullOrEmpty(empresaModel.OneSignalKey)?DBNull.Value:empresaModel.OneSignalKey    },
            new SqlParameter("@Primary_Color", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(empresaModel.PrimaryColor)?DBNull.Value:empresaModel.PrimaryColor   },
            new SqlParameter("@Second_Color", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(empresaModel.SecondColor)?DBNull.Value:empresaModel.SecondColor     },
            new SqlParameter("@Tipo", SqlDbType.Char, 1) { Value = string.IsNullOrEmpty(empresaModel.Tipo)?DBNull.Value:empresaModel.Tipo     },
            new SqlParameter("@Modo", SqlDbType.Int) { Value = string.IsNullOrEmpty(empresaModel.Modo.ToString())?DBNull.Value:empresaModel.Modo     },
            new SqlParameter("@Pagina", SqlDbType.Int) { Value = string.IsNullOrEmpty(empresaModel.Pagina.ToString())?DBNull.Value:empresaModel.Pagina     },
            new SqlParameter("@ElementosPorPagina", SqlDbType.Int) { Value = string.IsNullOrEmpty(empresaModel.ElementosPorPagina.ToString())?DBNull.Value:empresaModel.ElementosPorPagina     },
            new SqlParameter("@Mensaje", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output } // Parámetro de salida
        };
        try
        {

            // Crear la cadena SQL con el stored procedure y los parámetros
            var sqlQuery = @"EXEC sp_GestionarEmpresa @Empresa, @Nombre, @RNC_CEDULA, @Descripcion, @Direccion, @Telefono1,@Telefono2, @Logo, @Estatus, @Correo_Principal, @SendGridKey, @OneSignalKey,@Primary_Color, @Second_Color, @Tipo, @Modo, @Pagina, @ElementosPorPagina, @Mensaje OUTPUT";

            var result = await _dbContext.Database
                .ExecuteSqlRawAsync(sqlQuery, parametros.ToArray());

                          

            var respuesta = new EmpresaResponse
            {
                cError = (int)parametros.First(p => p.ParameterName == "@Mensaje").Value,
                Mensaje = parametros.First(p => p.ParameterName == "@Mensaje").Value.ToString()??""
            

            };

            return respuesta;
        }
        catch (Exception ex)
        {
            return new EmpresaResponse
            {
                cError = 1,
                Mensaje = ex.Message
            };
        }
    }
}