using Repaso.Modelos;
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
                empl1.Nombre = pideNombre();
                empl1.Apellidos = pideApellidos();
                empl1.Dni = pideDni();
                empl1.FechaNacimiento = pideFecha();
                empl1.Titulacion = pideTitulacion();
                empl1.NumSeguridadSocial = pideNumSeguridadSocial();
                empl1.NumCuenta = pideNumCuenta();

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
            int numEmpleado = imprimirDatosLista(listaEmpleadosAntigua);

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
                int numCampo = campoAModificar();

                switch (numCampo)
                {
                    case 1:
                        listaEmpleadosAntigua[numEmpleado].Nombre = pideNombre();
                        break;
                    case 2:
                        listaEmpleadosAntigua[numEmpleado].Apellidos = pideApellidos();
                        break;
                    case 3:
                        listaEmpleadosAntigua[numEmpleado].Dni = pideDni();
                        break;
                    case 4:
                        listaEmpleadosAntigua[numEmpleado].FechaNacimiento = pideFecha();
                        break;
                    case 5:
                        listaEmpleadosAntigua[numEmpleado].Titulacion = pideTitulacion();
                        break;
                    case 6:
                        listaEmpleadosAntigua[numEmpleado].NumSeguridadSocial = pideNumSeguridadSocial();
                        break;
                    case 7:
                        listaEmpleadosAntigua[numEmpleado].NumCuenta = pideNumCuenta();
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
                int numEmpleado = imprimirDatosLista(listaEmpleadosAntigua);

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

        private int imprimirDatosLista(List<Empleado> listaEmpleadosAntigua)
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

        private bool estaVacio(String txt)
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

        private bool tieneNumeros(String txt)
        {
            Regex regex = new Regex(@"\d+");
            return regex.IsMatch(txt);
        }

        private String pideApellidos()
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

        private String pideNombre()
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

        private String pideDni()
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

        private bool formatoErroneoDni(String dni)
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

        private int pideNumSeguridadSocial()
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

        private int pideNumCuenta()
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

        private String pideFecha()
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

        private String pideTitulacion()
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

        private int campoAModificar()
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
