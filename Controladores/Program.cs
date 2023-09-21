using Repaso.Modelos;
using Repaso.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanciamos 
            ImplMenu implMenu = new ImplMenu();
            ImplEmpleado implEmpleado = new ImplEmpleado();
            List<Empleado> listaEmpleados = new List<Empleado>();

            //Ejecucion del programa
            int opcion;

            do
            {
                do
                {
                    //Muestra el menu y recoge opcion siempre que este dentro del rango
                    Console.Clear();
                    implMenu.Menu();
                    opcion = Console.ReadKey().KeyChar - '0';
                } while (opcion < 1 || opcion > 4);
                
                switch(opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("---------Registrar Empleado---------");
                        implEmpleado.registrarEmpleado(listaEmpleados);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("---------Modificar Empleado---------");
                        implEmpleado.modificarEmpleado(listaEmpleados);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("---------Exportar a Fichero---------");
                        implEmpleado.exportarFichero(listaEmpleados);
                        break;
                }


            } while (opcion != 4);
            
            


            
                
           
            



        }
        
    }
}
