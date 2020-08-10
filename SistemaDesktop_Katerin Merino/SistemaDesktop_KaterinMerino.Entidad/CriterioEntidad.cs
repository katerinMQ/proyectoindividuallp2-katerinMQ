using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDesktop_KaterinMerino.Entidad
{
    public class CriterioEntidad
    {
        public int CriterioId { get; set; }
        public int ModeloId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
