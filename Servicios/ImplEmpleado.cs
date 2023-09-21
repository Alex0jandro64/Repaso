using Repaso.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {

            
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
            }catch(Exception ex)
            {
                Console.WriteLine("---Error---");
                Console.WriteLine("---Pulse cualquier tecla para continuar---");
                Console.ReadLine();
            }
        }

        public void modificarEmpleado(List<Empleado> listaEmpleadosAntigua)
        {
            //Metodo que imprime y captura un Empleado
            int numEmpleado = imprimirDatosLista(listaEmpleadosAntigua);

            //Pido y modifico los datos del empleado seleccionado
            Console.Write("\nNombre: ");
            listaEmpleadosAntigua[numEmpleado - 1].Nombre = Console.ReadLine();
            Console.Write("Apellidos: ");
            listaEmpleadosAntigua[numEmpleado - 1].Apellidos = Console.ReadLine();
            Console.Write("DNI: ");
            listaEmpleadosAntigua[numEmpleado - 1].Dni = Console.ReadLine();
            Console.Write("Fecha de Nacimiento: ");
            listaEmpleadosAntigua[numEmpleado - 1].FechaNacimiento = Console.ReadLine();
            Console.Write("Titulacion: ");
            listaEmpleadosAntigua[numEmpleado - 1].Titulacion = Console.ReadLine();
            Console.Write("Numero de la seguridad social: ");
            listaEmpleadosAntigua[numEmpleado - 1].NumSeguridadSocial = Convert.ToInt32(Console.ReadLine());
            Console.Write("Numero de cuenta: ");
            listaEmpleadosAntigua[numEmpleado - 1].NumCuenta = Convert.ToInt32(Console.ReadLine());

            Console.Write("Pulse cualquier tecla para volver al menu");
            Console.ReadLine();
        }

        public void exportarFichero(List<Empleado> listaEmpleadosAntigua)
        {
            int opcion;
            //Pregunto y capturo si quiere exportar a todos o solo a uno
            do
            {
                Console.Clear();
                Console.Write("Quiere exportar todos los Empleados (1) o solo a uno (2): ");
                opcion = Console.ReadKey().KeyChar - '0';
            } while (opcion < 1 || opcion > 2);

            //Independiente de la opcion, creo el fichero y le pongo cabecera
            //La Ruta de donde se creara el fichero
            StreamWriter sw = File.CreateText(@".\\Empleados.txt");
            sw.WriteLine("Numero de Empleado;Nombre;Apellidos;Dni;Fecha de Nacimiento;Titulacion");

            if (opcion == 1)
            {
                for (int i = 0; i < listaEmpleadosAntigua.Count; i++)
                {
                    sw.WriteLine("{0};{1};{2};{3};{4};{5};{6}", listaEmpleadosAntigua[i].NumEmpleado, listaEmpleadosAntigua[i].Nombre, listaEmpleadosAntigua[i].Apellidos, listaEmpleadosAntigua[i].Dni, listaEmpleadosAntigua[i].FechaNacimiento, listaEmpleadosAntigua[i].Titulacion);
                }
            }
            else
            {
                //Muestro y capturo el Empleado que quiere exportar
                int numEmpleado = imprimirDatosLista(listaEmpleadosAntigua);
                sw.WriteLine("{0};{1};{2};{3};{4};{5};{6}", listaEmpleadosAntigua[numEmpleado].NumEmpleado, listaEmpleadosAntigua[numEmpleado].Nombre, listaEmpleadosAntigua[numEmpleado].Apellidos, listaEmpleadosAntigua[numEmpleado].Dni, listaEmpleadosAntigua[numEmpleado].FechaNacimiento, listaEmpleadosAntigua[numEmpleado].Titulacion);
            }
            sw.Close();
        }

        public int imprimirDatosLista(List<Empleado> listaEmpleadosAntigua)
        {
            //Metodo que imprime y captura un Empleado
            int numEmpleado;

            //Imprimos todos los empleados actuales en la lista para facilitar los numeros de empleados
            foreach (Empleado empl in listaEmpleadosAntigua)
            {
                Console.WriteLine("\nNº Empleado {0}, {1} {2}", empl.NumEmpleado, empl.Nombre, empl.Apellidos);
            }
            Console.WriteLine("Que empleado quiere seleccionar (nº Empleado): ");

            //Capturo el numero de empleado
            do
            {
                numEmpleado = Console.ReadKey().KeyChar - '0';

                if (numEmpleado < 1 || numEmpleado > listaEmpleadosAntigua.Count)
                {
                    Console.WriteLine("El valor introducido no es correcto ");
                }
            } while (numEmpleado < 1 || numEmpleado > listaEmpleadosAntigua.Count);

            return numEmpleado;
        }
    }
}
