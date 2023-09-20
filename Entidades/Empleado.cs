using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Modelos
{
    internal class Empleado
    {
        //Atributos
        string nombre, apellidos, dni, fechaNacimiento, titulacion;
        int numSeguridadSocial, numCuenta;

        //Constructores
        public Empleado()
        {
        }

        public Empleado(string nombre, string apellidos, string dni, string fechaNacimiento, string titulacion, int numSeguridadSocial, int numCuenta)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
            this.titulacion = titulacion;
            this.numSeguridadSocial = numSeguridadSocial;
            this.numCuenta = numCuenta;
        }

        //Getters y Setters

    }
}
