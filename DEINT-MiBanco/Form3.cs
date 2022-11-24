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
    public partial class Form3 : Form
    {
        private Banco banco;

        public Form3(Banco banco)
        {
            InitializeComponent();
            this.banco = banco;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //dgv.DataSource = banco.clientes;
            
            for (int i = 0; i < banco.clientes.Count; i++)
            {
                int n = dgv.Rows.Add();

                dgv.Rows[n].Cells[0].Value = banco.clientes[i].dni;
                dgv.Rows[n].Cells[1].Value = banco.clientes[i].nombre;
                dgv.Rows[n].Cells[2].Value = banco.clientes[i].direccion;
                dgv.Rows[n].Cells[3].Value = banco.clientes[i].edad;
                dgv.Rows[n].Cells[4].Value = banco.clientes[i].telefono;
                dgv.Rows[n].Cells[5].Value = banco.clientes[i].numCuenta;
            }
        }
    }
}
