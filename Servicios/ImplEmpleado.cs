using Repaso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Servicios
{
    internal class ImplEmpleado : InterfazEmpleado
    {
        public void registrarEmpleado(List<Empleado> listaEmpleadosAntigua)
        {
            //Creo el objeto empleado
            Empleado empl1 = new Empleado();

            //Pido todos los datos necesarios y los guardo en el objeto creado
            Console.Write("Nombre: ");
            empl1.Nombre = Console.ReadLine();
            Console.Write("Apellidos: ");
            empl1.Apellidos = Console.ReadLine();
            Console.Write("DNI: ");
            empl1.Dni = Console.ReadLine();
            Console.Write("Fecha de Nacimiento: ");
            empl1.FechaNacimiento = Console.ReadLine();
            Console.Write("Titulacion: ");
            empl1.Titulacion = Console.ReadLine();
            Console.Write("Numero de la seguridad social: ");
            empl1.NumSeguridadSocial = Convert.ToInt32(Console.ReadLine());
            Console.Write("Numero de cuenta: ");
            empl1.NumCuenta = Convert.ToInt32(Console.ReadLine());

            //El numero de empleado es igual al numero de elementos que tiene la lista para que sea univoca
            empl1.NumEmpleado = listaEmpleadosAntigua.Count+1;
            Console.Write("Pulse cualquier tecla para registrar el usuario");
            Console.ReadLine();

            //Envio los datos a la lista
            listaEmpleadosAntigua.Add(empl1);
        }

        public void modificarEmpleado(List<Empleado> listaEmpleadosAntigua)
        {
            int numEmpleado;

            //Imprimos todos los empleados actuales en la lista para facilitar los numeros de empleados
            foreach (Empleado empl in listaEmpleadosAntigua)
            {
                Console.WriteLine("Nº Empleado {0}, {1} {2}",empl.NumEmpleado, empl.Nombre, empl.Apellidos);
            }
            Console.WriteLine("\nQue empleado quiere modificar (nº Empleado): ");

            //Capturo el numero de empleado
            do
            {
                numEmpleado = Console.ReadKey(true).KeyChar - '0';

                if(numEmpleado < 1 || numEmpleado > listaEmpleadosAntigua.Count)
                {
                    Console.WriteLine("El valor introducido no es correcto ");
                }
            } while (numEmpleado < 1 || numEmpleado > listaEmpleadosAntigua.Count);
            
        }

    }
}
