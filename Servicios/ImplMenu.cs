using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Servicios
{
    internal class ImplMenu:InterfazMenu
    {
        public void Menu()
        {
            Console.WriteLine("1.-Registro Empleado");
            Console.WriteLine("2.-Modificar Empleado");
            Console.WriteLine("3.-Exportar a Fichero");
            Console.WriteLine("4.-Cerrar");

        }
    }
}
