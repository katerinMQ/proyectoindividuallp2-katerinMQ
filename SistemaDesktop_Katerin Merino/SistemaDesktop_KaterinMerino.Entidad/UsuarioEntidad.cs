using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDesktop_KaterinMerino.Entidad
{
    public class UsuarioEntidad
    {
        public int UsuarioId { get; set; }  //get captura // set imprimir
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Nivel { get; set; }
        public string Estado { get; set; }
    }
}
