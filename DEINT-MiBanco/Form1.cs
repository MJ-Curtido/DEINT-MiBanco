using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//datasource = arraylist clientes       DATO A TENER EN CUENTA PARA EL DATASOURCE SIN HACER DATASET
namespace DEINT_MiBanco
{
    public partial class Form1 : Form
    {
        private Banco banco;
        public static Cliente cliente;
        public static int editarBorrar; //0:nada, 1:editar, 2:borrar

        public Form1()
        {
            InitializeComponent();
        }

        private void cambiarTb()
        {
            if (editarBorrar == 1)
            {
                tbDireccion.Text = cliente.direccion;
                tbNombre.Text = cliente.nombre;
                tbDNI.Text = cliente.dni;
                tbEdad.Text = cliente.edad + "";
                tbTelefono.Text = cliente.telefono + "";
                tbNCuenta.Text = cliente.numCuenta;

                alternarParaModificar();
            }
            else if (editarBorrar == 2)
            {
                tbDireccion.Text = cliente.direccion;
                tbNombre.Text = cliente.nombre;
                tbDNI.Text = cliente.dni;
                tbEdad.Text = cliente.edad + "";
                tbTelefono.Text = cliente.telefono + "";
                tbNCuenta.Text = cliente.numCuenta;

                alternarParaEliminar();
            }
        }

        public void alternarParaEliminar()
        {
            if (tbDireccion.Enabled)
            {
                tbDireccion.Enabled = false;
                tbNombre.Enabled = false;
                tbDNI.Enabled = false;
                tbEdad.Enabled = false;
                tbTelefono.Enabled = false;
                tbNCuenta.Enabled = false;
                btnAnyadir.Enabled = false;
                btnModificar.Enabled = false;
                btnMostrar.Enabled = false;
            }
            else
            {
                tbDireccion.Enabled = true;
                tbNombre.Enabled = true;
                tbDNI.Enabled = true;
                tbEdad.Enabled = true;
                tbTelefono.Enabled = true;
                tbNCuenta.Enabled = true;
                btnAnyadir.Enabled = true;
                btnModificar.Enabled = true;
                btnMostrar.Enabled = true;
            }
        }

        public void alternarParaModificar()
        {
            if (btnAnyadir.Enabled)
            {
                btnAnyadir.Enabled = false;
                btnEliminar.Enabled = false;
                btnMostrar.Enabled = false;
            }
            else
            {
                btnAnyadir.Enabled = true;
                btnEliminar.Enabled = true;
                btnMostrar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (editarBorrar == 1)
            {
                banco.clientes.Remove(cliente);

                if (!anyadirCliente())
                {
                    banco.clientes.Add(cliente);
                }

                tbDireccion.Text = "";
                tbNombre.Text = "";
                tbDNI.Text = "";
                tbEdad.Text = "";
                tbTelefono.Text = "";
                tbNCuenta.Text = "";

                alternarParaModificar();

                editarBorrar = 0;
            }
            else
            {
                Form2 form = new Form2(banco, 1);
                form.ShowDialog();

                cambiarTb();
            }
        }

        private void tbDNI_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(tbDNI.Text, @"^[0-9]{8}[A-Z]$"))
            {
                this.errores.SetError(this.tbDNI, "DNI incorrecto.");
                e.Cancel = true;
            }
            else
            {
                this.errores.SetError(this.tbDNI, "");
                e.Cancel = false;
            }
        }

        private void tbNombre_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(tbNombre.Text, @"^\w+$"))
            {
                this.errores.SetError(this.tbNombre, "Nombre incorrecto.");
                e.Cancel = true;
            }
            else
            {
                this.errores.SetError(this.tbNombre, "");
                e.Cancel = false;
            }
        }

        private void tbDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(tbDireccion.Text, @"^\w+$"))
            {
                this.errores.SetError(this.tbDireccion, "Dirección incorrecta.");
                e.Cancel = true;
            }
            else
            {
                this.errores.SetError(this.tbDireccion, "");
                e.Cancel = false;
            }
        }

        private void tbEdad_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(tbEdad.Text, @"^[0-9]+$"))
            {
                this.errores.SetError(this.tbEdad, "Edad incorrecta.");
                e.Cancel = true;
            }
            else
            {
                this.errores.SetError(this.tbEdad, "");
                e.Cancel = false;
            }
        }

        private void tbTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(tbTelefono.Text, @"^[0-9]{9}$"))
            {
                this.errores.SetError(this.tbTelefono, "Teléfono incorrecto.");
                e.Cancel = true;
            }
            else
            {
                this.errores.SetError(this.tbTelefono, "");
                e.Cancel = false;
            }
        }

        private void tbNCuenta_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(tbNCuenta.Text, @"^[0-9]{20}$"))
            {
                this.errores.SetError(this.tbNCuenta, "Número de cuenta incorrecto.");
                e.Cancel = true;
            }
            else
            {
                this.errores.SetError(this.tbNCuenta, "");
                e.Cancel = false;
            }
        }
        
        private void btnAnyadir_Click(object sender, EventArgs e)
        {
            anyadirCliente();
        }

        public Boolean anyadirCliente()
        {
            Boolean anyadido = false;

            if (this.ValidateChildren())
            {

                Cliente c = new Cliente(tbDNI.Text.ToString(), tbNombre.Text.ToString(), tbDireccion.Text.ToString(), int.Parse(tbEdad.Text.ToString()), int.Parse(tbTelefono.Text.ToString()), tbNCuenta.Text.ToString());

                if (!banco.clientes.Contains(c))
                {
                    banco.clientes.Add(c);
                    MessageBox.Show("Se ha añadido el cliente correctamente.");
                    anyadido = true;
                }
                else
                {
                    MessageBox.Show("Cliente registrado en el banco.");
                }
            }

            return anyadido;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Banco));

                using (var stream = new FileStream("banco.xml", FileMode.Open))
                {
                    var bancoSerializado = (Banco) serializer.Deserialize(stream);

                    this.banco = bancoSerializado;
                }
            }
            catch (Exception)
            {
                this.banco = new Banco();
            }

            this.ActiveControl = label1;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Banco));

            using (var stream = new FileStream("banco.xml", FileMode.Create))
            {
                serializer.Serialize(stream, this.banco);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (editarBorrar == 2)
            {
                banco.clientes.Remove(cliente);

                tbDireccion.Text = "";
                tbNombre.Text = "";
                tbDNI.Text = "";
                tbEdad.Text = "";
                tbTelefono.Text = "";
                tbNCuenta.Text = "";

                alternarParaModificar();

                editarBorrar = 0;
            }
            else
            {
                Form2 form = new Form2(banco, 2);
                form.ShowDialog();
            }
        }
    }
}
