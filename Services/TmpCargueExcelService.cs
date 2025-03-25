using ClosedXML.Excel;
//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using PruebaCargueExcel.Models;
using System.Data;

namespace PruebaCargueExcel.Services
{
    public class TmpCargueExcelService:ITmpCargueExcelService
    {
        PruebaCargueExcelContext context;
        public TmpCargueExcelService(PruebaCargueExcelContext dbcontext) 
        {
            context = dbcontext;
        }
        
        public IEnumerable<TmpCargueExcel> Get()
        {
            return context.TmpCargueExcel.ToList();
        }

        public DataTable LeerExcelDataTable(IFormFile archivoExcel)
        {
            var dataTable = new DataTable();
            using (var memoryStream = new MemoryStream())
            {
                archivoExcel.CopyTo(memoryStream);
                using (var LibroTrabajo = new XLWorkbook(memoryStream))
                {
                    var hojaTrabajo = LibroTrabajo.Worksheet(1);
                    var filas = hojaTrabajo.RowsUsed().Skip(1);

                    var cabeceraFila = hojaTrabajo.Row(1);
                    foreach (var celda in cabeceraFila.Cells())
                    {
                        dataTable.Columns.Add(celda.Value.ToString());
                    }
                    foreach (var fila in filas)
                    {
                        var dataRow = dataTable.NewRow();
                        for (int i = 0; i < fila.Cells().Count(); i++)
                        {
                            dataRow[i] = fila.Cell(i + 1).Value;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            return dataTable;
        }

        public string CargarDataTable(DataTable dataTable)
        {
            var resultado = "";
            try
            {
                using (context)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var tmpCargueExcel = new TmpCargueExcel
                        {
                            Dtm_fecha_cargue = DateTime.Now.Date,
                            Str_codigo = row["Codigo"].ToString(),
                            Str_descripcion = row["Descripcion"].ToString()
                        };

                        context.TmpCargueExcel.Add(tmpCargueExcel);
                    }
                    context.SaveChanges();
                }
                resultado = "Cargue realizado con exito.";
            }
            catch (Exception ex) 
            {
                resultado = ex.Message;
            }
            
            return resultado;
        }

    }

    public interface ITmpCargueExcelService
    {
        IEnumerable<TmpCargueExcel> Get();
        DataTable LeerExcelDataTable(IFormFile archivoExcel);
        string CargarDataTable(DataTable dataTable);
    }
}
