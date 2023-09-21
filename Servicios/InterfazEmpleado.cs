using Repaso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Servicios
{
    internal interface InterfazEmpleado
    {
        void registrarEmpleado(List<Empleado> listaEmpleadosAntigua);

        void modificarEmpleado(List<Empleado> listaEmpleadosAntigua);

        void exportarFichero(List<Empleado> listaEmpleadosAntigua);

        int imprimirDatosLista(List<Empleado> listaEmpleadosAntigua);
    }
}
