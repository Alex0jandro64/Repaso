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
        int numSeguridadSocial, numCuenta, numEmpleado;

        //Constructores
        public Empleado()
        {
        }

        public Empleado(string nombre, string apellidos, string dni, string fechaNacimiento, string titulacion, int numSeguridadSocial, int numCuenta, int numEmpleado)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
            this.titulacion = titulacion;
            this.numSeguridadSocial = numSeguridadSocial;
            this.numCuenta = numCuenta;
            this.numEmpleado = numEmpleado;
        }


        //Getters y Setters
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Dni { get => dni; set => dni = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Titulacion { get => titulacion; set => titulacion = value; }
        public int NumSeguridadSocial { get => numSeguridadSocial; set => numSeguridadSocial = value; }
        public int NumCuenta { get => numCuenta; set => numCuenta = value; }
        public int NumEmpleado { get => numEmpleado; set => numEmpleado = value; }

    }
}
