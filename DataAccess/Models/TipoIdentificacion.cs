using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Models
{
    public class TipoIdentificacion
    {
        public required int Id { get; set; }
        public required string Str_codigo { get; set; }
        public required string Str_descripcion { get; set; }
        public required IFormFile Archivo { get; set; }

    }
}
