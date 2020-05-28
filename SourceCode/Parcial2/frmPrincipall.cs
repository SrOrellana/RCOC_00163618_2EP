using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class frmPrincipall : Form
    {
        private Usuario user;
        public frmPrincipall(Usuario pUsuario)
        {
            InitializeComponent();
            user = pUsuario;
            cmbPermisos.DataSource = new List<String>() {"admin","user"};
        }

        private void frmPrincipall_Load(object sender, EventArgs e)
        {
            label6.Text = "Usuario: " + user.usuario;
          
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioDAO.ActualizarPermisos(comboBox1.Text, cmbPermisos.Text);
           
            MessageBox.Show("Permisos actualizados con éxito!",
                "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length >= 1 && textBox2.Text.Length >= 1 &&
                    (textBox3.Text.Length == 1 || textBox3.Text.Length == 1))
                {
                    UsuarioDAO.CrearNuevo(textBox1.ToString(),textBox2.ToString(),textBox3.ToString(),textBox4.ToString());

                    MessageBox.Show("Usuario agregado con exito!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("Datos invalidos",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Datos invalidos",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }
        

        
    }
}