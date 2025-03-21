using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using PruebaCargueExcel.Models;
using PruebaCargueExcel.Services;
using System.Data;

namespace PruebaCargueExcel.Controllers
{
    [Route("api/[controller]")]
    public class CargueExcelController:ControllerBase
    {
        ITmpCargueExcelService cargueExcelService;
        private readonly PruebaCargueExcelContext excelContext;
        public CargueExcelController(ITmpCargueExcelService _cargueExcelService, PruebaCargueExcelContext _excelContext)
        {
            cargueExcelService = _cargueExcelService;
            excelContext = _excelContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TmpCargueExcel>> get()
        {
            var result = cargueExcelService.Get();
            if(result == null || !result.Any())
            {
                return NotFound("NO SE ENCONTRARON DATOS.");
            }
            return Ok(result);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult LoadFile(IFormFile archivoExcel)
        {
            var resultado = "";
            if (archivoExcel == null || archivoExcel.Length == 0)
            {
                return BadRequest("No se ha seleccionado un archivo");
            }
            var dataTable = cargueExcelService.LeerExcelDataTable(archivoExcel);
            resultado = cargueExcelService.CargarDataTable(dataTable);
            return Ok(resultado);
        }
    }
}
