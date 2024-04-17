using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Conductor: EntidadBase
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public string LicenciaTransito { get; set; }
        public DateOnly FechaNacimiento { get; set; }

    }
}
