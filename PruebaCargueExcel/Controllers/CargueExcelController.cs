using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using PruebaCargueExcel.Models;
using System.Data;
using PruebaCargueExcel.Services;
using Services;
using DataAccess.Repository;
using DataAccess.Models;
using System.Security.Principal;

namespace PruebaCargueExcel.Controllers
{
    [Route("api/[controller]")]
    public class CargueExcelController:ControllerBase
    {
        //ITmpCargueExcelService cargueExcelService;
        private readonly ICargueExcelService<TmpCargueExcel> cargueExcelService;
        private readonly PruebaCargueExcelContext excelContext;
        //private readonly GenericEntity<TipoIdentificacion> _TipoIdentificacion;
        public CargueExcelController(PruebaCargueExcelContext _excelContext, ICargueExcelService<TmpCargueExcel> _cargueExcelService)
        {
            cargueExcelService = _cargueExcelService;
            excelContext = _excelContext;
            //_TipoIdentificacion = genericEntity;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = cargueExcelService.Get();
            return Ok(lista);
        }


        //[HttpGet]
        //public ActionResult<IEnumerable<TmpCargueExcel>> get()
        //{
        //    var result = cargueExcelService.Get();
        //    if(result == null || !result.Any())
        //    {
        //        return NotFound("NO SE ENCONTRARON DATOS.");
        //    }
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public IActionResult LoadFile(IFormFile archivoExcel)
        //{
        //    var resultado = "";
        //    //var nombre_archivo = archivoExcel.FileName.Split('.');
        //    if (archivoExcel == null || archivoExcel.Length == 0)
        //    {
        //        return BadRequest("No se ha seleccionado un archivo");
        //    }
        //    var dataTable = cargueExcelService.LeerExcelDataTable(archivoExcel);
        //    resultado = cargueExcelService.CargarDataTable(dataTable);
        //    return Ok(resultado);
        //}
    }
}
