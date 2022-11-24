using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEINT_MiBanco
{
    public partial class Form2 : Form
    {
        private Banco banco;
        private int editarBorrar;
        public Form2(Banco banco, int editarBorrar)
        {
            InitializeComponent();

            this.banco = banco;
            this.editarBorrar = editarBorrar;

            for (int i = 0; i < banco.clientes.Count; i++)
            {
                cbClientes.Items.Add(banco.clientes[i].dni);
            }

            cbClientes.SelectedIndex = 0;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Cliente cliente = null;

            for (int i = 0; i < banco.clientes.Count && cliente == null; i++)
            {
                if (banco.clientes[i].dni.Equals(cbClientes.SelectedItem.ToString()))
                {
                    cliente = banco.clientes[i];
                }
            }

            Form1.cliente = cliente;
            Form1.editarBorrar = editarBorrar;
            this.Close();
        }
    }
}
