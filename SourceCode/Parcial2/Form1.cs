using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 try
                 {
                     var user = UsuarioDAO.GetUser(textBox1.Text, textBox2.Text);
                     if (user.tipo.Equals(""))
                     {
                         MessageBox.Show("Usuario y/o contraseña incorrectos","Hugo",
                             MessageBoxButtons.OK,MessageBoxIcon.Error);
                     }
                     else
                     {
                         MessageBox.Show("Bienvenido","Hugo",
                             MessageBoxButtons.OK,MessageBoxIcon.Information);
                         frmPrincipall ventana = new frmPrincipall(user);
                         ventana.Show();
                         this.Hide();
                            
                     }
                 }
                 catch (Exception exception)
                 {
                     MessageBox.Show(exception.ToString());
                     throw;
                 }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCambirContra unaVentana = new frmCambirContra();
            unaVentana.ShowDialog();
        }
    }
}