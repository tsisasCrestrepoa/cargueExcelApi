using Microsoft.AspNetCore.Http;

namespace PruebaCargueExcel.Models
{
    public class TmpCargueExcel
    {
        public int Id { get; set; }
        public required DateTime Dtm_fecha_cargue { get; set; }
        public required string  Str_codigo { get; set; }
        public required string Str_descripcion { get; set; }
        public  IFormFile ?Archivo { get; set; }
    }
}
