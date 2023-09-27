using Repaso.Modelos;
using Repaso.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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
                empl1.Nombre = Utilidades.pideNombre();
                empl1.Apellidos = Utilidades.pideApellidos();
                empl1.Dni = Utilidades.pideDni();
                empl1.FechaNacimiento = Utilidades.pideFecha();
                empl1.Titulacion = Utilidades.pideTitulacion();
                empl1.NumSeguridadSocial = Utilidades.pideNumSeguridadSocial();
                empl1.NumCuenta = Utilidades.pideNumCuenta();

                //El numero de empleado es igual al numero de elementos que tiene la lista para que sea univoca
                empl1.NumEmpleado = listaEmpleadosAntigua.Count + 1;

                Console.Write("Pulse cualquier tecla para registrar el usuario");
                Console.ReadLine();

                //Envio los datos a la lista
                listaEmpleadosAntigua.Add(empl1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("---Error---");
                Console.WriteLine("---Pulse cualquier tecla para continuar---");
                Console.ReadLine();
            }
        }

        public void modificarEmpleado(List<Empleado> listaEmpleadosAntigua)
        {
            //Metodo que imprime y captura un Empleado
            int numEmpleado = Utilidades.imprimirDatosLista(listaEmpleadosAntigua);

            //Si pulsa 0 significa que el usuario quiere salir y no modificar
            bool salir = false;
            if (numEmpleado == 0)
            {
                salir = true;
            }
               

            if (!salir)
            {
                numEmpleado--;

                //Pregunto que campo quiere modificar y llamo a su correspondiente metodo
                int numCampo = Utilidades.campoAModificar();

                switch (numCampo)
                {
                    case 1:
                        listaEmpleadosAntigua[numEmpleado].Nombre = Utilidades.pideNombre();
                        break;
                    case 2:
                        listaEmpleadosAntigua[numEmpleado].Apellidos = Utilidades.pideApellidos();
                        break;
                    case 3:
                        listaEmpleadosAntigua[numEmpleado].Dni = Utilidades.pideDni();
                        break;
                    case 4:
                        listaEmpleadosAntigua[numEmpleado].FechaNacimiento = Utilidades.pideFecha();
                        break;
                    case 5:
                        listaEmpleadosAntigua[numEmpleado].Titulacion = Utilidades.pideTitulacion();
                        break;
                    case 6:
                        listaEmpleadosAntigua[numEmpleado].NumSeguridadSocial = Utilidades.pideNumSeguridadSocial();
                        break;
                    case 7:
                        listaEmpleadosAntigua[numEmpleado].NumCuenta = Utilidades.pideNumCuenta();
                        break;
                    
                }
            }
            
        }

        public void exportarFichero(List<Empleado> listaEmpleadosAntigua)
        {
            int opcion;
            //Pregunto y capturo si quiere exportar a todos o solo a uno
            do
            {
                Console.Write("\nQuiere exportar todos los Empleados (1) o solo a uno (2): ");
                opcion = Console.ReadKey().KeyChar - '0';
            } while (opcion < 1 || opcion > 2);

            //Independiente de la opcion, creo el fichero y le pongo cabecera
            //La Ruta de donde se creara el fichero
            StreamWriter sw = File.CreateText(@".\\Empleados.txt");
            sw.WriteLine("Numero de Empleado;Nombre;Apellidos;Dni;Fecha de Nacimiento;Titulacion");

            //Exporto toda la lista
            if (opcion == 1) 
            {
                for (int i = 0; i < listaEmpleadosAntigua.Count; i++)
                {
                    sw.WriteLine("{0};{1};{2};{3};{4};{5}", listaEmpleadosAntigua[i].NumEmpleado, listaEmpleadosAntigua[i].Nombre, listaEmpleadosAntigua[i].Apellidos, listaEmpleadosAntigua[i].Dni, listaEmpleadosAntigua[i].FechaNacimiento, listaEmpleadosAntigua[i].Titulacion);
                }
            }
            else
            {
                //Muestro y capturo el Empleado que quiere exportar
                int numEmpleado = Utilidades.imprimirDatosLista(listaEmpleadosAntigua);

                bool salir = false;
                if (numEmpleado == 0)
                    salir = true;

                if (!salir)
                {
                    numEmpleado--;
                    sw.WriteLine("{0};{1};{2};{3};{4};{5}", listaEmpleadosAntigua[numEmpleado].NumEmpleado, listaEmpleadosAntigua[numEmpleado].Nombre, listaEmpleadosAntigua[numEmpleado].Apellidos, listaEmpleadosAntigua[numEmpleado].Dni, listaEmpleadosAntigua[numEmpleado].FechaNacimiento, listaEmpleadosAntigua[numEmpleado].Titulacion);
                }
            }
            sw.Close();
        }

        
    }
}
