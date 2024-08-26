using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; } 

        public Usuarios() { }   

        public Usuarios(string NombreUsuario, string Contraseña)
        {
            this.NombreUsuario = NombreUsuario;
            this.Contraseña = Contraseña;
        }
    }
}
