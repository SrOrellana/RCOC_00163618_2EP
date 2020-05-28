using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class frmCambirContra : Form
    {
        public frmCambirContra()
        {
            InitializeComponent();
        }

        private void frmCambirContra_Load(object sender, EventArgs e)
        {
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "contrasena";
            cmbUsuario.DisplayMember = "usuario";
            cmbUsuario.DataSource = UsuarioDAO.GetLista();
        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtActual.Text.Equals(txtNueva.Text))
                {
                    UsuarioDAO.actualizarContra(cmbUsuario.Text, txtNueva.Text);
                    MessageBox.Show("Se actualizo la contrasena", "Hugo App", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Datos incorrectos", "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique su datos!", "Hugo App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
    }
