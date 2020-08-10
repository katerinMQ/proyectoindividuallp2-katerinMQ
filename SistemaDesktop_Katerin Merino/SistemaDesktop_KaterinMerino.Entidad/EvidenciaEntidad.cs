using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDesktop_KaterinMerino.Entidad
{
    public class EvidenciaEntidad
    {
        public int EvidenciaId { get; set; }
        public int ModeloId { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public string Tipo { get; set; }
        public string Tamanio { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
