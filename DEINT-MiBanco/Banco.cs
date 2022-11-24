using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEINT_MiBanco
{
    internal class Banco
    {
        public List<Cliente> clientes { get; set; }

        public Banco()
        {
            this.clientes = new List<Cliente>();
        }

        public Banco(List<Cliente> clientes)
        {
            this.clientes = clientes;
        }
    }
}