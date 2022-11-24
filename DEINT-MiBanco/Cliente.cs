using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEINT_MiBanco
{
    internal class Cliente
    {
        public String dni { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public int edad { get; set; }
        public int telefono { get; set; }
        public int numCuenta { get; set; }

        public Cliente()
        {
            this.dni = default;
            this.nombre = default;
            this.direccion = default;
            this.edad = default;
            this.telefono = default;
            this.numCuenta = default;
        }

        public Cliente(String dni, String nombre, String direccion, int edad, int telefono, int numCuenta)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.direccion = direccion;
            this.edad = edad;
            this.telefono = telefono;
            this.numCuenta = numCuenta;
        }
    }
}