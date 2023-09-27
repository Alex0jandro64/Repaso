using Repaso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repaso.Util
{
    internal class Utilidades
    {

        public static int imprimirDatosLista(List<Empleado> listaEmpleadosAntigua)
        {
            //Metodo que imprime y captura un Empleado
            int numEmpleado;

            //Imprimos todos los empleados actuales en la lista para facilitar los numeros de empleados
            foreach (Empleado empl in listaEmpleadosAntigua)
            {
                Console.WriteLine("\nNº Empleado {0}, {1} {2}, {3}, {4}, {5}", empl.NumEmpleado, empl.Nombre, empl.Apellidos, empl.Dni, empl.FechaNacimiento, empl.Titulacion);
            }
            Console.Write("\nQue empleado quiere seleccionar (nº Empleado) (Pulse 0 para salir): ");

            //Capturo el numero de empleado
            do
            {
                numEmpleado = Console.ReadKey().KeyChar - '0';

                if (numEmpleado < 0 || numEmpleado > listaEmpleadosAntigua.Count)
                {
                    Console.WriteLine("\nEl valor introducido no es correcto ");
                }
            } while (numEmpleado < 0 || numEmpleado > listaEmpleadosAntigua.Count);

            //Si es 0 significa que quiere salir y no modificar 

            return numEmpleado;


        }

        public static bool estaVacio(String txt)
        {
            if (txt.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool tieneNumeros(String txt)
        {
            Regex regex = new Regex(@"\d+");
            return regex.IsMatch(txt);
        }

        public static String pideApellidos()
        {
            String apellidos;
            do
            {
                //Compruebo que los tipos de datos son los correctos
                Console.Write("\nApellidos: ");
                apellidos = Console.ReadLine();
                if (estaVacio(apellidos))
                {
                    Console.WriteLine("El apellido no puede estar vacio");
                }
                else if (tieneNumeros(apellidos))
                {
                    Console.WriteLine("El apellido no puede contener numero");
                }

            } while (estaVacio(apellidos) || tieneNumeros(apellidos));

            //Si sale del bucle es que esta correcto entonces devuelvo el dato
            return apellidos;


        }

        public static String pideNombre()
        {
            String nombre;

            do
            {
                //Compruebo que los tipos de datos son los correctos
                Console.Write("\nNombre: ");
                nombre = Console.ReadLine();
                if (estaVacio(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacio");
                }
                else if (tieneNumeros(nombre))
                {
                    Console.WriteLine("El nombre no puede contener numero");
                }
            } while (estaVacio(nombre) || tieneNumeros(nombre));

            //Si sale del bucle es que esta correcto entonces devuelvo el dato
            return nombre;
        }

        public static String pideDni()
        {
            String dni;

            do
            {
                //Compruebo que los tipos de datos son los correctos
                Console.Write("\nDni: ");
                dni = Console.ReadLine();
                if (estaVacio(dni))
                {
                    Console.WriteLine("El dni no puede estar vacio");
                }
                else if (formatoErroneoDni(dni))
                {
                    Console.WriteLine("El dni tiene que tener 9 caracteres");
                }


            } while (estaVacio(dni) || formatoErroneoDni(dni));

            //Si sale del bucle es que esta correcto entonces devuelvo el dato
            return dni;
        }

        public static bool formatoErroneoDni(String dni)
        {
            if (dni.Length != 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int pideNumSeguridadSocial()
        {
            bool ok;
            int numeroSeguridadSocial;
            do
            {
                Console.Write("\nNumero de la seguridad social: ");
                ok = int.TryParse(Console.ReadLine(), out numeroSeguridadSocial);
                if (!ok)
                {
                    Console.WriteLine("El Numero de la Seguridad Social no puede tener caracteres no numericos");
                }
                else if (estaVacio(numeroSeguridadSocial.ToString()))
                {
                    Console.WriteLine("El Numero de la seguridad social no puede estar vacio");
                }
            } while (!ok || estaVacio(numeroSeguridadSocial.ToString()));

            return numeroSeguridadSocial;
        }

        public static int pideNumCuenta()
        {
            bool ok;
            int numeroCuenta;
            do
            {
                Console.Write("\nNumero de Cuenta: ");
                ok = int.TryParse(Console.ReadLine(), out numeroCuenta);
                if (!ok)
                {
                    Console.WriteLine("El Numero de la Cuenta no puede tener caracteres no numericos");
                }
                else if (estaVacio(numeroCuenta.ToString()))
                {
                    Console.WriteLine("El Numero de la Cuenta no puede estar vacio");
                }
            } while (!ok || estaVacio(numeroCuenta.ToString()));

            return numeroCuenta;
        }

        public static String pideFecha()
        {
            String fecha;
            do
            {
                //Compruebo que los tipos de datos son los correctos
                Console.Write("\nFecha de Nacimiento: ");
                fecha = Console.ReadLine();
                if (estaVacio(fecha))
                {
                    Console.WriteLine("La fecha de nacimiento no puede estar vacia");
                }


            } while (estaVacio(fecha));

            //Si sale del bucle es que esta correcto entonces devuelvo el dato
            return fecha;


        }

        public static String pideTitulacion()
        {
            String titulacion;
            do
            {
                //Compruebo que los tipos de datos son los correctos
                Console.Write("\nTitulacion: ");
                titulacion = Console.ReadLine();
                if (estaVacio(titulacion))
                {
                    Console.WriteLine("La titulacion no puede estar vacia");
                }


            } while (estaVacio(titulacion));

            //Si sale del bucle es que esta correcto entonces devuelvo el dato
            return titulacion;


        }

        public static int campoAModificar()
        {
            int numCampo;
            do
            {
                Console.Clear();

                //Imprimo las opciones que se pueden modificar

                Console.WriteLine("1.-Nombre");
                Console.WriteLine("2.-Apellidos");
                Console.WriteLine("3.-Dni");
                Console.WriteLine("4.-Fecha de Nacimiento");
                Console.WriteLine("5.-Titulacion");
                Console.WriteLine("6.-Numero de la Seguridad Social");
                Console.WriteLine("7.-Numero de Cuenta");
                Console.Write("Que campo quiere modificar: ");

                //Capturo la opcion


                numCampo = Console.ReadKey().KeyChar - '0';

                if (numCampo < 1 || numCampo > 7)
                {
                    Console.WriteLine("El valor introducido no es correcto ");
                }
            } while (numCampo < 1 || numCampo > 7);

            return numCampo;
        }

    }
}
